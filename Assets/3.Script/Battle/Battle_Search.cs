using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Search : MonoBehaviour
{
    private Battle_Ghastling ghastling;
    public Text HP;
    public Text Max_HP;
    public Text Dam;
    public Text DEF;
    public Text Speed;

    private void Start()
    {
        TryGetComponent(out ghastling);
    }

    public void Search()
    {
        HP.text = ghastling.Mob_HP.ToString();
        Max_HP.text = ghastling.Mob_Max_HP.ToString();
        Dam.text = ghastling.Damage.ToString();
        DEF.text = ghastling.DEF.ToString();
        Speed.text = ghastling.Speed.ToString();
    }
}
