using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map008_Ghost : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Vector3 targetPosition;
    private Animator animator;
    private bool isNpcMove1 = false;

    private void Start()
    {
        TryGetComponent(out animator);
    }

    private void Update()
    {
        if (!isNpcMove1)
        {
            targetPosition = new Vector3(-1.23f, 2.6f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                StartMoveToTarget();
            }
            else
            {
                animator.SetBool("Walking", false);
                isNpcMove1 = true;
            }
        }
    }

    private void StartMoveToTarget()
    {
        float stepY = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPosition.y, 0f), stepY);
        float DirY = targetPosition.y - transform.position.y;
        if (DirY > 0)
        {
            animator.SetFloat("DirX", 0f);
            animator.SetFloat("DirY", 1f);
        }
        else if (DirY < 0)
        {
            animator.SetFloat("DirX", 0f);
            animator.SetFloat("DirY", -1f);
        }

        if (transform.position.y == targetPosition.y)
        {
            float stepX = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, transform.position.y, 0f), stepX);
            float DirX = targetPosition.x - transform.position.x;

            if (DirX > 0)
            {
                animator.SetFloat("DirY", 0f);
                animator.SetFloat("DirX", 1f);
            }
            else if (DirX < 0)
            {
                animator.SetFloat("DirY", 0f);
                animator.SetFloat("DirX", -1f);
            }
        }
    }
}
