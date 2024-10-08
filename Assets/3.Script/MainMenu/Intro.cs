using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] GameObject Intro0;
    [SerializeField] GameObject Intro1;
    private FadeController fadeController;
    private bool isIntro = false;

    private void Awake()
    {
        fadeController = FindObjectOfType<FadeController>();
    }

    private void Start()
    {
        fadeController.FadeIn();
    }

    private void Update()
    {
        if (fadeController.isFadeing) return;

        if(isIntro)
        {
            Intro0.SetActive(false);
            Intro1.SetActive(true);
            fadeController.FadeIn();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                AudioManager.instance.Play("Select");
                fadeController.FadeOut();
                isIntro = true;
            }
        }
    }
}
