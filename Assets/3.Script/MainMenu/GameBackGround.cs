using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBackGround : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private FadeController fadeController;
    [SerializeField] private GameObject WakeUp;
    [SerializeField] private GameObject GameBackground;
    private bool isColor = false;

    private void Start()
    {
        TryGetComponent(out spriteRenderer);
        fadeController = FindObjectOfType<FadeController>();

        fadeController.FadeIn();
    }

    private void Update()
    {
        if (fadeController.isFadeing) return;

        if (isColor) Color();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AudioManager.instance.Play("Select");
            GameBackground.SetActive(false);
            WakeUp.SetActive(false);
            isColor = true;
        }
    }

    private void Color()
    {
        if (spriteRenderer.color.r < 1)
        {
            Color color = spriteRenderer.color;
            color.r += 0.2f * Time.deltaTime;
            color.g += 0.2f * Time.deltaTime;
            color.b += 0.2f * Time.deltaTime;
            spriteRenderer.color = color;
        }
        else
        {
            SceneManager.LoadScene("Intro3");
            return;
        }
    }
}
