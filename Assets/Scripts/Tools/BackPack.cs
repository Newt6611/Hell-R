using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    private static BackPack m_instance;
    public static BackPack Instance { get { return m_instance; } }

    public int bar_index = 0;
    public BackPackItem[] items;

    public InputReader input_reader;

    private void Awake()
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;
    }

    private void OnEnable() 
    {
        input_reader.itemOneEvent += OnItemOneSelected;
        input_reader.itemTwoEvent += OnItemTwoSelected;
        input_reader.itemThreeEvent += OnItemThreeSelected;
        input_reader.itemFourEvent += OnItemFourSelected;
        input_reader.itemFiveEvent += OnItemFiveSelected;
        input_reader.useItemEvent += UseItem;
    }

    private void Start()
    {
        items[bar_index].Select();
    }

    public void UseItem() 
    {
        items[bar_index].Use();
    }

    public bool SetSprite(Sprite sprite)
    {
        bool isFull = false;
        for(int i=0; i<items.Length; i++)
        {
            if(items[i].IsEmpty())
            {
                items[i].SetSprite(sprite);
                break;
            }
            if(i == items.Length - 1)
                isFull = true;
        }
        return isFull;
    }

    public void OnItemOneSelected()
    {
        items[bar_index].UnSelect();
        bar_index = 0;
        items[bar_index].Select();
    }

    public void OnItemTwoSelected()
    {
        items[bar_index].UnSelect();
        bar_index = 1;
        items[bar_index].Select();
    }

    public void OnItemThreeSelected()
    {
        items[bar_index].UnSelect();
        bar_index = 2;
        items[bar_index].Select();
    }

    public void OnItemFourSelected()
    {
        items[bar_index].UnSelect();
        bar_index = 3;
        items[bar_index].Select();
    }

    public void OnItemFiveSelected()
    {
        items[bar_index].UnSelect();
        bar_index = 4;
        items[bar_index].Select();
    }
}
