using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;

    private bool isOnGround = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Set speed in animator
        float speed = rb.linearVelocity.magnitude;
        Mathf.Clamp01(speed);
        animator.SetFloat("Speed", speed);

        //Set isonground in animator
        animator.SetBool("IsOnGround", isOnGround);
    }

    public void SetGroundedVariable(bool grounded)
    {
        isOnGround = grounded;
    }
}
