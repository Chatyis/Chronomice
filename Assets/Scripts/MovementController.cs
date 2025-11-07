using System;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Rigidbody2D rb;
    
    public Rigidbody2D Rb => rb;
    public UnityEvent playerJump;
    public UnityEvent playerLanding;
    public UnityEvent playerInAirChanged;
    
    private bool _inAir;

    public bool InAir
    {
        get => _inAir;
        private set
        {
            _inAir = value;
            playerInAirChanged.Invoke();
        }
    }

    private void Awake()
    {
        GroundedCheck();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!InAir)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                InAir = true;
                playerJump.Invoke();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);

        FlipTowardsMovement();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GroundedCheck();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(!InAir)
        {
            GroundedCheck();    
        }
    }

    private void GroundedCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Terrain"));

        if(hit.collider != null)
        {
            InAir = false;
            playerLanding.Invoke();
        }
        else
        {
            InAir = true;
        }
    }
    
    private void FlipTowardsMovement()
    {
        transform.localScale = rb.linearVelocity.x switch
        {
            > 0 => new Vector3(1, 1, 1),
            < 0 => new Vector3(-1, 1, 1),
            _ => transform.localScale
        };
    }
}
