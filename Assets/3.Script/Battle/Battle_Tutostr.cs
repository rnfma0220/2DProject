using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Tutostr : MonoBehaviour
{
    [SerializeField] private Collider2D collider_1;
    [SerializeField] private Collider2D collider_2;
    [SerializeField] private Collider2D collider_3;
    [SerializeField] private Collider2D collider_4;
    [SerializeField] private Collider2D collider_5;
    [SerializeField] private Collider2D collider_6;
    [SerializeField] private Collider2D collider_7;
    [SerializeField] private Collider2D collider_8;
    [SerializeField] private Collider2D collider_9;
    private Battle_tutorial battle_Tutorial;

    private void Start()
    {
        battle_Tutorial = FindObjectOfType<Battle_tutorial>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == collider_1)
        {
            battle_Tutorial.attack_Miss = true;
        }
        else if (collision == collider_2)
        {
            battle_Tutorial.attack_Dam_4_1 = true;
        }
        else if (collision == collider_3)
        {
            battle_Tutorial.attack_Dam_2_1 = true;
        }
        else if (collision == collider_4)
        {
            battle_Tutorial.attack_Dam_15 = true;
        }
        else if (collision == collider_5)
        {
            battle_Tutorial.attack_Dam_2 = true;
        }
        else if (collision == collider_6)
        {
            battle_Tutorial.attack_Dam_15 = true;
        }
        else if (collision == collider_7)
        {
            battle_Tutorial.attack_Dam_2_1 = true;
        }
        else if (collision == collider_8)
        {
            battle_Tutorial.attack_Dam_4_1 = true;
        }
        else if (collision == collider_9)
        {
            battle_Tutorial.attack_Miss = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == collider_1)
        {
            battle_Tutorial.attack_Miss = false;
        }
        else if (collision == collider_2)
        {
            battle_Tutorial.attack_Dam_4_1 = false;
        }
        else if (collision == collider_3)
        {
            battle_Tutorial.attack_Dam_2_1 = false;
        }
        else if (collision == collider_4)
        {
            battle_Tutorial.attack_Dam_15 = false;
        }
        else if (collision == collider_5)
        {
            battle_Tutorial.attack_Dam_2 = false;
        }
        else if (collision == collider_6)
        {
            battle_Tutorial.attack_Dam_15 = false;
        }
        else if (collision == collider_7)
        {
            battle_Tutorial.attack_Dam_2_1 = false;
        }
        else if (collision == collider_8)
        {
            battle_Tutorial.attack_Dam_4_1 = false;
        }
        else if (collision == collider_9)
        {
            battle_Tutorial.attack_Miss = false;
        }
    }
}
