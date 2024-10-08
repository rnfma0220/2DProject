using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map005_NpcEvent_1 : MonoBehaviour
{
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private bool NPC;
    private bool Chat_1;
    private bool Chat_2;
    private bool Chat_3;
    private bool Chat_4;
    private bool Chat_5;
    private bool Chat_6;
    private bool Chat_7;
    private bool Chat_8;

    void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
        bool switchValue = DataManager.instance.GetSwitchValue("NPC_1");
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
            bool switchValue = DataManager.instance.GetSwitchValue("NPC_1");

            if (switchValue)
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
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(3);
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
            else
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (Chat_8)
                    {
                        DataManager.instance.SetSwitchValue("NPC_1", true);
                        chat_event.Image_Out(0);
                        TileChat.SetActive(false);
                        ChatMessages.SetActive(false);
                        ChatName.SetActive(false);
                        playerControll.NotMove = false;
                        return;
                    }
                    else if (Chat_7)
                    {
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(8);
                        ChatMessages.SetActive(true);
                        Chat_8 = true;
                    }
                    else if (Chat_6)
                    {
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(7);
                        ChatMessages.SetActive(true);
                        Chat_7 = true;
                    }
                    else if (Chat_5)
                    {
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(6);
                        ChatMessages.SetActive(true);
                        Chat_6 = true;
                    }
                    else if (Chat_4)
                    {
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(5);
                        ChatMessages.SetActive(true);
                        Chat_5 = true;
                    }
                    else if (!Chat_3)
                    {
                        playerControll.NotMove = true;
                        chat_event.Image_In(0);
                        TileChat.SetActive(true);
                        chat_event.Chatname_Out(0);
                        ChatName.SetActive(true);
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(4);
                        ChatMessages.SetActive(true);
                        Chat_3 = true;
                        Chat_4 = true;
                    }
                }
            }
        }
    }
}
