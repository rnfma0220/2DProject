using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMove : MonoBehaviour
{
    [SerializeField] private string MoveMap;
    private PlayerControll playercontroll;
    private FadeController fadeController;

    private void Start()
    {

        playercontroll = FindObjectOfType<PlayerControll>();
        fadeController = FindObjectOfType<FadeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playercontroll.NotMove = true;
            if (MoveMap == "Map004_2")
            {
                PlayerManager.instance.MapName = "Map004_2";
                MoveMap = "Map004";
            }
            else if (MoveMap == "Map002_1")
            {
                PlayerManager.instance.MapName = "Map002_3";
                MoveMap = "Map002";
            }
            else if (MoveMap == "Map002_2")
            {
                PlayerManager.instance.MapName = "Map002_4";
                MoveMap = "Map002";
            }
            else if (MoveMap == "Map005_2")
            {
                PlayerManager.instance.MapName = "Map005_2";
                AudioManager.instance.Stop("Map_007");
                AudioManager.instance.Play("Story_1");
                MoveMap = "Map005";
            }
            else if (MoveMap == "Map005_3")
            {
                PlayerManager.instance.MapName = "Map005_3";
                AudioManager.instance.Stop("Map_007");
                AudioManager.instance.Play("Story_1");
                MoveMap = "Map005";
            }
            else if (MoveMap == "Map006")
            {
                PlayerManager.instance.MapName = MoveMap;
                AudioManager.instance.Stop("Story_1");
                AudioManager.instance.Play("Map_007");
            }
            else if (MoveMap == "Map007")
            {
                PlayerManager.instance.MapName = MoveMap;
                AudioManager.instance.Stop("Story_1");
                AudioManager.instance.Play("Map_007");
            }
            else if (MoveMap == "Map007_2")
            {
                PlayerManager.instance.MapName = "Map007_2";
                playercontroll.Reaper = true;
                AudioManager.instance.Stop("dungeon");
                AudioManager.instance.Play("Map_007");
                MoveMap = "Map007";
            }
            else
            {
                PlayerManager.instance.MapName = MoveMap;
            }
            fadeController.FadeOut();
            StartCoroutine(Door());
        }
    }

    private IEnumerator Door()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(MoveMap);
        PlayerManager.instance.CurrentSceneName = MoveMap;
        fadeController.FadeIn2();
        playercontroll.NotMove = false;
    }
}