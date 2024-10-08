using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Ghastling : MonoBehaviour
{
    public float Mob_Max_HP = 100;
    public float Mob_HP = 100;
    public float Damage = 7;
    public float DEF = 0;
    public float Speed = 8;

    public bool Mob_Die;

    private SpriteRenderer spriteRenderer;
    private Battle_Text battle_Text;

    private void Start()
    {
        TryGetComponent(out spriteRenderer);
        TryGetComponent(out battle_Text);
    }

    public void TakeDamage(float damage)
    {
        Mob_HP -= damage;
        ShowDamage(damage);
        if (Mob_HP <= 0)
        {
            StartCoroutine(DamEffect());
            StartCoroutine(DieWithFade());
        }
        else
        {
            StartCoroutine(DamEffect());
        }
    }

    private IEnumerator DamEffect()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator DieWithFade()
    {
        float fadeDuration = 1.0f;
        float timer = 0.0f;
        Color startColor = spriteRenderer.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(1, 0, normalizedTime));
            yield return null;
        }

        Mob_Die = true;
        gameObject.SetActive(false);
    }

    private void ShowDamage(float Damage)
    {
        battle_Text.ShowDamage(Damage);
    }
}
