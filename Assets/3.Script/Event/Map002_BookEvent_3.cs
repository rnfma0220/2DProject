using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map002_BookEvent_3 : MonoBehaviour
{
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatMessages;
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject[] Select;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private int Index = 0;
    private bool Book;
    private bool Chat_1;
    private bool Chat_2;
    private bool Chat_3;

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
            if (Chat_3)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(3);
                    ChatMessages.SetActive(true);
                    playerControll.NotMove = false;
                    Chat_1 = false;
                    Chat_2 = false;
                    Chat_3 = false;
                    return;
                }
            }

            if (Chat_2)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (Index == 0)
                    {
                        Select[Index].SetActive(false);
                        Index = 1;
                        Select[Index].SetActive(true);
                    }
                    else
                    {
                        Select[Index].SetActive(false);
                        Index = 0;
                        Select[Index].SetActive(true);
                    }
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (Index == 0)
                    {
                        Select[Index].SetActive(false);
                        Index = 1;
                        Select[Index].SetActive(true);
                    }
                    else
                    {
                        Select[Index].SetActive(false);
                        Index = 0;
                        Select[Index].SetActive(true);
                    }
                }

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    switch(Index)
                    {
                        case 0:
                            ChatMessages.SetActive(false);
                            chat_event.Messages_Out(4);
                            ChatMessages.SetActive(true);
                            Text.SetActive(false);
                            Select[0].SetActive(false);
                            Index = 2;
                            Chat_2 = false;
                            Chat_3 = true;
                            break;
                        case 1:
                            TileChat.SetActive(false);
                            Text.SetActive(false);
                            ChatMessages.SetActive(false);
                            Select[Index].SetActive(false);
                            playerControll.NotMove = false;
                            Chat_2 = false;
                            Chat_1 = false;
                            return;
                    }
                }

            }

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!Chat_1)
                {
                    playerControll.NotMove = true;
                    TileChat.SetActive(true);
                    chat_event.Messages_Out(1);
                    ChatMessages.SetActive(true);
                    Text.SetActive(true);
                    Index = 0;
                    Select[Index].SetActive(true);
                    Chat_2 = true;
                    Chat_1 = true;
                }
            }
        }
    }

}
