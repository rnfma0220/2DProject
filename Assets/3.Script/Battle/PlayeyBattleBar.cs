using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeyBattleBar : MonoBehaviour
{
    [SerializeField] private Slider HPBar;
    [SerializeField] private Slider MPBar;
    [SerializeField] private Slider TimeBar;
    [SerializeField] private Text hp;
    [SerializeField] private Text mp;
    private float HP;
    private float Max_HP;
    private float MP;
    private float Max_MP;

    private void Update()
    {
        hp.text = PlayerManager.instance.HP.ToString();
        mp.text = PlayerManager.instance.MP.ToString();

        HP = PlayerManager.instance.HP;
        Max_HP = PlayerManager.instance.Max_HP;
        MP = PlayerManager.instance.MP;
        Max_MP = PlayerManager.instance.Max_MP;

        HPBar.value = HP;
        HPBar.maxValue = Max_HP;
        MPBar.value = MP;
        MPBar.maxValue = Max_MP;
        TimeBar.maxValue = 5;

        float fillAmount = PlayerManager.instance.Speed * Time.deltaTime; 
        TimeBar.value += fillAmount;
    }
}

