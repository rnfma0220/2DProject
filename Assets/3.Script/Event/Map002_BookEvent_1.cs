using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map002_BookEvent_1 : MonoBehaviour
{
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatMessages;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private bool Book;
    private bool Chat_1;
    private bool Chat_2;

    private void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Book = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Book = false;
    }

    private void Update()
    {
        if (Book)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (Chat_2)
                {
                    TileChat.SetActive(false);
                    ChatMessages.SetActive(false);
                    playerControll.NotMove = false;
                    Chat_2 = false;
                }
                else if (!Chat_1)
                {
                    playerControll.NotMove = true;
                    TileChat.SetActive(true);
                    chat_event.Messages_Out(0);
                    ChatMessages.SetActive(true);
                    Chat_2 = true;
                }
            }
        }
    }
}
