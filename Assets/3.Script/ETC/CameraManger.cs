using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float Speed;
    [SerializeField] private BoxCollider2D ground;
    private Vector3 minground;
    private Vector3 maxground;
    private float halfWidth;
    private float halfHeight;
    private Camera _camera;
    private Vector3 targetPosition;
    public static CameraManger instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        TryGetComponent(out _camera);
        minground = ground.bounds.min;
        maxground = ground.bounds.max;
        halfHeight = _camera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    private void Update()
    {
        if (target == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            target = playerObject;
        }

        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Speed * Time.deltaTime);

            float ClampX = Mathf.Clamp(this.transform.position.x, minground.x + halfWidth, maxground.x - halfWidth);
            float ClampY = Mathf.Clamp(this.transform.position.y, minground.y + halfHeight, maxground.y - halfHeight);

            this.transform.position = new Vector3(ClampX, ClampY, transform.position.z);
        }
    }
    
    public void Setbound(BoxCollider2D newground)
    {
        ground = newground;
        minground = ground.bounds.min;
        maxground = ground.bounds.max;
    }

}
