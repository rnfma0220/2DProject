using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private bool isFadeIn;
    public GameObject panel;
    public bool isFadeing = false;

    private void Start()
    {
        if (!panel)
        {
            Debug.LogError("Fade�� ������ Panel�� �����ϴ�.");
        }
        if (isFadeIn)
        {
            isFadeing = true;
            panel.SetActive(true);
            StartCoroutine(FadeIn_Co());
        }
        else
        {
            panel.SetActive(false);
        }
    }
    
    public void Fadeoff()
    {
        panel.SetActive(false);
    }

    public void FadeIn()
    {
        if (!isFadeing)
        {
            isFadeing = true;
            panel.SetActive(true);
            StartCoroutine(FadeIn_Co());
        }
    }
    public void FadeIn2()
    {
        if (!isFadeing)
        {
            isFadeing = true;
            panel.SetActive(true);
            StartCoroutine(FadeIn2_Co());
        }
    }

    public void FadeOut()
    {
        if (!isFadeing)
        {
            isFadeing = true;
            panel.SetActive(true);
            StartCoroutine(FadeOut_Co());
        }
    }

    private IEnumerator FadeIn_Co()
    {
        float elapsedTime = 0f;
        float fadeTime = 2f;

        while (elapsedTime <= fadeTime)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / fadeTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isFadeing = false;
        panel.SetActive(false);
        yield break;
    }

    private IEnumerator FadeIn2_Co()
    {
        float elapsedTime = 0f;
        float fadeTime = 0.5f;

        while (elapsedTime <= fadeTime)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / fadeTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isFadeing = false;
        panel.SetActive(false);
        yield break;
    }

    private IEnumerator FadeOut_Co()
    {
        float elapsedTime = 0f;
        float fadeTime = 2f;

        while(elapsedTime <= fadeTime)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / fadeTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isFadeing = false;
        yield break;
    }
}
