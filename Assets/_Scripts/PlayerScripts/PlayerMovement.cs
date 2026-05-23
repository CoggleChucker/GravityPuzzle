using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform groundCheckStart;
    public LayerMask groundLayer;

    public InputActionAsset PlayerInput;

    private InputAction moveAction;
    private InputAction jumpAction;

    public float moveSpeed = 6f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.1f;

    //Private variables
    private PlayerAnimations playerAnimations;
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool jumped = false;
    private float jumpCooldown = 0.2f;
    public bool isOnGround = false;
    private float currentGroundCheckDistance = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimations = GetComponent<PlayerAnimations>();
        rb.freezeRotation = true;
        currentGroundCheckDistance = groundCheckDistance;
    }

    private void Start()
    {
        GameEvents.OnGameOver += PlayerInput.Disable;
        GameEvents.OnGameWin += PlayerInput.Disable;
    }

    private void OnDestroy()
    {
        
    }
    private void OnEnable()
    {
        PlayerInput.Enable();
        moveAction = PlayerInput.FindActionMap("Player").FindAction("Move");
        jumpAction = PlayerInput.FindActionMap("Player").FindAction("Jump");
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void Update()
    {
        ReadInput();
        isOnGround = IsGrounded();
        playerAnimations.SetGroundedVariable(isOnGround);
        HandleJump();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(groundCheckStart.position, Vector3.down, currentGroundCheckDistance, groundLayer);
    }

    void HandleJump()
    {
        if(isOnGround && jumped)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentGroundCheckDistance = 0;
            StartCoroutine(ResetJump());
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpCooldown);
        currentGroundCheckDistance = groundCheckDistance;
    }
    void ReadInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        jumped = jumpAction.WasPressedThisFrame();
    }

    void MovePlayer()
    {
        Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward,Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right,Vector3.up).normalized;
        Vector3 moveDirection =(forward * moveInput.y + right * moveInput.x).normalized;
        Vector3 verticalVelocity = Vector3.Project(rb.linearVelocity,Vector3.up);
        Vector3 targetVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = targetVelocity + verticalVelocity;

        // Rotate player toward movement direction
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection,Vector3.up);

            transform.rotation =Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
