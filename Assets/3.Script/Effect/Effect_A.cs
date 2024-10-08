using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_A : MonoBehaviour
{
    [SerializeField] private float speed = 1.8f;

    [SerializeField] GameObject Text;
    [SerializeField] GameObject Text_1;
    [SerializeField] GameObject Text_2;
    [SerializeField] GameObject Text_3;
    [SerializeField] GameObject Text_4;
    [SerializeField] GameObject Tile;
    [SerializeField] GameObject Tile_1;
    [SerializeField] GameObject Tile_2;
    [SerializeField] GameObject Tile_3;
    [SerializeField] GameObject Tile_4;
    [SerializeField] GameObject Tile_5;
    [SerializeField] GameObject Player_1;
    [SerializeField] GameObject Player_2;

    private FadeController fadeController;
    private GamePlay gameplay;
    public bool isChat = true;
    public bool Chat_1 = false;
    public bool Chat_2 = false;
    public bool Chat_3 = false;
    public bool Chat_4 = false;
    public bool Chat_5 = false;
    public bool Chat_6 = false;
    public bool Chat_7 = false;
    public bool Chat_8 = false;
    public bool Chat_9 = false;
    public bool Chat_10 = false;

    private void Start()
    {
        TryGetComponent(out gameplay);
        fadeController = FindObjectOfType<FadeController>();
        if (fadeController == null)
        {
            Debug.LogError("Null!!");
        }
    }

    private void Update()
    {

        if (isChat)
        {
            if (Tile.transform.localScale.y < 1.0f)
            {
                gameplay.isStop = true;

                float newY = Tile.transform.localScale.y + speed * Time.deltaTime;

                newY = Mathf.Min(newY, 1.0f);

                Tile.transform.localScale = new Vector3(Tile.transform.localScale.x, newY, Tile.transform.localScale.z);
            }
            if (Tile.transform.localScale.y == 1.0f)
            {
                Text.SetActive(true);
                gameplay.isStop = false;
            }
        }
        else
        {
            if (Tile.transform.localScale.y > 0.0f)
            {
                float newY = Tile.transform.localScale.y - speed * Time.deltaTime;
                newY = Mathf.Max(newY, 0.0f);
                Tile.transform.localScale = new Vector3(Tile.transform.localScale.x, newY, Tile.transform.localScale.z);
                gameplay.isStop = false;
            }
        }

        if (fadeController.isFadeing) return;

        if (Chat_1)
        {
            if (Tile_1.transform.localScale.y < 1.0f)
            {
                gameplay.isStop = true;

                float newY = Tile_1.transform.localScale.y + speed * Time.deltaTime;

                newY = Mathf.Min(newY, 1.0f);

                Tile_1.transform.localScale = new Vector3(Tile_1.transform.localScale.x, newY, Tile_1.transform.localScale.z);
            }
            if (Tile_1.transform.localScale.y == 1.0f)
            {
                Text_1.SetActive(true);
                gameplay.isStop = false;
            }
        }

        if (Chat_2)
        {
            if (Tile_1.transform.localScale.y > 0.0f)
            {
                float newY = Tile_1.transform.localScale.y - speed * Time.deltaTime;
                newY = Mathf.Max(newY, 0.0f);
                Tile_1.transform.localScale = new Vector3(Tile_1.transform.localScale.x, newY, Tile_1.transform.localScale.z);
            }
            if (Tile_1.transform.localScale.y == 0f)
            {
                Chat_2 = false;
            }
        }

        if (Chat_3)
        {
            if (Tile_2.transform.localScale.y < 1.0f)
            {
                float newY = Tile_2.transform.localScale.y + speed * Time.deltaTime;

                newY = Mathf.Min(newY, 1.0f);

                Tile_2.transform.localScale = new Vector3(Tile_2.transform.localScale.x, newY, Tile_2.transform.localScale.z);
            }
            if (Tile_2.transform.localScale.y == 1.0f)
            {
                gameplay.isStop = false;
                Chat_3 = false;
            }
        }

        if (Chat_4)
        {
            if (Tile_2.transform.localScale.y > 0.0f)
            {
                gameplay.isStop = true;
                float newY = Tile_2.transform.localScale.y - speed * Time.deltaTime;
                newY = Mathf.Max(newY, 0.0f);
                Tile_2.transform.localScale = new Vector3(Tile_2.transform.localScale.x, newY, Tile_2.transform.localScale.z);
            }
            if (Tile_2.transform.localScale.y == 0f)
            {
                Chat_4 = false;
                gameplay.isStop = false;
            }
        }

        if (Chat_5)
        {
            if (Tile_3.transform.localScale.y < 1.0f)
            {
                float newY = Tile_3.transform.localScale.y + speed * Time.deltaTime;

                newY = Mathf.Min(newY, 1.0f);

                Tile_3.transform.localScale = new Vector3(Tile_3.transform.localScale.x, newY, Tile_3.transform.localScale.z);
            }
            if (Tile_3.transform.localScale.y == 1.0f)
            {
                gameplay.isStop = false;
                Text_2.SetActive(true);
                Chat_5 = false;
            }
        }

        if (Chat_6)
        {
            if (Tile_3.transform.localScale.y > 0.0f)
            {
                gameplay.isStop = true;
                float newY = Tile_3.transform.localScale.y - speed * Time.deltaTime;
                newY = Mathf.Max(newY, 0.0f);
                Tile_3.transform.localScale = new Vector3(Tile_3.transform.localScale.x, newY, Tile_3.transform.localScale.z);
            }
            if (Tile_3.transform.localScale.y == 0f)
            {
                Chat_6 = false;
            }
        }

        if (Chat_7)
        {
            if (Tile_4.transform.localScale.y < 1.0f)
            {
                float newY = Tile_4.transform.localScale.y + speed * Time.deltaTime;
                newY = Mathf.Min(newY, 1.0f);
                Tile_4.transform.localScale = new Vector3(Tile_3.transform.localScale.x, newY, Tile_4.transform.localScale.z);
            }
            if (Tile_4.transform.localScale.y == 1.0f)
            {
                Text_3.SetActive(true);
                Player_1.SetActive(false);
                Player_2.SetActive(true);
                gameplay.isStop = false;
                Chat_7 = false;
            }
        }

        if (Chat_8)
        {
            if (Tile_4.transform.localScale.y > 0.0f)
            {
                float newY = Tile_4.transform.localScale.y - speed * Time.deltaTime;
                newY = Mathf.Max(newY, 0.0f);
                Tile_4.transform.localScale = new Vector3(Tile_4.transform.localScale.x, newY, Tile_4.transform.localScale.z);
            }
            if (Tile_4.transform.localScale.y == 0f)
            {
                Chat_8 = false;
            }
        }

        if (Chat_9)
        {
            if (Tile_5.transform.localScale.y < 1.0f)
            {
                float newY = Tile_5.transform.localScale.y + speed * Time.deltaTime;
                newY = Mathf.Min(newY, 1.0f);
                Tile_5.transform.localScale = new Vector3(Tile_5.transform.localScale.x, newY, Tile_5.transform.localScale.z);
            }
            if (Tile_5.transform.localScale.y == 1.0f)
            {
                gameplay.isStop = false;
                Text_4.SetActive(true);
                Chat_9 = false;
            }
        }

        if (Chat_10)
        {
            if (Tile_5.transform.localScale.y > 0.0f)
            {
                gameplay.isStop = true;
                float newY = Tile_5.transform.localScale.y - speed * Time.deltaTime;
                newY = Mathf.Max(newY, 0.0f);
                Tile_5.transform.localScale = new Vector3(Tile_5.transform.localScale.x, newY, Tile_5.transform.localScale.z);
            }
            if (Tile_5.transform.localScale.y == 0f)
            {
                gameplay.isStop = false;
                Chat_10 = false;
                
            }
        }
    }
}