using System;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventSender : MonoBehaviour
{
    public UnityEvent collisionEnter;
    public UnityEvent collisionExit;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        collisionEnter.Invoke();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        collisionExit.Invoke();
    }
}
