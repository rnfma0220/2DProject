using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMove_Dungeon : MonoBehaviour
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
            PlayerManager.instance.MapName = MoveMap;
            fadeController.FadeOut();
            StartCoroutine(Door());
        }
    }

    private IEnumerator Door()
    {
        AudioManager.instance.Stop("Map_007");
        AudioManager.instance.Play("dungeon");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(MoveMap);
        PlayerManager.instance.CurrentSceneName = MoveMap;
    }
}