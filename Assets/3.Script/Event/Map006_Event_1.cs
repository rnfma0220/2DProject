using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map006_Event_1 : MonoBehaviour
{
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    private PlayerControll playerControll;
    private Chat_Event chat_event;
    private bool Event;

    void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerControll.NotMove = true;
        chat_event.Image_In(0);
        TileChat.SetActive(true);
        chat_event.Chatname_Out(0);
        ChatName.SetActive(true);
        ChatMessages.SetActive(false);
        chat_event.Messages_Out(0);
        ChatMessages.SetActive(true);
        Event = true;
    }

    void Update()
    {
        if (Event)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                chat_event.Image_Out(0);
                TileChat.SetActive(false);
                ChatMessages.SetActive(false);
                ChatName.SetActive(false);
                playerControll.NotMove = false;
                Event = false;
            }
        }
    }
}
