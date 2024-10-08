using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float Move_Speed = 30f;
    //[SerializeField] private Vector3 Move;
    [SerializeField] private LayerMask obstacleLayer;
    public static PlayerControll instance = null;
    private float x;
    private float y;
    public bool Reaper;
    public bool Lavender;
    public bool NotMove;
    public float DirY;

    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private Animator animator;
    private AudioSource audioSource;
    private PlayerManager playerManager;

    private void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            TryGetComponent(out animator);
            TryGetComponent(out rb);
            TryGetComponent(out playerCollider);
            TryGetComponent(out audioSource);
            TryGetComponent(out playerManager);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Reaper)
        {
            animator.runtimeAnimatorController = playerManager.newAnimatorController;
            PlayerManager.instance.Reaper_P = true;
            Reaper = false;
        }

        if (Lavender)
        {
            animator.runtimeAnimatorController = PlayerManager.instance.oldAnimatorController;
            PlayerManager.instance.Reaper_P = false;
            Lavender = false;
        }

        if (!NotMove)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            x = 0;
            y = 0;
        }

        if (x != 0 || y != 0)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("DirX", x);
            animator.SetFloat("DirY", y);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        DirY = animator.GetFloat("DirY");
    }

    private void FixedUpdate()
    {
        Move(new Vector2(x, y));
    }

    private void Move(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, direction.y, 0);
        Vector3 potentialPosition = transform.position + move * Move_Speed * Time.fixedDeltaTime;

        if (!IsObstacleAhead(potentialPosition))
        {
            rb.MovePosition(potentialPosition);
        }
    }

    private bool IsObstacleAhead(Vector3 potentialPosition)
    {
        Bounds bounds = playerCollider.bounds;
        Vector3 newPosition = bounds.center + (Vector3)(potentialPosition - transform.position);
        bounds.center = newPosition;

        Collider2D hit = Physics2D.OverlapBox(bounds.center, bounds.size, 0f, obstacleLayer);
        return hit != null;
    }

    public void MoveEvent()
    {
        float stepY = 1.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1.0f, 0f), stepY);
        float DirY = 1.0f - transform.position.y;
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

    public void MoveEvent_1()
    {
        float stepX = 1.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.7f, transform.position.y, 0f), stepX);
        float DirX = -1.7f - transform.position.x;

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

    public void MoveEvent_2()
    {
        float stepX = 1.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.69f, transform.position.y, 0f), stepX);
        float DirX = -1.69f - transform.position.x;

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
