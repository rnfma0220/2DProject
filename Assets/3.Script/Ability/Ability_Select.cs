using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ability_Select : MonoBehaviour
{
    [SerializeField] private GameObject[] select;
    [SerializeField] private GameObject Tile;
    [SerializeField] private GameObject Success;
    [SerializeField] private GameObject Fall;
    [SerializeField] private GameObject Back;
    [SerializeField] private GameObject[] HP;
    [SerializeField] private GameObject[] Skill;
    [SerializeField] private GameObject[] Damage;
    [SerializeField] private GameObject[] DEF;
    [SerializeField] private GameObject[] Speed;
    [SerializeField] private GameObject[] HP_icon;
    [SerializeField] private GameObject[] Speed_icon;
    [SerializeField] private GameObject[] Attack_icon;
    [SerializeField] private GameObject[] DEF_icon;
    [SerializeField] private GameObject[] Skill_icon;
    private TileManger tilemanger;
    private PlayerControll playerControll;
    private FadeController fadeController;
    private Ability_Out ability;
    private string Map;
    private int Index;
    private bool Select;
    private bool Upgrade;
    private bool Upgrade_Select;
    private bool HP_Select_1;
    private bool HP_Select_2;
    private bool HP_Select_3;
    private bool HP_Select_Fall;
    private bool Skill_Select_1;
    private bool Skill_Select_2;
    private bool Skill_Select_3;
    private bool Skill_Select_Fall;
    private bool Damage_Select_1;
    private bool Damage_Select_2;
    private bool Damage_Select_3;
    private bool Damage_Select_Fall;
    private bool DEF_Select_1;
    private bool DEF_Select_2;
    private bool DEF_Select_3;
    private bool DEF_Select_Fall;
    private bool Speed_Select_1;
    private bool Speed_Select_2;
    private bool Speed_Select_3;
    private bool Speed_Select_Fall;

    private void Start()
    {
        tilemanger = FindObjectOfType<TileManger>();
        playerControll = FindObjectOfType<PlayerControll>();
        fadeController = FindObjectOfType<FadeController>();
        TryGetComponent(out ability);

        if (PlayerManager.instance.GetSwitchValue("HP_1"))
        {
            HP_icon[0].SetActive(false);
            HP_icon[1].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("HP_2"))
        {
            HP_icon[0].SetActive(false);
            HP_icon[1].SetActive(false);
            HP_icon[2].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("HP_3"))
        {
            HP_icon[0].SetActive(false);
            HP_icon[1].SetActive(false);
            HP_icon[2].SetActive(false);
            HP_icon[3].SetActive(true);
        }

        if (PlayerManager.instance.GetSwitchValue("Speed_1"))
        {
            Speed_icon[0].SetActive(false);
            Speed_icon[1].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("Speed_2"))
        {
            Speed_icon[0].SetActive(false);
            Speed_icon[1].SetActive(false);
            Speed_icon[2].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("Speed_3"))
        {
            Speed_icon[0].SetActive(false);
            Speed_icon[1].SetActive(false);
            Speed_icon[2].SetActive(false);
            Speed_icon[3].SetActive(true);
        }

        if (PlayerManager.instance.GetSwitchValue("Attack_1"))
        {
            Attack_icon[0].SetActive(false);
            Attack_icon[1].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("Attack_2"))
        {
            Attack_icon[0].SetActive(false);
            Attack_icon[1].SetActive(false);
            Attack_icon[2].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("Attack_3"))
        {
            Attack_icon[0].SetActive(false);
            Attack_icon[1].SetActive(false);
            Attack_icon[2].SetActive(false);
            Attack_icon[3].SetActive(true);
        }

        if (PlayerManager.instance.GetSwitchValue("DEF_1"))
        {
            DEF_icon[0].SetActive(false);
            DEF_icon[1].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("DEF_2"))
        {
            DEF_icon[0].SetActive(false);
            DEF_icon[1].SetActive(false);
            DEF_icon[2].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("DEF_3"))
        {
            DEF_icon[0].SetActive(false);
            DEF_icon[1].SetActive(false);
            DEF_icon[2].SetActive(false);
            DEF_icon[3].SetActive(true);
        }

        if (PlayerManager.instance.GetSwitchValue("Skill_1"))
        {
            Skill_icon[0].SetActive(false);
            Skill_icon[1].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("Skill_2"))
        {
            Skill_icon[0].SetActive(false);
            Skill_icon[1].SetActive(false);
            Skill_icon[2].SetActive(true);
        }
        else if (PlayerManager.instance.GetSwitchValue("Skill_3"))
        {
            Skill_icon[0].SetActive(false);
            Skill_icon[1].SetActive(false);
            Skill_icon[2].SetActive(false);
            Skill_icon[3].SetActive(true);
        }
    }

    void Update()
    {
        if(Upgrade_Select)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Index == 1)
                {
                    select[Index].SetActive(false);
                    Index = 0;
                    select[Index].SetActive(true);
                }
                else
                {
                    select[Index].SetActive(false);
                    Index = 1;
                    select[Index].SetActive(true);
                }
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (Index == 0)
                {
                    select[Index].SetActive(false);
                    Index = 1;
                    select[Index].SetActive(true);
                }
                else
                {
                    select[Index].SetActive(false);
                    Index = 0;
                    select[Index].SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (Index)
                {
                    case 0: // °­È­
                        if(HP_Select_1)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 20;
                            PlayerManager.instance.Max_HP += 40;
                            PlayerManager.instance.HP += 40;
                            PlayerManager.instance.SetSwitchValue("HP_1", true);
                            HP_icon[0].SetActive(false);
                            HP_icon[1].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            HP[0].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            HP_Select_1 = false;
                        }
                        else if (HP_Select_2)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 50;
                            PlayerManager.instance.Max_HP += 150;
                            PlayerManager.instance.HP += 150;
                            PlayerManager.instance.SetSwitchValue("HP_2", true);
                            HP_icon[1].SetActive(false);
                            HP_icon[2].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            HP[1].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            HP_Select_2 = false;
                        }
                        else if (HP_Select_3)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 100;
                            PlayerManager.instance.Max_HP += 250;
                            PlayerManager.instance.HP += 250;
                            PlayerManager.instance.SetSwitchValue("HP_3", true);
                            HP_icon[2].SetActive(false);
                            HP_icon[3].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            HP[2].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            HP_Select_3 = false;
                        }
                        else if(Damage_Select_1)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 2;
                            PlayerManager.instance.Damage += 2;
                            PlayerManager.instance.SetSwitchValue("Damage_1", true);
                            Attack_icon[0].SetActive(false);
                            Attack_icon[1].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Damage[0].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Damage_Select_1 = false;
                        }
                        else if (Damage_Select_2)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 5;
                            PlayerManager.instance.Damage += 4;
                            PlayerManager.instance.SetSwitchValue("Damage_2", true);
                            Attack_icon[1].SetActive(false);
                            Attack_icon[2].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Damage[1].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Damage_Select_2 = false;
                        }
                        else if (Damage_Select_3)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 10;
                            PlayerManager.instance.Damage += 4;
                            PlayerManager.instance.SetSwitchValue("Damage_3", true);
                            Attack_icon[2].SetActive(false);
                            Attack_icon[3].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Damage[2].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Damage_Select_3 = false;
                        }
                        else if(Speed_Select_1)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 2;
                            PlayerManager.instance.Speed += 2;
                            PlayerManager.instance.SetSwitchValue("Speed_1", true);
                            Speed_icon[0].SetActive(false);
                            Speed_icon[1].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Speed[0].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Speed_Select_1 = false;
                        }
                        else if (Speed_Select_2)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 5;
                            PlayerManager.instance.Speed += 4;
                            PlayerManager.instance.SetSwitchValue("Speed_2", true);
                            Speed_icon[1].SetActive(false);
                            Speed_icon[2].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Speed[1].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Speed_Select_2 = false;
                        }
                        else if (Speed_Select_3)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 10;
                            PlayerManager.instance.Speed += 4;
                            PlayerManager.instance.SetSwitchValue("Speed_3", true);
                            Speed_icon[2].SetActive(false);
                            Speed_icon[3].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Speed[2].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Speed_Select_3 = false;
                        }
                        else if(DEF_Select_1)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 1;
                            PlayerManager.instance.DEF += 1;
                            PlayerManager.instance.SetSwitchValue("DEF_1", true);
                            DEF_icon[0].SetActive(false);
                            DEF_icon[1].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            DEF[0].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            DEF_Select_1 = false;
                        }
                        else if (DEF_Select_2)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 3;
                            PlayerManager.instance.DEF += 2;
                            PlayerManager.instance.SetSwitchValue("DEF_2", true);
                            DEF_icon[1].SetActive(false);
                            DEF_icon[2].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            DEF[1].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            DEF_Select_2 = false;
                        }
                        else if (DEF_Select_3)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 5;
                            PlayerManager.instance.DEF += 2;
                            PlayerManager.instance.SetSwitchValue("DEF_3", true);
                            DEF_icon[2].SetActive(false);
                            DEF_icon[3].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            DEF[2].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            DEF_Select_3 = false;
                        }
                        else if(Skill_Select_1)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 2;
                            PlayerManager.instance.Skill += 2;
                            PlayerManager.instance.SetSwitchValue("Skill_1", true);
                            Skill_icon[0].SetActive(false);
                            Skill_icon[1].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Skill[0].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Skill_Select_1 = false;
                        }
                        else if (Skill_Select_2)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 5;
                            PlayerManager.instance.Skill += 3;
                            PlayerManager.instance.SetSwitchValue("Skill_2", true);
                            Skill_icon[1].SetActive(false);
                            Skill_icon[2].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Skill[1].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Skill_Select_2 = false;
                        }
                        else if (Skill_Select_3)
                        {
                            AudioManager.instance.Play("upgrade");
                            PlayerManager.instance.Soul -= 10;
                            PlayerManager.instance.Skill += 4;
                            PlayerManager.instance.SetSwitchValue("Skill_3", true);
                            Skill_icon[2].SetActive(false);
                            Skill_icon[3].SetActive(true);
                            Upgrade_Select = false;
                            Upgrade = false;
                            Select = false;
                            Tile.SetActive(false);
                            Skill[2].SetActive(false);
                            Success.SetActive(false);
                            Back.SetActive(false);
                            select[0].SetActive(false);
                            ability.upgrade();
                            Skill_Select_3 = false;
                        }
                        break;
                    case 1:
                        Select = false;
                        Upgrade_Select = false;
                        Upgrade = false;
                        Tile.SetActive(false);
                        HP[0].SetActive(false);
                        HP[1].SetActive(false);
                        HP[2].SetActive(false);
                        HP[3].SetActive(false);
                        Speed[0].SetActive(false);
                        Speed[1].SetActive(false);
                        Speed[2].SetActive(false);
                        Speed[3].SetActive(false);
                        DEF[0].SetActive(false);
                        DEF[1].SetActive(false);
                        DEF[2].SetActive(false);
                        DEF[3].SetActive(false);
                        Damage[0].SetActive(false);
                        Damage[1].SetActive(false);
                        Damage[2].SetActive(false);
                        Damage[3].SetActive(false);
                        Skill[0].SetActive(false);
                        Skill[1].SetActive(false);
                        Skill[2].SetActive(false);
                        Skill[3].SetActive(false);
                        Success.SetActive(false);
                        Back.SetActive(false);
                        select[1].SetActive(false);
                        break;
                }
            }
        }
        else if(!Upgrade)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (gameObject.transform.position.x == 0f && gameObject.transform.position.y == 0f)
                {
                    if (HP_Select_Fall)
                    {
                        Select = false;
                        Tile.SetActive(false);
                        HP[0].SetActive(false);
                        HP[1].SetActive(false);
                        HP[2].SetActive(false);
                        HP[3].SetActive(false);
                        Fall.SetActive(false);
                        Back.SetActive(false);
                        select[1].SetActive(false);
                        HP_Select_Fall = false;
                    }
                    else
                    {
                        if (PlayerManager.instance.GetSwitchValue("HP_3"))
                        {
                            Select = true;
                            Tile.SetActive(true);
                            HP[3].SetActive(true);
                            Back.SetActive(true);
                            select[1].SetActive(true);
                            HP_Select_Fall = true;
                        }
                        else if (PlayerManager.instance.GetSwitchValue("HP_2"))
                        {
                            if (PlayerManager.instance.Soul >= 100)
                            {
                                Tile.SetActive(true);
                                HP[2].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                HP_Select_3 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                HP[2].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                HP_Select_Fall = true;
                            }
                        }
                        else if (PlayerManager.instance.GetSwitchValue("HP_1"))
                        {
                            if (PlayerManager.instance.Soul >= 50)
                            {
                                Tile.SetActive(true);
                                HP[1].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                HP_Select_2 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                HP[1].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                HP_Select_Fall = true;
                            }
                        }
                        else
                        {
                            if (PlayerManager.instance.Soul >= 20)
                            {
                                Tile.SetActive(true);
                                HP[0].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                HP_Select_1 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                HP[0].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                HP_Select_Fall = true;
                            }
                        }
                    }
                }

                else if (gameObject.transform.position.x == 2f && gameObject.transform.position.y == 0f)
                {
                    if (Skill_Select_Fall)
                    {
                        Select = false;
                        Tile.SetActive(false);
                        Skill[0].SetActive(false);
                        Skill[1].SetActive(false);
                        Skill[2].SetActive(false);
                        Skill[3].SetActive(false);
                        Fall.SetActive(false);
                        Back.SetActive(false);
                        select[1].SetActive(false);
                        Skill_Select_Fall = false;
                    }
                    else
                    {
                        if (PlayerManager.instance.GetSwitchValue("Skill_3"))
                        {
                            Select = true;
                            Tile.SetActive(true);
                            Skill[3].SetActive(true);
                            Back.SetActive(true);
                            select[1].SetActive(true);
                            Skill_Select_Fall = true;
                        }
                        else if (PlayerManager.instance.GetSwitchValue("Skill_2"))
                        {
                            if (PlayerManager.instance.Soul >= 10)
                            {
                                Tile.SetActive(true);
                                Skill[2].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Skill_Select_3 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Skill[2].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Skill_Select_Fall = true;
                            }
                        }
                        else if (PlayerManager.instance.GetSwitchValue("Skill_1"))
                        {
                            if (PlayerManager.instance.Soul >= 5)
                            {
                                Tile.SetActive(true);
                                Skill[1].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Skill_Select_2 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Skill[1].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Skill_Select_Fall = true;
                            }
                        }
                        else
                        {
                            if (PlayerManager.instance.Soul >= 2)
                            {
                                Tile.SetActive(true);
                                Skill[0].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Skill_Select_1 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Skill[0].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Skill_Select_Fall = true;
                            }
                        }
                    }
                }

                else if (gameObject.transform.position.x == -2f && gameObject.transform.position.y == 0f)
                {
                    if (Damage_Select_Fall)
                    {
                        Select = false;
                        Tile.SetActive(false);
                        Damage[0].SetActive(false);
                        Damage[1].SetActive(false);
                        Damage[2].SetActive(false);
                        Damage[3].SetActive(false);
                        Fall.SetActive(false);
                        Back.SetActive(false);
                        select[1].SetActive(false);
                        Damage_Select_Fall = false;
                    }
                    else
                    {
                        if (PlayerManager.instance.GetSwitchValue("Damage_3"))
                        {
                            Select = true;
                            Tile.SetActive(true);
                            Damage[3].SetActive(true);
                            Back.SetActive(true);
                            select[1].SetActive(true);
                            Damage_Select_Fall = true;
                        }
                        else if (PlayerManager.instance.GetSwitchValue("Damage_2"))
                        {
                            if (PlayerManager.instance.Soul >= 10)
                            {
                                Tile.SetActive(true);
                                Damage[2].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Damage_Select_3 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Damage[2].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Damage_Select_Fall = true;
                            }
                        }
                        else if (PlayerManager.instance.GetSwitchValue("Damage_1"))
                        {
                            if (PlayerManager.instance.Soul >= 5)
                            {
                                Tile.SetActive(true);
                                Damage[1].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Damage_Select_2 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Damage[1].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Damage_Select_Fall = true;
                            }
                        }
                        else
                        {
                            if (PlayerManager.instance.Soul >= 2)
                            {
                                Tile.SetActive(true);
                                Damage[0].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Damage_Select_1 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Damage[0].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Damage_Select_Fall = true;
                            }
                        }
                    }
                }

                else if (gameObject.transform.position.x == 0f && gameObject.transform.position.y == -2f)
                {

                    if (Speed_Select_Fall)
                    {
                        Select = false;
                        Tile.SetActive(false);
                        Speed[0].SetActive(false);
                        Speed[1].SetActive(false);
                        Speed[2].SetActive(false);
                        Speed[3].SetActive(false);
                        Fall.SetActive(false);
                        Back.SetActive(false);
                        select[1].SetActive(false);
                        Speed_Select_Fall = false;
                    }
                    else
                    {
                        if (PlayerManager.instance.GetSwitchValue("Speed_3"))
                        {
                            Select = true;
                            Tile.SetActive(true);
                            Speed[3].SetActive(true);
                            Back.SetActive(true);
                            select[1].SetActive(true);
                            Speed_Select_Fall = true;
                        }
                        else if (PlayerManager.instance.GetSwitchValue("Speed_2"))
                        {
                            if (PlayerManager.instance.Soul >= 10)
                            {
                                Tile.SetActive(true);
                                Speed[2].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Speed_Select_3 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Speed[2].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Speed_Select_Fall = true;
                            }
                        }
                        else if (PlayerManager.instance.GetSwitchValue("Speed_1"))
                        {
                            if (PlayerManager.instance.Soul >= 5)
                            {
                                Tile.SetActive(true);
                                Speed[1].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Speed_Select_2 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Speed[1].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Speed_Select_Fall = true;
                            }
                        }
                        else
                        {
                            if (PlayerManager.instance.Soul >= 2)
                            {
                                Tile.SetActive(true);
                                Speed[0].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                Speed_Select_1 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                Speed[0].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                Speed_Select_Fall = true;
                            }
                        }
                    }
                }
                else
                {
                    if (DEF_Select_Fall)
                    {
                        Select = false;
                        Tile.SetActive(false);
                        DEF[0].SetActive(false);
                        DEF[1].SetActive(false);
                        DEF[2].SetActive(false);
                        DEF[3].SetActive(false);
                        Fall.SetActive(false);
                        Back.SetActive(false);
                        select[1].SetActive(false);
                        DEF_Select_Fall = false;
                    }
                    else
                    {
                        if (PlayerManager.instance.GetSwitchValue("DEF_3"))
                        {
                            Select = true;
                            Tile.SetActive(true);
                            DEF[3].SetActive(true);
                            Back.SetActive(true);
                            select[1].SetActive(true);
                            DEF_Select_Fall = true;
                        }
                        else if (PlayerManager.instance.GetSwitchValue("DEF_2"))
                        {
                            if (PlayerManager.instance.Soul >= 5)
                            {
                                Tile.SetActive(true);
                                DEF[2].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                DEF_Select_3 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                DEF[2].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                DEF_Select_Fall = true;
                            }
                        }
                        else if (PlayerManager.instance.GetSwitchValue("DEF_1"))
                        {
                            if (PlayerManager.instance.Soul >= 3)
                            {
                                Tile.SetActive(true);
                                DEF[1].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                DEF_Select_2 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                DEF[1].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                DEF_Select_Fall = true;
                            }
                        }
                        else
                        {
                            if (PlayerManager.instance.Soul >= 1)
                            {
                                Tile.SetActive(true);
                                DEF[0].SetActive(true);
                                Success.SetActive(true);
                                Back.SetActive(true);
                                select[0].SetActive(true);
                                DEF_Select_1 = true;
                                Upgrade_Select = true;
                                Upgrade = true;
                                Select = true;
                                Index = 0;
                            }
                            else
                            {
                                Select = true;
                                Tile.SetActive(true);
                                DEF[0].SetActive(true);
                                Fall.SetActive(true);
                                Back.SetActive(true);
                                select[1].SetActive(true);
                                DEF_Select_Fall = true;
                            }
                        }
                    }
                }
            }
        }

        if (!Select)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Map = PlayerManager.instance.CurrentSceneName;
                PlayerManager.instance.MapName = "";
                if (Map == "")
                {
                    Map = "Map001";
                    fadeController.FadeOut();
                    StartCoroutine(Wait());
                }
                else
                {
                    fadeController.FadeOut();
                    StartCoroutine(Wait());
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                Vector3 currentPosition = transform.position;

                if (currentPosition.y == 2.0f || currentPosition.x == 2.0f || currentPosition.x == -2.0f) return;

                currentPosition.y += 2.0f;

                transform.position = currentPosition;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                Vector3 currentPosition = transform.position;

                if (currentPosition.y == -2.0f || currentPosition.x == 2.0f || currentPosition.x == -2.0f) return;

                currentPosition.y -= 2.0f;

                transform.position = currentPosition;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                Vector3 currentPosition = transform.position;

                if (currentPosition.x == 2.0f || currentPosition.y == 2.0f || currentPosition.y == -2.0f) return;

                currentPosition.x += 2.0f;

                transform.position = currentPosition;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                Vector3 currentPosition = transform.position;

                if (currentPosition.x == -2.0f || currentPosition.y == 2.0f || currentPosition.y == -2.0f) return;

                currentPosition.x -= 2.0f;

                transform.position = currentPosition;
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Map);
        fadeController.FadeIn2();
        tilemanger.Ability = false;
        playerControll.NotMove = false;
    }
}
