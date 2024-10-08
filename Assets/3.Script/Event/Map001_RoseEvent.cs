using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map001_RoseEvent : MonoBehaviour
{
    [SerializeField] private GameObject EventRobeTile;
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private bool RobeEvent;
    private bool Chat_1;
    private bool Chat_2;
    private bool Chat_3;

    private void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
        bool switchValue = DataManager.instance.GetSwitchValue("Robe");
        bool switchValue_1 = DataManager.instance.GetSwitchValue("Ghost");

        if (!switchValue)
        {
            EventRobeTile.SetActive(true);
        }
        else
        {
            EventRobeTile.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobeEvent = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RobeEvent = false;
    }

    private void Update()
    {
        if(RobeEvent)
        {

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                bool switchValue = DataManager.instance.GetSwitchValue("Robe");

                if (!switchValue)
                {
                    if(Chat_3)
                    {
                        TileChat.SetActive(false);
                        ChatName.SetActive(false);
                        ChatMessages.SetActive(false);
                        EventRobeTile.SetActive(false);
                        DataManager.instance.SetSwitchValue("Robe", true);
                        playerControll.NotMove = false;
                        Chat_3 = false;
                    }

                    if (Chat_2)
                    {
                        playerControll.Reaper = true;
                        chat_event.Chatname_Out(2);
                        ChatMessages.SetActive(false);
                        DataManager.instance.AddItem(1, 8);
                        DataManager.instance.AddItem(2, 5);
                        chat_event.Messages_Out(2);
                        ChatMessages.SetActive(true);
                        Chat_2 = false;
                        Chat_3 = true;
                    }

                    if(!Chat_1)
                    {
                        TileChat.SetActive(true);
                        chat_event.Chatname_Out(1);
                        ChatName.SetActive(true);
                        chat_event.Messages_Out(1);
                        ChatMessages.SetActive(true);
                        playerControll.NotMove = true;
                        Chat_1 = true;
                        Chat_2 = true;
                    }
                }
            }
        }
    }
}
