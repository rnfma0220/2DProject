using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBack_Loop : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    private float y;

    void Start()
    {
        y = transform.GetComponent<BoxCollider2D>().size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y >= 11)
        {
            Vector2 offset = new Vector2(0, 2.0f * -y);
            transform.position = (Vector2)transform.position + offset;
        }
    }
}
