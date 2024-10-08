using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeyBar : MonoBehaviour
{
    [SerializeField] private Slider HPBar;
    [SerializeField] private Slider MPBar;
    [SerializeField] private Text Max_hp;
    [SerializeField] private Text hp;
    [SerializeField] private Text Max_mp;
    [SerializeField] private Text mp;
    [SerializeField] private Text Soul;
    private float Max_HP;
    private float HP;
    private float Max_MP;
    private float MP;

    private void OnEnable()
    {
        Soul.text = PlayerManager.instance.Soul.ToString();
        Max_hp.text = PlayerManager.instance.Max_HP.ToString();
        hp.text = PlayerManager.instance.HP.ToString();
        Max_mp.text = PlayerManager.instance.Max_MP.ToString();
        mp.text = PlayerManager.instance.MP.ToString();

        Max_HP = PlayerManager.instance.Max_HP;
        HP = PlayerManager.instance.HP;
        Max_MP = PlayerManager.instance.Max_MP;
        MP = PlayerManager.instance.MP;

        HPBar.maxValue = Max_HP;
        HPBar.value = HP;
        MPBar.value = Max_MP;
        MPBar.value = MP;
    }
}
