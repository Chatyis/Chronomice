using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent<bool> bushEnteredByPlayer;
    public UnityEvent scorePickedUp;
    public UnityEvent<GameObject> checkpointCaptured;
    public UnityEvent levelCompleted;
}
