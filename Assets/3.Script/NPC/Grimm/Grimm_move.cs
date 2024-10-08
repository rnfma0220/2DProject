using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grimm_move : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Vector3 targetPosition;
    private Animator animator;
    private GamePlay gameplay;
    private Effect_A effect_a;
    private bool isMove_1 = true;
    public bool isMove_2 = false;
    private bool isMove_3 = false;
    public bool isMove_4 = false;
    private bool isMove_5 = false;
    public bool isMove_6 = false;
    public bool isMove_7 = false;
    public bool isMove_8 = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameplay = FindObjectOfType<GamePlay>();
        effect_a = FindObjectOfType<Effect_A>();
    }

    private void Update()
    {
        if(isMove_1)
        {
            targetPosition = new Vector3(-3.5f, 0.5f, 0);
            if(gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_y();
            }
            else
            {
                animator.SetBool("Walking", false);
                isMove_1 = false;
                effect_a.Chat_5 = true;
            }
        }
        if(isMove_2)
        {
            targetPosition = new Vector3(0.15f, 2.0f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_x();
            }
            else
            {
                animator.SetBool("Walking", false);
                isMove_3 = true;
                isMove_2 = false;
            }
        }
        if(isMove_3)
        {
            targetPosition = new Vector3(0.10f, 2.0f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                StartMoveToTarget_x();
                gameplay.isStop = true;
            }
            else
            {
                animator.SetBool("Walking", false);
                effect_a.Chat_7 = true;
                isMove_3 = false;
            }
        }
        if(isMove_4)
        {
            targetPosition = new Vector3(-1.5f, 0.4f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_y();
            }
            else
            {
                animator.SetBool("Walking", false);
                gameplay.isStop = false;
                isMove_5 = true;
                isMove_4 = false;
            }
        }
        if (isMove_5)
        {
            targetPosition = new Vector3(-1.5f, 0.5f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_y();
            }
            else
            {
                animator.SetBool("Walking", false);
                gameplay.isStop = false;
                isMove_5 = false;
            }
        }
        if (isMove_6)
        {
            targetPosition = new Vector3(-2f, 0.5f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_x();
            }
            else
            {
                animator.SetBool("Walking", false);
                gameplay.isStop = false;
                isMove_6 = false;
            }
        }
        if (isMove_7)
        {
            targetPosition = new Vector3(-1.9f, 0.5f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_x();
            }
            else
            {
                animator.SetBool("Walking", false);
                gameplay.isStop = false;
                isMove_7 = false;
            }
        }
        if (isMove_8)
        {
            targetPosition = new Vector3(-5f, 2f, 0);
            if (gameObject.transform.position != targetPosition)
            {
                animator.SetBool("Walking", true);
                gameplay.isStop = true;
                StartMoveToTarget_x();
            }
            else
            {
                AudioManager.instance.Play("Door_Open");
                animator.SetBool("Walking", false);
                effect_a.Chat_9 = true;
                isMove_8 = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void StartMoveToTarget_y()
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

    public void StartMoveToTarget_x()
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

        if (transform.position.x == targetPosition.x)
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
        }
    }
}
