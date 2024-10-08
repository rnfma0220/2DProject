using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMove_Door : MonoBehaviour
{
    [SerializeField] private string MoveMap;
    private Animator animator;
    private PlayerControll playercontroll;
    private FadeController fadeController;

    private void Start()
    {

        playercontroll = FindObjectOfType<PlayerControll>();
        fadeController = FindObjectOfType<FadeController>();
        TryGetComponent(out animator);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerManager.instance.MapName == "Map003")
        {
            if (collision.gameObject.tag == "Player" && playercontroll.DirY == 1)
            {
                playercontroll.NotMove = true;
                PlayerManager.instance.MapName = "Map002_2";
                fadeController.FadeOut();
                StartCoroutine(Door_animation());
            }
        }
        else if (MoveMap == "Map001_2")
        {
            if (collision.gameObject.tag == "Player" && playercontroll.DirY == 1)
            {
                playercontroll.NotMove = true;
                PlayerManager.instance.MapName = "Map001_2";
                MoveMap = "Map001";
                fadeController.FadeOut();
                StartCoroutine(Door_animation());
            }
        }
        else if (MoveMap == "Map004_3")
        {
            if (collision.gameObject.tag == "Player" && playercontroll.DirY == 1)
            {
                playercontroll.NotMove = true;
                PlayerManager.instance.MapName = "Map004_3";
                MoveMap = "Map004";
                fadeController.FadeOut();
                StartCoroutine(Door_animation());
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player" && playercontroll.DirY == 1)
            {
                playercontroll.NotMove = true;
                PlayerManager.instance.MapName = MoveMap;
                fadeController.FadeOut();
                StartCoroutine(Door_animation());
            }
        }
    }

    private IEnumerator Door_animation()
    {
        animator.SetBool("DoorOpen", true);
        AudioManager.instance.Play("Door_Open");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(MoveMap);
        fadeController.FadeIn2();
        playercontroll.NotMove = false;
    }
}