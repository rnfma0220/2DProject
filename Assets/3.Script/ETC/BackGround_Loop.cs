using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Loop : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private float width;

    void Start()
    {
        width = transform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.x >= 18.24)
        {
            Vector2 offset = new Vector2(-width * 2.99f, 0);
            transform.position = (Vector2)transform.position + offset;
        }
    }
}
