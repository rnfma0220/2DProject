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
        fullText = uiText.text;  // uiText�� ���� �ؽ�Ʈ�� �����ɴϴ�.
        uiText.text = "";  // �ʱ⿡�� �ؽ�Ʈ�� �� ���ڿ��� �����մϴ�.
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
