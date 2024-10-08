using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStartPoint : MonoBehaviour
{
    [SerializeField] private string StartPoint;
    private PlayerControll playercontroll;
    private CameraManger cameramanger;

    void Start()
    {
        playercontroll = FindObjectOfType<PlayerControll>();
        cameramanger = FindObjectOfType<CameraManger>();

        if (StartPoint == PlayerManager.instance.MapName)
        {
            cameramanger.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, cameramanger.transform.position.z);
            playercontroll.transform.position = this.transform.position;
        }
    }
}
