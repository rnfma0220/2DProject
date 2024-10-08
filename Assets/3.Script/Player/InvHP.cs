using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvHP : MonoBehaviour
{
    [SerializeField] private Slider HPBar;
    [SerializeField] private Slider MPBar;

    [SerializeField] private Text hp;
    [SerializeField] private Text mp;
    [SerializeField] private Text max_hp;
    [SerializeField] private Text max_mp;

    private float HP;
    private float Max_HP;
    private float MP;
    private float Max_MP;

    private void Update()
    {
        hp.text = PlayerManager.instance.HP.ToString();
        max_hp.text = PlayerManager.instance.Max_HP.ToString();
        mp.text = PlayerManager.instance.MP.ToString();
        max_mp.text = PlayerManager.instance.Max_MP.ToString();

        HP = PlayerManager.instance.HP;
        Max_HP = PlayerManager.instance.Max_HP;
        MP = PlayerManager.instance.MP;
        Max_MP = PlayerManager.instance.Max_MP;

        HPBar.value = HP;
        HPBar.maxValue = Max_HP;
        MPBar.value = MP;
        MPBar.maxValue = Max_MP;
    }

}
