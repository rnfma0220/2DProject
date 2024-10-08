using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string[] switch_name;
    public bool[] switches;
    public string[] Item_name;
    public int[] Item_count;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        switch_name = new string[5];
        switches = new bool[5];
        Item_name = new string[8];
        Item_count = new int[8];

        switch_name[0] = "Robe";
        switch_name[1] = "Ghost";
        switch_name[2] = "NPC_1";
        switch_name[3] = "Dungeon";
        switch_name[4] = "Battle_1";

        for (int i = 0; i < switches.Length; i++)
        {
            switches[i] = false;
        }

        Item_name[0] = "Ƽ��";
        Item_name[1] = "���ý�_��Ű";
        Item_name[2] = "���վ��״�_����";
        Item_name[3] = "��ħ��_����";
        Item_name[4] = "���ݷ�_����ũ";
        Item_name[5] = "�ٰ�Ʈ";
        Item_name[6] = "���";
        Item_name[7] = "�����";

        for (int i = 0; i < Item_count.Length; i++)
        {
            Item_count[i] = 0;
        }
    }

    public bool GetSwitchValue(string name) // �Է��� name�� ����ġ ���� Ȯ���Ͽ� ���
    {
        for (int i = 0; i < switch_name.Length; i++)
        {
            if (switch_name[i] == name)
            {
                return switches[i];
            }
        }
        return false;
    }

    public void SetSwitchValue(string name, bool value)
    {
        for (int i = 0; i < switch_name.Length; i++)
        {
            if (switch_name[i] == name)
            {
                switches[i] = value;
                break;
            }
        }
    }

    public void AddItem(int index, int count)
    {
        if (index >= 0 && index < Item_count.Length)
        {
            Item_count[index] += count;
        }
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < Item_count.Length && Item_count[index] > 0)
        {
            Item_count[index]--;
        }
    }
}
