using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    #region Object
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Npc_1;
    [SerializeField] private GameObject Npc_2;
    [SerializeField] private GameObject Npc_3;
    [SerializeField] private GameObject Npc_4;
    [SerializeField] private GameObject Npc_5;
    [SerializeField] private GameObject Npc_6;
    [SerializeField] private GameObject Npc_7;
    [SerializeField] private GameObject Npc_8;
    [SerializeField] private GameObject Npc_9;
    [SerializeField] private GameObject Npc_10;
    [SerializeField] private GameObject Npc_1_1;
    [SerializeField] private GameObject Npc_2_1;
    [SerializeField] private GameObject Npc_3_1;
    [SerializeField] private GameObject Npc_4_1;
    [SerializeField] private GameObject Npc_5_1;
    [SerializeField] private GameObject Npc_6_1;
    [SerializeField] private GameObject Npc_7_1;
    [SerializeField] private GameObject Npc_8_1;
    [SerializeField] private GameObject Npc_9_1;
    [SerializeField] private GameObject Npc_10_1;
    [SerializeField] private GameObject Player_1;
    [SerializeField] private GameObject Player_2;
    [SerializeField] private GameObject Lavender_1;
    [SerializeField] private GameObject Lavender_2;
    [SerializeField] private GameObject Lavender_3;
    [SerializeField] private GameObject Lavender_4;
    [SerializeField] private GameObject Door_1;
    [SerializeField] private GameObject Door_2;
    [SerializeField] private GameObject NPC_1;
    [SerializeField] private GameObject NPC_1_1;
    [SerializeField] private GameObject NPC_2;
    [SerializeField] private GameObject NPC_2_1;
    [SerializeField] private GameObject NPC_3;
    [SerializeField] private GameObject NPC_3_1;
    [SerializeField] private GameObject NPC_4;
    [SerializeField] private GameObject NPC_4_1;
    [SerializeField] private GameObject Grimm;
    [SerializeField] private GameObject Chat_1;
    [SerializeField] private GameObject Chat_2;
    [SerializeField] private GameObject Chat_3;
    [SerializeField] private GameObject Chat_4;
    [SerializeField] private GameObject Chat_5;
    [SerializeField] private GameObject Chat_6;
    [SerializeField] private GameObject Chat_7;
    [SerializeField] private GameObject Chat_8;
    [SerializeField] private GameObject Chat_9;
    [SerializeField] private GameObject Chat_10;
    [SerializeField] private GameObject Chat_11;
    [SerializeField] private GameObject Chat_12;
    [SerializeField] private GameObject Chat_13;
    [SerializeField] private GameObject Chat_14;
    [SerializeField] private GameObject Chat_15;
    [SerializeField] private GameObject Chat_16;
    [SerializeField] private GameObject Chat_17;
    [SerializeField] private GameObject Chat_18;
    [SerializeField] private GameObject Chat_19;
    [SerializeField] private GameObject Chat_20;
    [SerializeField] private GameObject Chat_21;
    [SerializeField] private GameObject Chat_22;
    [SerializeField] private GameObject Chat_23;
    [SerializeField] private GameObject Chat_24;
    [SerializeField] private GameObject Chat_25;
    [SerializeField] private GameObject Chat_26;
    [SerializeField] private GameObject Chat_27;
    [SerializeField] private GameObject Chat_28;
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject Text_1;
    [SerializeField] private GameObject Text_2;
    [SerializeField] private GameObject Text_3;
    [SerializeField] private GameObject Text_4;
    [SerializeField] private GameObject Text_5;
    [SerializeField] private GameObject Text_6;
    [SerializeField] private GameObject Text_7;
    [SerializeField] private GameObject Text_8;
    [SerializeField] private GameObject Text_9;
    [SerializeField] private GameObject Text_10;
    [SerializeField] private GameObject Text_11;
    [SerializeField] private GameObject Text_12;
    [SerializeField] private GameObject Text_13;
    [SerializeField] private GameObject Text_14;
    [SerializeField] private GameObject Text_15;
    [SerializeField] private GameObject Text_16;
    [SerializeField] private GameObject Text_17;
    [SerializeField] private GameObject Text_18;
    [SerializeField] private GameObject Text_19;
    [SerializeField] private GameObject Text_20;
    [SerializeField] private GameObject Text_21;
    [SerializeField] private GameObject Text_22;
    [SerializeField] private GameObject Text_23;
    [SerializeField] private GameObject Text_24;
    [SerializeField] private GameObject background;
    #endregion

    private FadeController fadeController;
    private Grimm_move grimm_move;
    private Effect_A effect_a;
    private Camera_Scroll camera_scroll;
    private PlayerControll playerControll;
    private AudioSource source;

    #region Chat
    private bool isCamera = false;
    private bool isCamera2 = false;
    public bool isStop = false;
    private bool isChat1 = false;
    private bool isChat2 = false;
    private bool isChat3 = false;
    private bool isChat4 = false;
    private bool isChat5 = false;
    private bool isChat6 = false;
    private bool isChat7 = false;
    private bool isChat8 = false;
    private bool isChat9 = false;
    private bool isChat10 = true;
    private bool isChat11 = false;
    private bool isChat12 = false;
    private bool isChat13 = false;
    private bool isChat14 = false;
    private bool isChat15 = false;
    private bool isChat16 = false;
    private bool isChat17 = true;
    private bool isChat18 = false;
    private bool isChat19 = false;
    private bool isChat20 = false;
    private bool isChat21 = false;
    private bool isChat22 = false;
    private bool isChat23 = false;
    private bool isChat24 = false;
    private bool isChat25 = false;
    private bool isChat26 = false;
    private bool isChat27 = true;
    private bool isChat28 = true;
    private bool isChat29 = false;
    private bool isChat30 = false;
    private bool isChat31 = false;
    private bool isChat32 = false;
    private bool isChat33 = false;
    private bool isChat34 = false;
    private bool isChat35 = false;
    private bool isChat36 = false;
    private bool isChat37 = false;
    private bool isChat38 = false;
    private bool isChat39 = false;
    private bool isChat40 = false;
    private bool isChat41 = false;
    private bool isChat42 = false;
    private bool isChat43 = false;
    private bool isChat44 = false;
    private bool isChat45 = false;
    private bool isChat46 = false;
    private bool isChat47 = false;
    private bool isChat48 = false;
    private bool isChat49 = false;
    private bool isChat50 = true;
    #endregion

    private void Start()
    {
        TryGetComponent(out effect_a);
        TryGetComponent(out source);
        fadeController = FindObjectOfType<FadeController>();
        camera_scroll = FindObjectOfType<Camera_Scroll>();
        playerControll = FindObjectOfType<PlayerControll>();
        grimm_move = FindObjectOfType<Grimm_move>();
    }
    private void Update()
    {
        if (fadeController.isFadeing) return;

        if (isCamera)
        {
            if (Camera.transform.position.y > -0.25f)
            {
                isStop = true;
                float newY = Camera.transform.position.y - 1.0f * Time.deltaTime;
                newY = Mathf.Max(newY, -0.25f);
                Camera.transform.position = new Vector3(Camera.transform.position.x, newY, Camera.transform.position.z);
            }
            if (Camera.transform.position.y == -0.25f)
            {
                isCamera = false;
                effect_a.Chat_3 = true;
                isChat9 = true;
                isChat10 = false;
            }
        }

        if(isCamera2)
        {
            if (Camera.transform.position.y <= 2f)
            {
                isStop = true;
                Camera.transform.Translate(Vector3.up * Time.deltaTime * 1.0f);
            }
            else
            {
                isCamera2 = false;
                isStop = false;
                isChat50 = false;
            }
        }

        if(!isChat50)
        {
            SceneManager.LoadScene("Map001");
            playerControll.NotMove = false;
        }

        if (!isChat27)
        {
            Npc_1.SetActive(false);
            Npc_2.SetActive(false);
            Npc_3.SetActive(false);
            Npc_4.SetActive(false);
            Npc_5.SetActive(false);
            Npc_6.SetActive(false);
            Npc_7.SetActive(false);
            Npc_8.SetActive(false);
            Npc_9.SetActive(false);
            Npc_10.SetActive(false);
            Npc_1_1.SetActive(true);
            Npc_2_1.SetActive(true);
            Npc_3_1.SetActive(true);
            Npc_4_1.SetActive(true);
            Npc_5_1.SetActive(true);
            Npc_6_1.SetActive(true);
            Npc_7_1.SetActive(true);
            Npc_8_1.SetActive(true);
            Npc_9_1.SetActive(true);
            Npc_10_1.SetActive(true);
            isChat28 = false;
            isChat27 = true;
        }

        if (!isChat28)
        {
            if (!Npc_10_1.activeSelf)
            {
                grimm_move = FindObjectOfType<Grimm_move>();
                Door_2.SetActive(false);
                Door_1.SetActive(true);
                isStop = false;
                grimm_move.isMove_2 = true;
                isChat28 = true;
            }
        }

        if (isStop) return;

        if (!isChat10)
        {
            Chat_5.SetActive(true);
            isChat10 = true;
        }

        if(!isChat17)
        {
            Door_1.SetActive(false);
            Door_2.SetActive(true);
            AudioManager.instance.Play("Door_Open");
            Grimm.SetActive(true);
            NPC_1.SetActive(false);
            NPC_1_1.SetActive(true);
            NPC_2.SetActive(false);
            NPC_2_1.SetActive(true);
            NPC_3.SetActive(false);
            NPC_3_1.SetActive(true);
            NPC_4.SetActive(false);
            NPC_4_1.SetActive(true);
            source.Play();
            isChat17 = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (!isChat1)
            {
                Text.SetActive(false);
                fadeController.FadeIn();
                background.SetActive(false);
                source.Play();
                effect_a.isChat = false;
                effect_a.Chat_1 = true;
                isChat1 = true;
            }
            else if (!isChat2)
            {
                Text_1.SetActive(false);
                Text_2.SetActive(true);
                effect_a.Chat_1 = false;
                isChat2 = true;
            }
            else if (!isChat3)
            {
                Chat_1.SetActive(false);
                Text_2.SetActive(false);
                Chat_2.SetActive(true);
                isChat3 = true;
            }
            else if (!isChat4)
            {
                Lavender_1.SetActive(false);
                Lavender_2.SetActive(true);
                Text_3.SetActive(false);
                Text_4.SetActive(true);
                isChat4 = true;
            }
            else if (!isChat5)
            {
                Chat_2.SetActive(false);
                Chat_3.SetActive(true);
                isChat5 = true;
            }
            else if (!isChat6)
            {
                Chat_3.SetActive(false);
                Chat_4.SetActive(true);
                isChat6 = true;
            }
            else if (!isChat7)
            {
                Lavender_3.SetActive(false);
                Lavender_4.SetActive(true);
                Text_5.SetActive(false);
                Text_6.SetActive(true);
                isChat7 = true;
            }
            else if (!isChat8)
            {
                Text_7.SetActive(true);
                isChat8 = true;
            }
            else if (!isChat9)
            {
                Chat_4.SetActive(false);
                effect_a.Chat_2 = true;
                isCamera = true;
            }
            else if (!isChat11)
            {
                Chat_5.SetActive(false);
                Chat_6.SetActive(true);
                isChat11 = true;
            }
            else if (!isChat12)
            {
                Chat_6.SetActive(false);
                Chat_7.SetActive(true);
                isChat12 = true;
            }
            else if (!isChat13)
            {
                Text_8.SetActive(false);
                Text_9.SetActive(true);
                isChat13 = true;
            }
            else if (!isChat14)
            {
                Chat_7.SetActive(false);
                Chat_8.SetActive(true);
                source.Stop();
                isChat14 = true;
            }
            else if (!isChat15)
            {
                Chat_8.SetActive(false);
                Chat_9.SetActive(true);
                isChat15 = true;
            }
            else if (!isChat16)
            {
                Chat_9.SetActive(false);
                effect_a.Chat_4 = true;
                isChat16 = true;
                isChat17 = false;
            }
            else if (!isChat18)
            {
                Chat_10.SetActive(false);
                Chat_11.SetActive(true);
                isChat18 = true;
            }
            else if (!isChat19)
            {
                Chat_11.SetActive(false);
                Chat_12.SetActive(true);
                isChat19 = true;
            }
            else if (!isChat20)
            {
                Text_10.SetActive(false);
                Text_11.SetActive(true);
                isChat20 = true;
            }
            else if (!isChat21)
            {
                Text_11.SetActive(false);
                Text_12.SetActive(true);
                isChat21 = true;
            }
            else if (!isChat22)
            {
                Chat_12.SetActive(false);
                Chat_13.SetActive(true);
                isChat22 = true;
            }
            else if (!isChat23)
            {
                Chat_13.SetActive(false);
                Chat_14.SetActive(true);
                isChat23 = true;
            }
            else if (!isChat24)
            {
                Chat_14.SetActive(false);
                Chat_15.SetActive(true);
                isChat24 = true;
            }
            else if (!isChat25)
            {
                Chat_15.SetActive(false);
                Chat_16.SetActive(true);
                isChat25 = true;
            }
            else if (!isChat26)
            {
                Chat_16.SetActive(false);
                source.Stop();
                effect_a.Chat_6 = true;
                isChat27 = false;
                isChat26 = true;
            }
            else if (!isChat29)
            {
                AudioManager.instance.Play("Npc_Exit");
                Chat_17.SetActive(false);
                Chat_18.SetActive(true);
                isChat29 = true;
            }
            else if (!isChat30)
            {
                Chat_18.SetActive(false);
                Chat_19.SetActive(true);
                isChat30 = true;
            }
            else if (!isChat31)
            {
                AudioManager.instance.Stop("Npc_Exit");
                Chat_19.SetActive(false);
                Chat_20.SetActive(true);
                isChat31 = true;
            }
            else if (!isChat32)
            {
                Chat_20.SetActive(false);
                Chat_21.SetActive(true);
                isChat32 = true;
            }
            else if (!isChat33)
            {
                Chat_21.SetActive(false);
                Chat_22.SetActive(true);
                isChat33 = true;
            }
            else if (!isChat34)
            {
                AudioManager.instance.Play("Story_1");
                Chat_22.SetActive(false);
                Chat_23.SetActive(true);
                isChat34 = true;
            }
            else if (!isChat35)
            {
                Chat_23.SetActive(false);
                Camera.transform.position = new Vector3(-47.13f, 11.90f, -10f);
                camera_scroll.CameraMove = true;
                Text_13.SetActive(true);
                isChat35 = true;
            }
            else if (!isChat36)
            {
                Text_13.SetActive(false);
                Camera.transform.position = new Vector3(-0.5f, -0.25f, -10f);
                Chat_24.SetActive(true);
                isChat36 = true;
            }
            else if (!isChat37)
            {
                Chat_24.SetActive(false);
                Chat_25.SetActive(true);
                isChat37 = true;
            }
            else if(!isChat38)
            {
                Text_14.SetActive(false);
                Text_15.SetActive(true);
                isChat38 = true;
            }
            else if (!isChat39)
            {
                Text_15.SetActive(false);
                Text_16.SetActive(true);
                isChat39 = true;
            }
            else if (!isChat40)
            {
                Text_16.SetActive(false);
                grimm_move.isMove_4 = true;
                Player_2.SetActive(false);
                Player_1.SetActive(true);
                Text_17.SetActive(true);
                isChat40 = true;
            }
            else if (!isChat41)
            {
                Text_17.SetActive(false);
                Text_18.SetActive(true);
                isChat41 = true;
            }
            else if (!isChat42)
            {
                grimm_move.isMove_6 = true;
                Chat_25.SetActive(false);
                Chat_26.SetActive(true);
                isChat42 = true;
            }
            else if (!isChat43)
            {
                grimm_move.isMove_7 = true;
                Text_19.SetActive(false);
                Text_20.SetActive(true);
                isChat43 = true;
            }
            else if (!isChat44)
            {
                Chat_26.SetActive(false);
                Chat_27.SetActive(true);
                isChat44 = true;
            }
            else if (!isChat45)
            {
                Text_21.SetActive(false);
                Text_22.SetActive(true);
                isChat45 = true;
            }
            else if(!isChat46)
            {
                Chat_27.SetActive(false);
                AudioManager.instance.Stop("Story_1");
                effect_a.Chat_8 = true;
                grimm_move.isMove_8 = true;
                isChat46 = true;
            }
            else if(!isChat47)
            {
                effect_a.Chat_9 = true;
                isChat47 = true;
            }
            else if(!isChat48)
            {
                Text_23.SetActive(false);
                Text_24.SetActive(true);
                isChat48 = true;
            }
            else if (!isChat49)
            {
                Chat_28.SetActive(false);
                isCamera2 = true;
                effect_a.Chat_10 = true;
            }
        }
    }
}
