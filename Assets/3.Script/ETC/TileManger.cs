using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TileManger : MonoBehaviour
{
    public static TileManger instance = null;
    [SerializeField] private GameObject[] Tile;
    [SerializeField] private GameObject Esc_On;
    [SerializeField] private GameObject Esc_On_1;
    [SerializeField] private GameObject HP;
    [SerializeField] private GameObject MP;
    [SerializeField] private GameObject Soul;
    private SaveorLoad saveorload;
    private bool Esc;
    private PlayerControll playerControll;
    private FadeController fadeController;
    private int currentTileIndex = 0;
    private string MoveMap;
    public bool Ability;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            playerControll = FindObjectOfType<PlayerControll>();
            fadeController = FindObjectOfType<FadeController>();
            saveorload = FindObjectOfType<SaveorLoad>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Ability) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Esc)
            {
                Esc_On.SetActive(true);
                Esc_On_1.SetActive(true);
                Tile[0].SetActive(true);
                HP.SetActive(true);
                MP.SetActive(true);
                Soul.SetActive(true);
                currentTileIndex = 0;
                Esc = true;
                playerControll.NotMove = true;
            }
            else
            {
                Esc_On.SetActive(false);
                Esc_On_1.SetActive(false);
                HP.SetActive(false);
                MP.SetActive(false);
                Soul.SetActive(false);
                Tile[currentTileIndex].SetActive(false);
                Esc = false;
                playerControll.NotMove = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Esc)
            {
                AudioManager.instance.Play("Menu_Move");
                Tile[currentTileIndex].SetActive(false);
                currentTileIndex = (currentTileIndex + 1) % Tile.Length;
                Tile[currentTileIndex].SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Esc)
            {
                AudioManager.instance.Play("Menu_Move");
                if (currentTileIndex == 0)
                {
                    Tile[currentTileIndex].SetActive(false);
                    currentTileIndex = 7;
                    Tile[currentTileIndex].SetActive(true);
                }
                else
                {
                    Tile[currentTileIndex].SetActive(false);
                    currentTileIndex = (currentTileIndex - 1) % Tile.Length;
                    Tile[currentTileIndex].SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Esc)
            {
                switch (currentTileIndex)
                {
                    case 0: // 라벤더의 영
                        MoveMap = "PlayerAbility";
                        fadeController.FadeOut();
                        StartCoroutine(Wait());
                        Esc_On.SetActive(false);
                        Esc_On_1.SetActive(false);
                        HP.SetActive(false);
                        MP.SetActive(false);
                        Soul.SetActive(false);
                        Tile[currentTileIndex].SetActive(false);
                        playerControll.NotMove = true;
                        Ability = true;
                        Esc = false;
                        break;
                    case 1: // 주머니
                        Debug.Log("주머니");
                        MoveMap = "PlayerInv";
                        fadeController.FadeOut();
                        StartCoroutine(Wait());
                        Esc_On.SetActive(false);
                        Esc_On_1.SetActive(false);
                        HP.SetActive(false);
                        MP.SetActive(false);
                        Soul.SetActive(false);
                        Tile[currentTileIndex].SetActive(false);
                        playerControll.NotMove = true;
                        Ability = true;
                        Esc = false;
                        break;
                    case 2: // 메뉴얼
                        Debug.Log("메뉴얼");
                        break;
                    case 3: // 저장
                        Debug.Log("저장");
                        AudioManager.instance.Play("Save");
                        saveorload.Save();
                        Esc_On.SetActive(false);
                        Esc_On_1.SetActive(false);
                        HP.SetActive(false);
                        MP.SetActive(false);
                        Soul.SetActive(false);
                        Tile[currentTileIndex].SetActive(false);
                        Esc = false;
                        playerControll.NotMove = false;
                        break;
                    case 4: // 불러오기
                        Debug.Log("불러오기");
                        saveorload.Load();
                        Esc_On.SetActive(false);
                        Esc_On_1.SetActive(false);
                        HP.SetActive(false);
                        MP.SetActive(false);
                        Soul.SetActive(false);
                        Tile[currentTileIndex].SetActive(false);
                        Esc = false;
                        playerControll.NotMove = false;
                        break;
                    case 5: // 설정
                        Debug.Log("설정");
                        break;
                    case 6: // 종료
                        fadeController.FadeOut();
                        playerControll.NotMove = true;
                        Esc_On.SetActive(false);
                        Esc_On_1.SetActive(false);
                        HP.SetActive(false);
                        MP.SetActive(false);
                        Soul.SetActive(false);
                        Tile[currentTileIndex].SetActive(false);
                        Esc = false;
                        StartCoroutine(Exit());
                        break;
                    case 7: // 돌아가기
                        Esc_On.SetActive(false);
                        Esc_On_1.SetActive(false);
                        HP.SetActive(false);
                        MP.SetActive(false);
                        Soul.SetActive(false);
                        Tile[currentTileIndex].SetActive(false);
                        Esc = false;
                        playerControll.NotMove = false;
                        break;
                }
            }
        }

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(MoveMap);
        fadeController.FadeIn2();
    }

    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
