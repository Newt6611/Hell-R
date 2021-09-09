using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    CD = 0
}

public class PickItem : MonoBehaviour
{
    public InputReader input_reader;
    public ItemType type;
    private Sprite sprite;

    private void Start() 
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.player_pick_item += GetItem;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.player_pick_item -= GetItem;
        }
    }

    public void GetItem()
    {
        bool isFull = false;
        switch(type)
        {
            case ItemType.CD:
                isFull = BackPack.Instance.SetSprite(sprite);
                break;
        }

        if(!isFull)
            Destroy(gameObject);
    }
}
