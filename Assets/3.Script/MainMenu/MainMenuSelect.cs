using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSelect : MonoBehaviour
{
    private FadeController fadeController;
    private PlayerControll playerControll;
    private SaveorLoad saveorload;
    [SerializeField] private Text Load;
    private float x = 0f;
    private float y = 0.8f;
    private bool isQuit = false;
    private bool isStart = false;

    private void Awake()
    {
        fadeController = FindObjectOfType<FadeController>();
        saveorload = FindObjectOfType<SaveorLoad>();
        playerControll = FindObjectOfType<PlayerControll>();
    }

    private void Start()
    {
        playerControll.NotMove = true;
    }

    private void Update()
    {
        string filePath = Application.dataPath + "/SaveFile.json";

        if (File.Exists(filePath)) // 로드파일이 있을경우 글씨 흰색으로 변경
        {
            Load.color = Color.white;
        }

        if (fadeController.isFadeing) return; // 페이드중에는 아래 내용은 전부다 return을 통해 작동되지않는다.

        if (isQuit) GameExit();

        if (isStart) GameStart();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.instance.Play("Menu_Move");
            if (transform.position == new Vector3(0, -3.6f, 0))
            {
                transform.position = new Vector3(x, -2.0f, 0);
            }
            else
            {
                transform.position -= new Vector3(x, y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManager.instance.Play("Menu_Move");
            if (transform.position == new Vector3(0, -2.0f, 0))
            {
                transform.position = new Vector3(x, -3.6f, 0);
            }
            else
            {
                transform.position += new Vector3(x, y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AudioManager.instance.Play("Menu_select");
            if (transform.position == new Vector3(0, -2.0f, 0))
            {
                fadeout();
                isStart = true;
            }
            else if (transform.position == new Vector3(0, -2.8f, 0))
            {
                saveorload.Load();
                playerControll.NotMove = false;
            }
            else
            {
                fadeout();
                isQuit = true;
            }
        }
    }

    private void fadeout()
    {
        fadeController.FadeOut();
    }

    private void GameExit()
    {
        Application.Quit();
    }

    private void GameStart()
    {
        SceneManager.LoadScene("Intro");
    }
}
