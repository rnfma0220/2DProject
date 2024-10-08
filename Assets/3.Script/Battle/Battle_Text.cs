using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Text : MonoBehaviour
{
    public Text damageText;

    void Start()
    {
        damageText.gameObject.SetActive(false);
    }

    public void ShowDamage(float damage)
    {
        if (damage == 0)
        {
            damageText.text = "Miss";
        }
        else
        {
            damageText.text = damage.ToString();
        }
        damageText.gameObject.SetActive(true);
        StartCoroutine(FadeAndDeactivate());
    }

    private IEnumerator FadeAndDeactivate()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Color originalColor = damageText.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            damageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        damageText.gameObject.SetActive(false);
    }
}
