using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobeCheck : MonoBehaviour
{
    [SerializeField] private string MoveMap;
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    [SerializeField] private GameObject Ghost;
    [SerializeField] private GameObject Stat;
    private Animator animator;
    private PlayerControll playercontroll;
    private FadeController fadeController;
    private Chat_Event chat_event;
    private bool ChatOpen;
    private bool Chat_1;
    private bool Chat_2;
    private bool Chat_3;
    private bool Chat_4;
    private bool Chat_5;
    private bool Chat_6;
    private bool Chat_7;
    private bool Chat_8;
    private bool Chat_9;
    private bool Chat_10;
    private bool Chat_11;
    private bool Chat_12;
    private bool Chat_13;
    private bool Chat_14;
    private bool Chat_15;

    private void Start()
    {
        playercontroll = FindObjectOfType<PlayerControll>();
        fadeController = FindObjectOfType<FadeController>();
        chat_event = FindObjectOfType<Chat_Event>();
        TryGetComponent(out animator);
    }

    private void Update()
    {
        if (ChatOpen)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                TileChat.SetActive(false);
                chat_event.Image_Out(0);
                ChatName.SetActive(false);
                ChatMessages.SetActive(false);
                ChatOpen = false;
                playercontroll.NotMove = false;
            }
        }

        if (Chat_1)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (Chat_2)
                {
                    chat_event.Image_In(1);
                    chat_event.Chatname_Out(0);
                    chat_event.Messages_Out(3);
                    ChatMessages.SetActive(true);
                    Chat_2 = false;
                    Chat_3 = true;
                }
                else if (Chat_3)
                {
                    chat_event.Image_Out(1);
                    chat_event.Chatname_Out(4);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(4);
                    ChatMessages.SetActive(true);
                    Chat_3 = false;
                    Chat_4 = true;
                }
                else if (Chat_4)
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(5);
                    ChatMessages.SetActive(true);
                    Stat.SetActive(true);
                    TileChat.SetActive(false);
                    ChatName.SetActive(false);
                    ChatMessages.SetActive(false);
                    playercontroll.MoveEvent();
                    StartCoroutine(Ghost_Out());
                    Chat_4 = false;
                }
                else if (Chat_5)
                {
                    chat_event.Image_Out(2);
                    chat_event.Image_In(3);
                    chat_event.Chatname_Out(0);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(7);
                    ChatMessages.SetActive(true);
                    Chat_5 = false;
                    Chat_6 = true;
                }
                else if (Chat_6)
                {
                    chat_event.Image_Out(3);
                    chat_event.Image_In(2);
                    chat_event.Chatname_Out(5);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(8);
                    ChatMessages.SetActive(true);
                    Chat_6 = false;
                    Chat_7 = true;
                }
                else if(Chat_7)
                {
                    chat_event.Image_Out(2);
                    chat_event.Image_In(4);
                    chat_event.Chatname_Out(0);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(9);
                    ChatMessages.SetActive(true);
                    Chat_7 = false;
                    Chat_8 = true;
                }
                else if (Chat_8)
                {
                    chat_event.Image_Out(4);
                    chat_event.Image_In(2);
                    chat_event.Chatname_Out(5);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(10);
                    ChatMessages.SetActive(true);
                    Chat_8 = false;
                    Chat_9 = true;
                }
                else if (Chat_9)
                {
                    chat_event.Image_Out(2);
                    chat_event.Image_In(5);
                    chat_event.Chatname_Out(0);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(11);
                    ChatMessages.SetActive(true);
                    Chat_9 = false;
                    Chat_10 = true;
                }
                else if (Chat_10)
                {
                    chat_event.Image_Out(5);
                    chat_event.Image_In(2);
                    chat_event.Chatname_Out(5);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(12);
                    ChatMessages.SetActive(true);
                    Chat_10 = false;
                    Chat_11 = true;
                }
                else if (Chat_11)
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(13);
                    ChatMessages.SetActive(true);
                    Chat_11 = false;
                    Chat_12 = true;
                }
                else if (Chat_12)
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(14);
                    ChatMessages.SetActive(true);
                    AudioManager.instance.Play("Door_Open");
                    Chat_12 = false;
                    Chat_13 = true;
                }
                else if (Chat_13)
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(15);
                    ChatMessages.SetActive(true);
                    Chat_13 = false;
                    Chat_14 = true;
                }
                else if (Chat_14)
                {
                    chat_event.Image_Out(2);
                    chat_event.Image_In(6);
                    chat_event.Chatname_Out(0);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(16);
                    ChatMessages.SetActive(true);
                    Chat_14 = false;
                    Chat_15 = true;
                }
                else if (Chat_15)
                {
                    chat_event.Image_Out(6);
                    TileChat.SetActive(false);
                    ChatName.SetActive(false);
                    ChatMessages.SetActive(false);
                    playercontroll.NotMove = false;
                    DataManager.instance.SetSwitchValue("Ghost", true);
                    Chat_1 = false;
                    Chat_15 = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool switchValue = DataManager.instance.GetSwitchValue("Robe");

        if (!switchValue && playercontroll.DirY == 1)
        {
            if (playercontroll.DirY == 1)
            {
                TileChat.SetActive(true);
                chat_event.Image_In(0);
                chat_event.Chatname_Out(0);
                ChatName.SetActive(true);
                chat_event.Messages_Out(0);
                ChatMessages.SetActive(true);
                playercontroll.NotMove = true;
                ChatOpen = true;
            }
        }
        else
        {
            if(playercontroll.DirY == 1)
            {
                bool switchValue_ = DataManager.instance.GetSwitchValue("Ghost");

                if (switchValue_)
                {
                    playercontroll.NotMove = true;
                    PlayerManager.instance.MapName = MoveMap;
                    fadeController.FadeOut();
                    StartCoroutine(Door_animation());
                }
                else
                {
                    if (!Chat_1)
                    {
                        playercontroll.NotMove = true;
                        AudioManager.instance.Play("Door_Open");
                        TileChat.SetActive(true);
                        ChatName.SetActive(true);
                        chat_event.Chatname_Out(3);
                        Chat_1 = true;
                        Chat_2 = true;
                        AudioManager.instance.Play("Story_1");
                    }
                }
            }
        }

    }

    private IEnumerator Door_animation()
    {
        animator.SetBool("DoorOpen", true);
        AudioManager.instance.Play("Door_Open");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(MoveMap);
        fadeController.FadeIn2();
        playercontroll.NotMove = false;
    }

    private IEnumerator Ghost_Out()
    {
        yield return new WaitForSeconds(2f);
        Stat.SetActive(false);
        Ghost.SetActive(true);
        chat_event.Image_In(2);
        TileChat.SetActive(true);
        chat_event.Chatname_Out(5);
        ChatName.SetActive(true);
        chat_event.Messages_Out(6);
        ChatMessages.SetActive(true);
        Chat_5 = true;
        yield break;
    }
}
