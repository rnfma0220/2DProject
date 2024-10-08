using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPlay : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private FadeController fadeController;
    [SerializeField] GameObject Intro1;
    private bool isStart = false;
    private float fadeTime = 1f;
    private float elapsedTime = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fadeController = FindObjectOfType<FadeController>();
        StartCoroutine(Play_co());
    }

    private void Update()
    {
        if (fadeController.isFadeing) return;

        if (isStart) GameStart();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            AudioManager.instance.Play("Select");
            isStart = true;
            fadeController.FadeOut();
        }
    }

    private void GameStart()
    {
        if (isStart)
        {
            SceneManager.LoadScene("Intro2");
        }
    }

    private IEnumerator Play_co()
    {
        while (true)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.PingPong(elapsedTime / fadeTime, 1f);

            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
            yield return null;
        }
    }
}
