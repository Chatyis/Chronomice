using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent<bool> bushEnteredByPlayer;
    public UnityEvent<bool> scorePickedUp;
}
