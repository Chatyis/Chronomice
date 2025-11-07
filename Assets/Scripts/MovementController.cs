using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D _rb;
    private bool _inAir;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") )
        {
            Debug.Log("Jump");
            if (!_inAir)
            {
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _inAir = true;
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GroundedCheck();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(!_inAir)
        {
            GroundedCheck();    
        }
    }

    private void GroundedCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Terrain"));

        if(hit.collider != null)
        {
            _inAir = false;
        }
        else
        {
            _inAir = true;
        }
    }
}
