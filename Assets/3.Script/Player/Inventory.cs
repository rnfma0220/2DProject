using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject MenuUpSelect;
    [SerializeField] private GameObject MenuDownSelect;
    [SerializeField] private GameObject Tile;
    [SerializeField] private GameObject HPMAX;
    [SerializeField] private GameObject CountZero;
    [SerializeField] private GameObject HPbar;
    [SerializeField] private GameObject MPbar;
    [SerializeField] private GameObject[] Item_objects = new GameObject[8];
    [SerializeField] private GameObject[] Item_Image = new GameObject[8];
    [SerializeField] private Text[] Itemcount = new Text[8];
    private FadeController fadeController;
    private PlayerControll playerControll;
    private TileManger tileManger;
    private int SelectUp_Index;
    private int SelectDown_Index;
    private bool Select;
    private string Map;

    private void Start()
    {
        fadeController = FindObjectOfType<FadeController>();
        playerControll = FindObjectOfType<PlayerControll>();
        tileManger = FindObjectOfType<TileManger>();
        UpdateItemVisibility();
    }

    private void Update()
    {
        if (!Select)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                if (SelectUp_Index == 7)
                {
                    Vector3 position = MenuUpSelect.transform.position;
                    position.y = 1.97f;
                    if (Item_Image[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(false);
                    SelectUp_Index = 0;
                    if (Item_objects[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(true);
                    MenuUpSelect.transform.position = position;
                }
                else
                {
                    Vector3 position = MenuUpSelect.transform.position;
                    position.y -= 0.565f;
                    if (Item_Image[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(false);
                    SelectUp_Index += 1;
                    if (Item_objects[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(true);
                    MenuUpSelect.transform.position = position;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                if (SelectUp_Index == 0)
                {
                    Vector3 position = MenuUpSelect.transform.position;
                    position.y = -1.985f;
                    if (Item_Image[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(false);
                    SelectUp_Index = 7;
                    if (Item_objects[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(true);
                    MenuUpSelect.transform.position = position;
                }
                else
                {
                    Vector3 position = MenuUpSelect.transform.position;
                    position.y += 0.565f;
                    if (Item_Image[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(false);
                    SelectUp_Index -= 1;
                    if (Item_objects[SelectUp_Index].activeSelf) Item_Image[SelectUp_Index].SetActive(true);
                    MenuUpSelect.transform.position = position;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Select = true;
                MenuDownSelect.SetActive(true);
            }

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
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                if (SelectDown_Index == 1)
                {
                    Vector3 position = MenuDownSelect.transform.position;
                    position.x = -4.8f;
                    SelectDown_Index = 0;
                    MenuDownSelect.transform.position = position;
                }
                else
                {
                    Vector3 position = MenuDownSelect.transform.position;
                    position.x = -1.44f;
                    SelectDown_Index = 1;
                    MenuDownSelect.transform.position = position;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioManager.instance.Play("Menu_Move");
                if (SelectDown_Index == 0)
                {
                    Vector3 position = MenuDownSelect.transform.position;
                    position.x = -1.44f;
                    SelectDown_Index = 1;
                    MenuDownSelect.transform.position = position;
                }
                else
                {
                    Vector3 position = MenuDownSelect.transform.position;
                    position.x = -4.8f;
                    SelectDown_Index = 0;
                    MenuDownSelect.transform.position = position;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (SelectDown_Index == 0)
                {
                    if (DataManager.instance.Item_count[SelectUp_Index] == 0)
                    {
                        bool isActive = Tile.activeSelf && CountZero.activeSelf;
                        Tile.SetActive(!isActive);
                        CountZero.SetActive(!isActive);
                    }
                    else if (PlayerManager.instance.HP == PlayerManager.instance.Max_HP)
                    {
                        bool isActive = Tile.activeSelf && HPMAX.activeSelf;
                        Tile.SetActive(!isActive);
                        HPMAX.SetActive(!isActive);
                    }
                    else
                    {
                        if(SelectUp_Index == 1)
                        {
                            DataManager.instance.RemoveItem(1);
                            UpdateItemVisibility();
                            PlayerManager.instance.HP += 50;
                            if(PlayerManager.instance.HP >= PlayerManager.instance.Max_HP)
                            {
                                PlayerManager.instance.HP = PlayerManager.instance.Max_HP;
                            }
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                        else if(SelectUp_Index == 2)
                        {
                            DataManager.instance.RemoveItem(2);
                            UpdateItemVisibility();
                            PlayerManager.instance.HP += 100;
                            if (PlayerManager.instance.HP >= PlayerManager.instance.Max_HP)
                            {
                                PlayerManager.instance.HP = PlayerManager.instance.Max_HP;
                            }
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                        else if (SelectUp_Index == 3)
                        {
                            DataManager.instance.RemoveItem(3);
                            UpdateItemVisibility();
                            PlayerManager.instance.HP += 200;
                            if (PlayerManager.instance.HP >= PlayerManager.instance.Max_HP)
                            {
                                PlayerManager.instance.HP = PlayerManager.instance.Max_HP;
                            }
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                        else if (SelectUp_Index == 4)
                        {
                            DataManager.instance.RemoveItem(4);
                            UpdateItemVisibility();
                            PlayerManager.instance.HP += 500;
                            if (PlayerManager.instance.HP >= PlayerManager.instance.Max_HP)
                            {
                                PlayerManager.instance.HP = PlayerManager.instance.Max_HP;
                            }
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                        else if (SelectUp_Index == 5)
                        {
                            DataManager.instance.RemoveItem(5);
                            UpdateItemVisibility();
                            PlayerManager.instance.HP += 300;
                            PlayerManager.instance.MP += 50;
                            if (PlayerManager.instance.HP >= PlayerManager.instance.Max_HP)
                            {
                                PlayerManager.instance.HP = PlayerManager.instance.Max_HP;
                            }
                            if (PlayerManager.instance.MP >= PlayerManager.instance.Max_MP)
                            {
                                PlayerManager.instance.MP = PlayerManager.instance.Max_MP;
                            }
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                        else if (SelectUp_Index == 6)
                        {
                            DataManager.instance.RemoveItem(6);
                            UpdateItemVisibility();
                            PlayerManager.instance.MP = PlayerManager.instance.Max_MP;
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                        else if (SelectUp_Index == 7)
                        {
                            DataManager.instance.RemoveItem(7);
                            UpdateItemVisibility();
                            PlayerManager.instance.HP = PlayerManager.instance.Max_HP;
                            PlayerManager.instance.MP = PlayerManager.instance.Max_MP;
                            Select = false;
                            MenuDownSelect.SetActive(false);
                            SelectDown_Index = 0;
                        }
                    }
                }
                else
                {
                    AudioManager.instance.Play("Cancel");
                    Select = false;
                    MenuDownSelect.SetActive(false);
                    SelectDown_Index = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Select = false;
                MenuDownSelect.SetActive(false);
                SelectDown_Index = 0;
            }
        }
    }

    private void UpdateItemVisibility()
    {
        for (int i = 0; i < Item_objects.Length; i++)
        {
            if (Item_objects[i] != null)
            {
                Item_objects[i].SetActive(DataManager.instance.Item_count[i] > 0);
                Itemcount[i].text = DataManager.instance.Item_count[i].ToString();
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Map);
        fadeController.FadeIn2();
        tileManger.Ability = false;
        playerControll.NotMove = false;
    }
}
