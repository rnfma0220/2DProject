using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle_tutorial : MonoBehaviour
{
    [SerializeField] private Slider TimeBar;
    [SerializeField] private GameObject TileChat;
    [SerializeField] private GameObject ChatName;
    [SerializeField] private GameObject ChatMessages;
    [SerializeField] private GameObject SkillTile;
    [SerializeField] private GameObject Select_1;
    [SerializeField] private GameObject Text_1;
    [SerializeField] private GameObject Select_2;
    [SerializeField] private GameObject Text_2;
    [SerializeField] private GameObject Bar;
    [SerializeField] private GameObject UpDown;
    [SerializeField] private GameObject strike;
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Skill_1;
    [SerializeField] private Text Skill_1_Text;
    [SerializeField] private GameObject Skill_2;
    [SerializeField] private GameObject Ghastiling;
    [SerializeField] private GameObject Mob_Skill;
    [SerializeField] private GameObject Skill;
    [SerializeField] private GameObject DodgeS;
    [SerializeField] private GameObject DodgeN;
    [SerializeField] private GameObject Battle_End;
    [SerializeField] private GameObject[] UpDown_2;
    [SerializeField] private GameObject[] Skillselect;
    private PlayerControll playerControll;
    private FadeController fadeController;
    private TileManger tileManger;
    private Animator animator;
    private Battle_Ghastling ghastling;
    private Battle_Search _Search;
    private Color originalColor;
    private int Index = 0;
    private int SkillIndex = 0;
    private Chat_Event chat_event;
    public bool attack_Miss;
    public bool attack_Dam_4_1;
    public bool attack_Dam_2_1;
    public bool attack_Dam_15;
    public bool attack_Dam_2;
    public bool Dodge;
    private bool attack;
    private bool isSword;
    private bool SKill_select;
    private bool SKill_Search;
    private bool SKill_text;
    private bool Searching;
    private bool attack_select;
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
    public bool Chat_12;
    private bool Chat_13;
    private bool Chat_14;
    private bool Chat_15;
    private bool Chat_16;

    private void Start()
    {
        chat_event = FindObjectOfType<Chat_Event>();
        playerControll = FindObjectOfType<PlayerControll>();
        fadeController = FindObjectOfType<FadeController>();
        tileManger = FindObjectOfType<TileManger>();
        ghastling = FindObjectOfType<Battle_Ghastling>();
        _Search = FindObjectOfType<Battle_Search>();
        TryGetComponent(out animator);
        originalColor = Skill_1_Text.color;
    }

    private void Update()
    {
        if(ghastling.Mob_Die) // 몹사망 배틀종료
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!Chat_13)
                {
                    Battle_End.SetActive(true);
                    PlayerManager.instance.Soul += 2;
                    Chat_13 = true;
                }
                else if (!Chat_14)
                {
                    Battle_End.SetActive(false);
                    TileChat.SetActive(true);
                    chat_event.Chatname_Out(0);
                    ChatName.SetActive(true);
                    chat_event.Messages_Out(7);
                    ChatMessages.SetActive(true);
                    Chat_14 = true;
                }
                else if (!Chat_15)
                {
                    chat_event.Chatname_Out(1);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(8);
                    ChatMessages.SetActive(true);
                    Chat_15 = true;
                }
                else if (!Chat_16)
                {
                    ChatName.SetActive(false);
                    TileChat.SetActive(false);
                    ChatMessages.SetActive(false);
                    playerControll.NotMove = false;
                    fadeController.FadeOut();
                    tileManger.Ability = false;
                    StartCoroutine(Move());
                }
            }
        }
        else if (Chat_12)
        {
            if (Dodge)
            {
                DodgeS.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Chat_12 = false;
                    DodgeS.SetActive(false);
                }
            }
            else
            {
                StartCoroutine(Mob_Attack());
                Chat_12 = false;
            }
        }
        else if (Chat_9)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!Chat_10)
                {
                    TileChat.SetActive(true);
                    chat_event.Chatname_Out(0);
                    ChatName.SetActive(true);
                    chat_event.Messages_Out(5);
                    ChatMessages.SetActive(true);
                    Chat_10 = true;
                }
                else if (!Chat_11)
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(6);
                    ChatMessages.SetActive(true);
                    Chat_11 = true;
                }
                else if (!SKill_text)
                {
                    ChatMessages.SetActive(false);
                    TileChat.SetActive(false);
                    ChatName.SetActive(false);
                    Mob_Skill.SetActive(true);
                    SKill_text = true;
                    Chat_9 = false;
                }
            }
        }
        else if(SKill_Search)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!Searching)
                {
                    ChatName.SetActive(false);
                    ChatMessages.SetActive(false);
                    _Search.Search();
                    Ghastiling.SetActive(true);
                    Searching = true;
                }
                else
                {
                    Ghastiling.SetActive(false);
                    TileChat.SetActive(false);
                    SKill_Search = false;
                    animator.SetBool("Search", false);
                    TimeBar.value = 0;
                    attack = false;
                    Chat_8 = false;
                }
            }
        }
        else if(SKill_select)
        {
            if(PlayerManager.instance.MP >= 6)
            {
                Skill_1_Text.color = Color.white;
            }
            else
            {
                Skill_1_Text.color = originalColor;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (SkillIndex == 0)
                {
                    Skillselect[SkillIndex].SetActive(false);
                    SkillIndex += 1;
                    Skillselect[SkillIndex].SetActive(true);
                    Skill_1.SetActive(false);
                    Skill_2.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (SkillIndex == 1)
                {
                    Skillselect[SkillIndex].SetActive(false);
                    SkillIndex -= 1;
                    Skillselect[SkillIndex].SetActive(true);
                    Skill_1.SetActive(true);
                    Skill_2.SetActive(false);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch(SkillIndex)
                {
                    case 0: // 관통
                        if (PlayerManager.instance.MP >= 6)
                        {
                            Index = 0;
                            SkillIndex = 0;
                            SkillTile.SetActive(false);
                            Skillselect[0].SetActive(false);
                            Skillselect[1].SetActive(false);
                            Skill_1.SetActive(false);
                            Skill_2.SetActive(false);
                            attack_select = false;
                            SKill_select = false;
                            StartCoroutine(Skill_co());
                        }
                        break;
                    case 1: // 관측
                        TileChat.SetActive(true);
                        chat_event.Chatname_Out(2);
                        ChatName.SetActive(true);
                        chat_event.Messages_Out(4);
                        ChatMessages.SetActive(true);
                        SKill_Search = true;
                        SKill_select = false;
                        Index = 0;
                        SkillIndex = 0;
                        SkillTile.SetActive(false);
                        Skillselect[0].SetActive(false);
                        Skillselect[1].SetActive(false);
                        Skill_1.SetActive(false);
                        Skill_2.SetActive(false);
                        attack_select = false;
                        animator.SetBool("Search", true);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Text_2.SetActive(true); 
                Select_2.SetActive(true);
                Index = 0;
                SkillIndex = 0;
                UpDown_2[0].SetActive(true);
                SkillTile.SetActive(false);
                Skillselect[0].SetActive(false);
                Skillselect[1].SetActive(false);
                Skill_1.SetActive(false);
                Skill_2.SetActive(false);
                attack_select = true;
                SKill_select = false;
                Chat_8 = false;
            }

        }
        else if (attack)
        {
            if (!isSword)
            {
                if (Sword.transform.position.x >= 2)
                {
                    isSword = true;
                    attack = false;
                    Sword.SetActive(false);
                    strike.SetActive(false);
                    StartCoroutine(Miss_co());
                }
                else
                {
                    Sword.transform.Translate(Vector3.right * 4.0f * Time.deltaTime);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (attack_Miss) 
                {
                    StartCoroutine(Miss_co());
                }
                else if (attack_Dam_4_1) 
                {
                    StartCoroutine(Dam_4_1_co());
                }
                else if (attack_Dam_2_1) 
                {
                    StartCoroutine(Dam_2_1_co());
                }
                else if (attack_Dam_15)
                {
                    StartCoroutine(Dam_15_co());
                }
                else if (attack_Dam_2) 
                {
                    StartCoroutine(Dam_2_co());
                }
                isSword = true;
                attack = false;
                Sword.SetActive(false);
                strike.SetActive(false);
            }
        }
        else if (!Chat_6)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!Chat_1)
                {
                    TileChat.SetActive(true);
                    chat_event.Image_In(0);
                    chat_event.Chatname_Out(0);
                    ChatName.SetActive(true);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(0);
                    ChatMessages.SetActive(true);
                    tileManger.Ability = true;
                    Chat_1 = true;
                }
                else if (!Chat_2)
                {
                    chat_event.Image_Out(0);
                    chat_event.Image_In(1);
                    chat_event.Chatname_Out(1);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(1);
                    ChatMessages.SetActive(true);
                    Chat_2 = true;
                }
                else if (!Chat_3)
                {
                    chat_event.Image_Out(1);
                    chat_event.Image_In(0);
                    chat_event.Chatname_Out(0);
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(2);
                    ChatMessages.SetActive(true);
                    Chat_3 = true;
                }
                else if (!Chat_4)
                {
                    ChatMessages.SetActive(false);
                    chat_event.Messages_Out(3);
                    ChatMessages.SetActive(true);
                    Chat_4 = true;
                }
                else if (!Chat_5)
                {
                    chat_event.Image_Out(0);
                    TileChat.SetActive(false);
                    ChatName.SetActive(false);
                    ChatMessages.SetActive(false);
                    Text_1.SetActive(true);
                    Select_1.SetActive(true);
                    Bar.SetActive(true);
                    UpDown.SetActive(true);
                    Chat_5 = true;
                    Chat_6 = true;
                }
            }
        }
        else if (!Chat_7)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (UpDown.transform.position == new Vector3(-5.1f, -3.4f, 0))
                {
                    UpDown.transform.position = new Vector3(-5.1f, -4.18f, 0);
                }
                else
                {
                    UpDown.transform.position = new Vector3(-5.1f, -3.4f, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (UpDown.transform.position == new Vector3(-5.1f, -4.18f, 0))
                {
                    UpDown.transform.position = new Vector3(-5.1f, -3.4f, 0);
                }
                else
                {
                    UpDown.transform.position = new Vector3(-5.1f, -4.18f, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (UpDown.transform.position == new Vector3(-5.1f, -3.4f, 0))
                {
                    UpDown.SetActive(false);
                    Text_1.SetActive(false);
                    Select_1.SetActive(false);
                    Bar.transform.position = new Vector3(-5.8f, -3.9f, 0);
                    Chat_7 = true;
                }
            }
        }
        else if(!Chat_8)
        {
            if (TimeBar.value >= TimeBar.maxValue)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (!attack_select)
                    {
                        Text_2.SetActive(true);
                        Select_2.SetActive(true);
                        UpDown_2[0].SetActive(true);
                        attack_select = true;
                    }
                    else 
                    {
                        switch (Index)
                        {
                            case 0:
                                Text_2.SetActive(false);
                                Select_2.SetActive(false);
                                UpDown_2[0].SetActive(false);
                                strike.SetActive(true);
                                Sword.SetActive(true);
                                attack = true;
                                attack_select = false;
                                break;
                            case 1:
                                Text_2.SetActive(false);
                                Select_2.SetActive(false);
                                UpDown_2[1].SetActive(false);
                                SkillTile.SetActive(true);
                                Skillselect[0].SetActive(true);
                                Skill_1.SetActive(true);
                                attack_select = false;
                                SKill_select = true;
                                Chat_8 = true;
                                break;
                            case 2:
                                Debug.Log("주머니");
                                break;
                            case 3:
                                Debug.Log("도망(비활성화)");
                                break;
                        }
                    }
                }
                if (attack_select)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (Index != 0)
                        {
                            UpDown_2[Index].SetActive(false);
                            Index -= 1;
                            UpDown_2[Index].SetActive(true);
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (Index != 3)
                        {
                            UpDown_2[Index].SetActive(false);
                            Index += 1;
                            UpDown_2[Index].SetActive(true);
                        }
                    }
                }
            }
        }

    }

    private IEnumerator Skill_co()
    {
        animator.SetBool("Attack", true);
        ghastling.TakeDamage(PlayerManager.instance.Damage);
        AudioManager.instance.Play("Skill");
        Skill.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Skill.SetActive(false);
        animator.SetBool("Attack", false);
        TimeBar.value = 0;
        Chat_8 = false;
        PlayerManager.instance.MP -= 6;
        if (ghastling.Mob_HP <= 50 && Chat_10 == false) Chat_9 = true;
        yield break;
    }

    private IEnumerator Miss_co()
    {
        animator.SetBool("Attack", true);
        ghastling.TakeDamage(0);
        AudioManager.instance.Play("Attack");
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        TimeBar.value = 0;
        isSword = false;
        Sword.transform.position = new Vector3(-1.73f, -0.69f, 0f);
        PlayerManager.instance.MP += 3;
        yield break;
    }
    private IEnumerator Dam_4_1_co()
    {
        animator.SetBool("Attack", true);
        ghastling.TakeDamage(PlayerManager.instance.Damage * 0.25f);
        AudioManager.instance.Play("Attack");
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        TimeBar.value = 0;
        isSword = false;
        Sword.transform.position = new Vector3(-1.73f, -0.69f, 0f);
        PlayerManager.instance.MP += 5;
        if (ghastling.Mob_HP <= 50 && Chat_10 == false) Chat_9 = true;
        yield break;
    }
    private IEnumerator Dam_2_1_co()
    {
        animator.SetBool("Attack", true);
        ghastling.TakeDamage(PlayerManager.instance.Damage * 0.5f);
        AudioManager.instance.Play("Attack");
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        TimeBar.value = 0;
        isSword = false;
        Sword.transform.position = new Vector3(-1.73f, -0.69f, 0f);
        PlayerManager.instance.MP += 9;
        if (ghastling.Mob_HP <= 50 && Chat_10 == false) Chat_9 = true;
        yield break;
    }
    private IEnumerator Dam_15_co()
    {
        animator.SetBool("Attack", true);
        ghastling.TakeDamage(PlayerManager.instance.Damage * 1.5f);
        AudioManager.instance.Play("Attack");
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        TimeBar.value = 0;
        isSword = false;
        Sword.transform.position = new Vector3(-1.73f, -0.69f, 0f);
        PlayerManager.instance.MP += 9;
        if (ghastling.Mob_HP <= 50 && Chat_10 == false) Chat_9 = true;
        yield break;
    }
    private IEnumerator Dam_2_co()
    {
        animator.SetBool("Attack", true);
        ghastling.TakeDamage(PlayerManager.instance.Damage * 2.0f);
        AudioManager.instance.Play("Attack");
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        TimeBar.value = 0;
        isSword = false;
        Sword.transform.position = new Vector3(-1.73f, -0.69f, 0f);
        PlayerManager.instance.MP += 15;
        if (ghastling.Mob_HP <= 50 && Chat_10 == false) Chat_9 = true;
        yield break;
    }

    private IEnumerator Mob_Attack()
    {
        DodgeN.SetActive(true);
        AudioManager.instance.Play("MobSkill_1");
        yield return new WaitForSeconds(0.9f);
        DodgeN.SetActive(false);
        PlayerManager.instance.HP -= ghastling.Damage * 2f;
        yield break;
    }

    private IEnumerator Move()
    {
        AudioManager.instance.Stop("battle");
        AudioManager.instance.Play("dungeon");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map008");
        fadeController.FadeIn2();
    }
}