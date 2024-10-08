using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map003_NpcEvent_2 : MonoBehaviour
{
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private bool NPC;
    private bool Chat_1;
    private bool Chat_2;

    void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NPC = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NPC = false;
    }


    void Update()
    {
        if (NPC)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!Chat_1)
                {
                    playerControll.NotMove = true;
                    chat_event.Image_In(0);
                    TileChat.SetActive(true);
                    chat_event.Chatname_Out(0);
                    ChatName.SetActive(true);
                    chat_event.Messages_Out(2);
                    ChatMessages.SetActive(true);
                    Chat_1 = true;
                    Chat_2 = true;
                }
                else if (Chat_2)
                {
                    chat_event.Image_Out(0);
                    TileChat.SetActive(false);
                    ChatMessages.SetActive(false);
                    ChatName.SetActive(false);
                    playerControll.NotMove = false;
                    Chat_1 = false;
                    Chat_2 = false;
                    return;
                }
            }
        }
    }
}
