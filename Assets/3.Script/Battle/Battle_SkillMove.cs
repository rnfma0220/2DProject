using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_SkillMove : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Battle_tutorial battle;
    public bool Dodge;

    private void Start()
    {
        battle = FindObjectOfType<Battle_tutorial>();
        TryGetComponent(out animator);
        TryGetComponent(out spriteRenderer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            animator.speed = 0f;
            Sprite currentSprite = spriteRenderer.sprite;
            if (currentSprite != null)
            {
                string spriteName = currentSprite.name;
                if(spriteName.Equals("Evade_Sprite_Sheet_46") || spriteName.Equals("Evade_Sprite_Sheet_47") || spriteName.Equals("Evade_Sprite_Sheet_48"))
                {
                    battle.Dodge = true;
                    battle.Chat_12 = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    battle.Dodge = false;
                    battle.Chat_12 = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
