using UnityEngine;

public class MiceAnimationController : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Jumping = Animator.StringToHash("Jumping");
    private static readonly int Landing = Animator.StringToHash("Landing");
    private static readonly int InAir = Animator.StringToHash("inAir");

    [SerializeField] private Animator animator;
    [SerializeField] private MovementController movementController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        movementController.playerJump.AddListener(() => animator.SetTrigger(Jumping));
        movementController.playerLanding.AddListener(() => { animator.SetTrigger(Landing); Debug.Log("Landing Triggered"); });
        movementController.playerInAirChanged.AddListener(() => animator.SetBool(InAir, movementController.InAir));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementController.Rb.linearVelocity.x != 0)
        {
            animator.SetBool(IsRunning, true);
        }
        else
        {
            animator.SetBool(IsRunning, false);
        }
    }
}
