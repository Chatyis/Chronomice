using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

    [SerializeField]
    private GameObject[] patrolPoints;
    [SerializeField]
    private float speed = 15f;
    [SerializeField] 
    private float attackingSpeed = 30f;
    [SerializeField]
    private bool isFlying;
    [SerializeField]
    private PlayerDetectorController playerDetector;

    private Rigidbody2D rb;
    private int currentTargetIndex;
    private bool chasingPlayer;
    private Transform playerTransform;
    private PlayerController playerController;
    private Animator _animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = FindFirstObjectByType<PlayerController>();
        _animator = GetComponent<Animator>();
        playerController.playerDeath.AddListener(()=>
        {
            speed = 15f;
            chasingPlayer = false;
            _animator.SetBool(IsAttacking, false);
            transform.position = patrolPoints[currentTargetIndex].transform.position;
        });
        
        if (playerDetector)
        {
            playerDetector.playerDetected.AddListener(()=>
            {
                if (!playerController.isHiddenInBush)
                {
                    TargetPlayer();
                }
            });
        }

        if (isFlying)
        {
            rb.gravityScale = 0;
        }
    }
    
    void Update()
    {
        Vector2 targetPosition = chasingPlayer ? playerTransform.position : patrolPoints[currentTargetIndex].transform.position;
        Vector2 direction = (targetPosition - rb.position).normalized;
        
            
        if (targetPosition.x >= rb.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTarget"))
        {
            if(currentTargetIndex < patrolPoints.Length - 1)
            {
                currentTargetIndex++;
            }
            else
            {
                currentTargetIndex = 0;
            }
        }    
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.Die(true);
        }
    }
    
    private void TargetPlayer()
    {
        speed = attackingSpeed;
        chasingPlayer = true;
        _animator.SetBool(IsAttacking, true);
    }
}
