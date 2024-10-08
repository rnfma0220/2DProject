using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map008_Event_1 : MonoBehaviour
{
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    [SerializeField] private GameObject StartMessages;
    [SerializeField] private GameObject NPC_1;
    [SerializeField] private GameObject NPC_2;
    [SerializeField] private GameObject NPC_3;
    private PlayerControll playerControll;
    private FadeController fadeController;
    private Chat_Event chat_event;
    private bool Event;
    private bool Event_2;
    private bool Chat_1;
    private bool Chat_2;
    private bool Chat_3;
    private bool Chat_4;
    private bool Chat_5;
    private bool Chat_6;
    private bool Chat_7;
    private bool Chat_8;
    private bool Chat_9;

    void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        chat_event = FindObjectOfType<Chat_Event>();
        fadeController = FindObjectOfType<FadeController>();

        if (DataManager.instance.GetSwitchValue("Dungeon"))
        {
            NPC_1.SetActive(false);
            NPC_2.SetActive(true);
            fadeController.FadeIn2();
            playerControll.NotMove = false;
            playerControll.Lavender = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Event = true;
    }

    private void Update()
    {
        if (Event)
        {
            if (DataManager.instance.GetSwitchValue("Dungeon") == false)
            {
                if (!Chat_1)
                {
                    StartMessages.SetActive(true);
                    Chat_1 = true;
                }
                else if (!Chat_2)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        StartMessages.SetActive(false);
                        fadeController.FadeIn2();
                        playerControll.Lavender = true;
                        TileChat.SetActive(true);
                        chat_event.Image_In(0);
                        chat_event.Chatname_Out(0);
                        ChatName.SetActive(true);
                        ChatMessages.SetActive(false);
                        chat_event.Messages_Out(0);
                        ChatMessages.SetActive(true);
                        Chat_2 = true;
                    }
                }
                else if (!Chat_3)
                {
                    playerControll.MoveEvent_1();
                    if(playerControll.transform.position.x == -1.7f)
                    {
                        playerControll.MoveEvent_2();
                        Chat_3 = true;
                    }
                }
                else if (!Event_2)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        if (!Chat_4)
                        {
                            chat_event.Image_Out(0);
                            chat_event.Image_In(1);
                            chat_event.Chatname_Out(1);
                            ChatMessages.SetActive(false);
                            chat_event.Messages_Out(1);
                            ChatMessages.SetActive(true);
                            Chat_4 = true;
                        }
                        else if (!Chat_5)
                        {
                            chat_event.Image_Out(1);
                            chat_event.Image_In(2);
                            chat_event.Chatname_Out(0);
                            ChatMessages.SetActive(false);
                            chat_event.Messages_Out(2);
                            ChatMessages.SetActive(true);
                            Chat_5 = true;
                        }
                        else if (!Chat_6)
                        {
                            chat_event.Image_Out(2);
                            chat_event.Image_In(1);
                            chat_event.Chatname_Out(1);
                            ChatMessages.SetActive(false);
                            chat_event.Messages_Out(3);
                            ChatMessages.SetActive(true);
                            Chat_6 = true;
                        }
                        else if (!Chat_7)
                        {
                            NPC_1.SetActive(false);
                            NPC_2.SetActive(true);
                            chat_event.Image_Out(1);
                            chat_event.Image_In(3);
                            chat_event.Chatname_Out(0);
                            ChatMessages.SetActive(false);
                            chat_event.Messages_Out(4);
                            ChatMessages.SetActive(true);
                            Chat_7 = true;
                        }
                        else if (!Chat_8)
                        {
                            NPC_3.SetActive(true);
                            chat_event.Image_Out(3);
                            chat_event.Image_In(1);
                            chat_event.Chatname_Out(1);
                            ChatMessages.SetActive(false);
                            chat_event.Messages_Out(5);
                            ChatMessages.SetActive(true);
                            playerControll.NotMove = true;
                            fadeController.FadeOut();
                            DataManager.instance.SetSwitchValue("Dungeon", true);
                            Chat_8 = true;
                            StartCoroutine(Move());
                        }
                        else if (!Chat_9)
                        {
                            StartCoroutine(Move());
                            Chat_9 = true;
                        }
                    }
                }
            }
        }
    }

    private IEnumerator Move()
    {
        AudioManager.instance.Stop("dungeon");
        AudioManager.instance.Play("battle");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Battle_tutorial");
        fadeController.FadeIn2();
    }
}
