using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            PlayerController player = other.collider.transform.parent.GetComponent<PlayerController>();
            player.Die(true);
        }
    }
}
