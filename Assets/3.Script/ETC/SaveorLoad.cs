using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveorLoad : MonoBehaviour
{
    [Serializable]
    public class Data
    {
        public float PlayerX; // 플레이어 x좌표
        public float PlayerY; // 플레이어 y좌표
        public float PlayerZ; // 플레이어 z좌표
        public bool PlayerReper; // 플레이어가 리퍼상태라면

        public float PlayerMax_HP; // 플레이어 MaxHP
        public float PlayerHP; // 플레이어 현재 HP
        public float PlayerMax_MP; // 플레이어 MaxMP
        public float PlayerMP; // 플레이어 현재 MP

        public float PlayerDamage; // 플레이어 공격력
        public float PlayerSpeed; // 플레이어 스피드
        public float PlayerDEF; // 플레이어 방어력
        public float PlayerSkill; // 플레이어 스킬
        public float PlayerSoul; // 플레이어 현재 영혼

        public string Scenename; // 현재 플레이어가 있는 씬

        public List<string> Abilityname; // 어빌리티 이름
        public List<bool> Abilitysw; // 어빌리티 변수
        public List<string> Swname; // 스위치이름
        public List<bool> Swcount; // 스위치값
        public List<string> Item_name; // 이름
        public List<int> Item_count; // 갯수

        public Data()
        {
            Abilityname = new List<string>();
            Abilitysw = new List<bool>();
            Swname = new List<string>();
            Swcount = new List<bool>();
            Item_name = new List<string>();
            Item_count = new List<int>();
        }
    }


    private PlayerControll playercontroll;
    public Data data;

    private void Start()
    {
        TryGetComponent(out playercontroll);
    }

    public void Save()
    {
        playercontroll = FindObjectOfType<PlayerControll>();

        data.PlayerX = playercontroll.transform.position.x;
        data.PlayerY = playercontroll.transform.position.y;
        data.PlayerZ = playercontroll.transform.position.z;
        data.PlayerReper = PlayerManager.instance.Reaper_P;

        data.PlayerMax_HP = PlayerManager.instance.Max_HP;
        data.PlayerHP = PlayerManager.instance.HP;
        data.PlayerMax_MP = PlayerManager.instance.Max_MP;
        data.PlayerMP = PlayerManager.instance.MP;

        data.PlayerDamage = PlayerManager.instance.Damage;
        data.PlayerSpeed = PlayerManager.instance.Speed;
        data.PlayerDEF = PlayerManager.instance.DEF;
        data.PlayerSkill = PlayerManager.instance.Skill;
        data.PlayerSoul = PlayerManager.instance.Soul;

        data.Scenename = PlayerManager.instance.CurrentSceneName;

        data.Abilityname = new List<string>(PlayerManager.instance.Ability_name);
        data.Abilitysw = new List<bool>(PlayerManager.instance.Abilityswitch);

        data.Swname = new List<string>(DataManager.instance.switch_name);
        data.Swcount = new List<bool>(DataManager.instance.switches);

        data.Item_name = new List<string>(DataManager.instance.Item_name);
        data.Item_count = new List<int>(DataManager.instance.Item_count);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.dataPath + "/SaveFile.json", json);

        Debug.Log(Application.dataPath + "/SaveFile.json 위치에 저장하였습니다.");
    }

    public void Load()
    {
        string filePath = Application.dataPath + "/SaveFile.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(json);

            ApplyLoadedData();
            Debug.Log("데이터 로드 완료!");
        }
        else
        {
            Debug.Log("세이브 파일을 찾을 수 없습니다.");
        }
    }

    private void ApplyLoadedData()
    {
        PlayerManager.instance.Max_HP = data.PlayerMax_HP;
        PlayerManager.instance.HP = data.PlayerHP;
        PlayerManager.instance.Max_MP = data.PlayerMax_MP;
        PlayerManager.instance.MP = data.PlayerMP;
        PlayerManager.instance.Reaper_P = data.PlayerReper;

        PlayerManager.instance.Damage = data.PlayerDamage;
        PlayerManager.instance.Speed = data.PlayerSpeed;
        PlayerManager.instance.DEF = data.PlayerDEF;
        PlayerManager.instance.Skill = data.PlayerSkill;
        PlayerManager.instance.Soul = data.PlayerSoul;
        PlayerManager.instance.CurrentSceneName = data.Scenename;

        PlayerManager.instance.Ability_name = data.Abilityname.ToArray();
        PlayerManager.instance.Abilityswitch = data.Abilitysw.ToArray();

        DataManager.instance.switch_name = data.Swname.ToArray();
        DataManager.instance.switches = data.Swcount.ToArray();

        DataManager.instance.Item_name = data.Item_name.ToArray();
        DataManager.instance.Item_count = data.Item_count.ToArray();

        if (PlayerManager.instance.Reaper_P) playercontroll.Reaper = true;
        gameObject.transform.position = new Vector3(data.PlayerX, data.PlayerY, data.PlayerZ);

        if (data.Scenename == "Map007")
        {
            AudioManager.instance.Play("Map_007");
        }
        else if (data.Scenename == "Map008")
        {
            AudioManager.instance.Play("dungeon");
        }
        else if (data.Scenename == "Map005")
        {
            AudioManager.instance.Play("Story_1");
        }

        Debug.Log(data.Scenename);

        SceneManager.LoadScene(data.Scenename);
    }

}
