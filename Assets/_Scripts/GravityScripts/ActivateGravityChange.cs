using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateGravityChange : MonoBehaviour
{
    public InputAction activationAction;
    public Transform gravityIndicator;


    private void OnEnable()
    {
        activationAction.Enable();
    }

    private void OnDisable()
    {
        activationAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(activationAction.WasPressedThisFrame())
        {
            gravityIndicator.gameObject.SetActive(!gravityIndicator.gameObject.activeSelf);
        }
    }
}
