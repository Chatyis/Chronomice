using System;
using DefaultNamespace;
using UnityEngine;

public class MovableObjectController : MonoBehaviour
{
    [SerializeField]
    private MovableObjectType movableObjectType;

    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        InitObjectByType();
    }

    private void InitObjectByType()
    {
        switch (movableObjectType)
        {
            case MovableObjectType.HEAVY:
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                break;
            case MovableObjectType.LIGHT:
                break;
            default:
                Debug.LogError("Unknown MovableObjectType: " + movableObjectType);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player") && movableObjectType == MovableObjectType.HEAVY )
        {
            var ageManger = other.collider.gameObject.transform.parent.GetComponent<PlayerAgeManager>();

            if (ageManger.Age == 1)
            {
                rb.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player") && movableObjectType == MovableObjectType.HEAVY)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
