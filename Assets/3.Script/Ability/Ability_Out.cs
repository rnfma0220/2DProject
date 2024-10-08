using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability_Out : MonoBehaviour
{
    public Text SoulText;
    public Text HPText;
    public Text DamageText;
    public Text Speed;
    public Text DEF;
    public Text Skill;

    private void Start()
    {
        SoulText.text = PlayerManager.instance.Soul.ToString();
        HPText.text = PlayerManager.instance.Max_HP.ToString();
        DamageText.text = PlayerManager.instance.Damage.ToString();
        Speed.text = PlayerManager.instance.Speed.ToString();
        DEF.text = PlayerManager.instance.DEF.ToString();
        Skill.text = PlayerManager.instance.Skill.ToString();
    }

    public void upgrade()
    {
        SoulText.text = PlayerManager.instance.Soul.ToString();
        HPText.text = PlayerManager.instance.Max_HP.ToString();
        DamageText.text = PlayerManager.instance.Damage.ToString();
        Speed.text = PlayerManager.instance.Speed.ToString();
        DEF.text = PlayerManager.instance.DEF.ToString();
        Skill.text = PlayerManager.instance.Skill.ToString();
    }
}
