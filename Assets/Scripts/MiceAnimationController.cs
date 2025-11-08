using UnityEngine;

public class MiceAnimationController : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Jumping = Animator.StringToHash("Jumping");
    private static readonly int Landing = Animator.StringToHash("Landing");
    private static readonly int InAir = Animator.StringToHash("inAir");

    [SerializeField] private Animator animator;
    [SerializeField] private MovementController movementController;
    
    void Awake()
    {
        movementController.playerJump.AddListener(() => animator.SetTrigger(Jumping));
        movementController.playerLanding.AddListener(() => animator.SetTrigger(Landing));
        movementController.playerInAirChanged.AddListener(UpdateInAir);
        movementController.playerClimbingChanged.AddListener(UpdateInAir);
    }

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

    void UpdateInAir()
    {
        animator.SetBool(InAir, movementController.InAir && !movementController.isClimbing);
        animator.SetBool(InAir, movementController.InAir && !movementController.isClimbing);
    }
}
