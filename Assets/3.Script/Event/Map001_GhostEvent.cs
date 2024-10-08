using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map001_GhostEvent : MonoBehaviour
{
    [SerializeField] private GameObject EventGhost;
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private bool GhostEvent;
    private bool Chat_1;
    private bool Chat_2;

    private void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
        bool switchValue = DataManager.instance.GetSwitchValue("Ghost");

        if(switchValue)
        {
            EventGhost.SetActive(true);
        }
        else
        {
            EventGhost.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GhostEvent = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GhostEvent = false;
    }

    private void Update()
    {
        if(GhostEvent)
        {

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                bool switchValue = DataManager.instance.GetSwitchValue("Ghost");

                if (switchValue)
                {

                    if (Chat_2)
                    {
                        TileChat.SetActive(false);
                        chat_event.Image_Out(2);
                        ChatName.SetActive(false);
                        ChatMessages.SetActive(false);
                        playerControll.NotMove = false;
                        Chat_2 = false;
                        Chat_1 = false;
                    }
                    else if(!Chat_1)
                    {
                        TileChat.SetActive(true);
                        chat_event.Image_In(2);
                        chat_event.Chatname_Out(5);
                        ChatName.SetActive(true);
                        chat_event.Messages_Out(17);
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
