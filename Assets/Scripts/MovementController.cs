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
    public UnityEvent playerClimbingChanged;
    
    private bool _inAir;
    private bool _isClimbing;

    public bool InAir
    {
        get => _inAir;
        private set
        {
            _inAir = value;
            playerInAirChanged.Invoke();
        }
    }
    public bool isClimbing
    {
        get => _isClimbing;
        private set
        {
            _isClimbing = value; 
            playerClimbingChanged.Invoke();
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
            if (!InAir && !isClimbing)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                InAir = true;
                playerJump.Invoke();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, isClimbing ? Input.GetAxis("Vertical") * speed / 2f : rb.linearVelocity.y);
        
        FlipTowardsMovement();
        GroundedCheck();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Climbable"))
        {
            Debug.Log("Entered Climbable");
            isClimbing = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Climbable"))
        {
            Debug.Log("Exited Climbable");
            GroundedCheck();
            isClimbing = false;
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
