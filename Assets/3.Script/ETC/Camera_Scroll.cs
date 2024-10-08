using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Scroll : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private GamePlay gameplay;
    public bool CameraMove = false;

    private void Start()
    {
        gameplay = FindObjectOfType<GamePlay>();
    }

    void Update()
    {
        if(CameraMove)
        {
            if (transform.position.x >= -55.70f)
            {
                gameplay.isStop = true;
                transform.Translate(Vector3.left * Time.deltaTime * speed) ;
            }
            else
            {
                gameplay.isStop = false;
                CameraMove = false;
            }
        }
    }
}
