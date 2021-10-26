using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoManager : MonoBehaviour
{
    private static PianoManager m_instance;
    public static PianoManager Instance { get { return m_instance; } }

    public PianoKeyboard[] keyboards;
    private int current_index = 0;

    private List<string> notes_on_paper;

    [SerializeField] private Image[] position_one;
    [SerializeField] private Image[] position_two;
    [SerializeField] private Image[] position_three;
    [SerializeField] private Image[] position_four;
    [SerializeField] private Image[] position_five;

    [SerializeField] private AudioClip F;
    [SerializeField] private AudioClip G;
    [SerializeField] private AudioClip A;
    [SerializeField] private AudioClip B;
    [SerializeField] private AudioClip C;
    [SerializeField] private AudioClip D;
    [SerializeField] private AudioClip E;
    [SerializeField] private AudioClip Complete;

    public bool is_opened = false;

    [SerializeField] private InputReader input_reader;

    private void Awake()
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;
        
        keyboards[current_index].Select();
        notes_on_paper = new List<string>();
    }

    public void Show()
    {
        input_reader.ui_OnRight += OnRightKeyDown;
        input_reader.ui_OnLeft += OnLeftKeyDown;
        input_reader.ui_OnSubmit += OnSubmitKeyDown;
        input_reader.ui_OnExit += OnExitKeyDown;
        current_index = 0;
        for(int i=0; i<keyboards.Length; i++)
            keyboards[i].UnSelect();
        notes_on_paper.Clear();
        keyboards[current_index].Select();
    }

    public void Close() 
    {
        input_reader.ui_OnRight -= OnRightKeyDown;
        input_reader.ui_OnLeft -= OnLeftKeyDown;
        input_reader.ui_OnSubmit -= OnSubmitKeyDown;
        input_reader.ui_OnExit -= OnExitKeyDown;

        for(int i=0; i < position_one.Length; ++i) 
            position_one[i].gameObject.SetActive(false);
        for(int i=0; i < position_two.Length; ++i) 
            position_two[i].gameObject.SetActive(false);
        for(int i=0; i < position_three.Length; ++i) 
            position_three[i].gameObject.SetActive(false);
        for(int i=0; i < position_four.Length; ++i) 
            position_four[i].gameObject.SetActive(false);
        for(int i=0; i < position_five.Length; ++i) 
            position_five[i].gameObject.SetActive(false);
    }

    private void OnRightKeyDown()
    {
        keyboards[current_index].UnSelect();

        current_index++;
        if(current_index >= keyboards.Length)
            current_index = 0;
        
        keyboards[current_index].Select();
    }

    private void OnLeftKeyDown()
    {
        keyboards[current_index].UnSelect();
        
        current_index--;
        if(current_index < 0)
            current_index = keyboards.Length - 1;
        
        keyboards[current_index].Select();
    }

    private void OnSubmitKeyDown()
    {
        if(notes_on_paper.Count >= 5)
            return;
        
        Image[] position = GetWhichPosition();

        switch(current_index)
        {
            case 0:
                notes_on_paper.Add("f");
                position[0].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(F);
                break;
            case 1:
                notes_on_paper.Add("g");
                position[1].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(G);
                break;
            case 2:
                notes_on_paper.Add("a");
                position[2].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(A);
                break;
            case 3:
                notes_on_paper.Add("b");
                position[3].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(B);
                break;
            case 4:
                notes_on_paper.Add("c");
                position[4].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(C);
                break;
            case 5:
                notes_on_paper.Add("d");
                position[5].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(D);
                break;
            case 6:
                notes_on_paper.Add("e");
                position[6].gameObject.SetActive(true);
                AudioManager.Instance.PlayOneShot(E);
                break;
        }

        // check anwser is correct or not
        if(notes_on_paper.Count == 5)
        {
            StartCoroutine(CheckAnwser(1f));    
        }
    }

    private void OnExitKeyDown()
    {
        input_reader.EnablePlayer();
        Player.Instance.Enable();
        UIManager.Instance.animator.Play("close_piano");
        Close();
    }

    private Image[] GetWhichPosition()
    {
        switch(notes_on_paper.Count)
        {
            case 0:
                return position_one;
            case 1:
                return position_two;
            case 2:
                return position_three;
            case 3:
                return position_four;
            case 4:
                return position_five;
            default:
                return null;
        }
    }

    private void AnwserCorrect()
    {
        AudioManager.Instance.PlayOneShot(Complete);
        UIManager.Instance.animator.Play("close_piano");
        SceneOneManager.Instance.to_boss_collider.isTrigger = true;
        Close();
        input_reader.EnablePlayer();
        Player.Instance.Enable();
        is_opened = true;
    }

    private void AnwserError()
    {
        if(notes_on_paper.Count == 0)
            return;
        notes_on_paper = new List<string>();

        for(int i=0; i<7; ++i) 
            position_one[i].gameObject.SetActive(false);
        for(int i=0; i<7; ++i) 
            position_two[i].gameObject.SetActive(false);
        for(int i=0; i<7; ++i) 
            position_three[i].gameObject.SetActive(false);
        for(int i=0; i<7; ++i) 
            position_four[i].gameObject.SetActive(false);
        for(int i=0; i<7; ++i)
            position_five[i].gameObject.SetActive(false);
    }

    private IEnumerator CheckAnwser(float t) 
    {
        yield return new WaitForSeconds(t);
        if(notes_on_paper.Count != 5)
            yield break;

        if(notes_on_paper[0] != "g")
        {
            AnwserError();
            yield break;
        }

        if(notes_on_paper[1] != "a")
        {
            AnwserError();
            yield break;
        }

        if(notes_on_paper[2] != "b")
        {
            AnwserError();
            yield break;
        }

        if(notes_on_paper[3] != "c")
        {
            AnwserError();
            yield break;
        }

        if(notes_on_paper[4] != "f")
        {
            AnwserError();
            yield break;
        }
        // anwser G A B C F
        AnwserCorrect();
    }
}
