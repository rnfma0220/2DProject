using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Text : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float delay = 0.05f;

    private string fullText;
    private string currentText;

    private void OnEnable()
    {
        fullText = uiText.text;  // uiText에 적힌 텍스트를 가져옵니다.
        uiText.text = "";  // 초기에는 텍스트를 빈 문자열로 설정합니다.
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            uiText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
