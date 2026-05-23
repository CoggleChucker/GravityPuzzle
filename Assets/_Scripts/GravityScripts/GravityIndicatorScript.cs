using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using Unity.VisualScripting;

public class GravityIndicatorScript : MonoBehaviour
{
    public InputAction inputAction;
    public InputAction SelectAction;

    public Transform indicatorObject;
    public float indicatorRotateSpeed = 10f;

    private Vector3 targetRot;
    private Vector2 currentInput;

    private CinemachineInputAxisController cameraInputs;
    private void OnEnable()
    {
        inputAction.Enable();
        SelectAction.Enable();

        cameraInputs = GetComponentInParent<CinemachineInputAxisController>();
        cameraInputs.enabled = false;
        indicatorObject.gameObject.SetActive(true);
        currentInput = Vector2.zero;
    }

    private void OnDisable()
    {
        inputAction.Disable();
        SelectAction.Disable();

        cameraInputs.enabled = true;
        indicatorObject.gameObject.SetActive(false);
    }

    void Update()
    { 
        //Debug.Log("Gravity Indicator Update");
        Vector2 input = inputAction.ReadValue<Vector2>();
       
        if (input != Vector2.zero)
            currentInput = input;

        //if both x and y are not 0, set x to 0, so that the indicator only shows one direction at a time
        if (currentInput.x != 0 && currentInput.y != 0)
            currentInput.x = 0;

        
        targetRot = new Vector3(-currentInput.y, 0f, currentInput.x) * 90f;
        indicatorObject.localRotation = Quaternion.Slerp(indicatorObject.localRotation, Quaternion.Euler(targetRot), Time.unscaledDeltaTime * indicatorRotateSpeed);

        if (SelectAction.WasPressedThisFrame())
        {
            //send current input to worldrotationcontroller
           WorldRotationController.instance.HandleInput(currentInput);
            gameObject.SetActive(false);
        }
    }
}
