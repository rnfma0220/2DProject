using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public RuntimeAnimatorController newAnimatorController;
    public RuntimeAnimatorController oldAnimatorController;
    public string MapName = "Map001";
    public string CurrentSceneName = "Map001";
    public bool Reaper_P;

    public float Max_HP = 100;
    public float HP = 100;
    public float Max_MP = 50;
    public float MP = 0;
    public float Damage = 20;
    public float Speed = 1;
    public float DEF = 1;
    public float Skill = 1;
    public float Soul = 0;
    public string[] Ability_name;
    public bool[] Abilityswitch;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Ability_name = new string[15];
        Abilityswitch = new bool[15];

        Ability_name[0] = "HP_1";
        Ability_name[1] = "HP_2";
        Ability_name[2] = "HP_3";
        Ability_name[3] = "Speed_1";
        Ability_name[4] = "Speed_2";
        Ability_name[5] = "Speed_3";
        Ability_name[6] = "Damage_1";
        Ability_name[7] = "Damage_2";
        Ability_name[8] = "Damage_3";
        Ability_name[9] = "DEF_1";
        Ability_name[10] = "DEF_2";
        Ability_name[11] = "DEF_3";
        Ability_name[12] = "Skill_1";
        Ability_name[13] = "Skill_2";
        Ability_name[14] = "Skill_3";

        for (int i = 0; i < Ability_name.Length; i++)
        {
            Abilityswitch[i] = false;
        }

    }

    public bool GetSwitchValue(string name) // 입력한 name의 스위치 값을 확인하여 출력
    {
        for (int i = 0; i < Ability_name.Length; i++)
        {
            if (Ability_name[i] == name)
            {
                return Abilityswitch[i];
            }
        }
        return false;
    }

    public void SetSwitchValue(string name, bool value)
    {
        for (int i = 0; i < Ability_name.Length; i++)
        {
            if (Ability_name[i] == name)
            {
                Abilityswitch[i] = value;
                break;
            }
        }
    }
}
