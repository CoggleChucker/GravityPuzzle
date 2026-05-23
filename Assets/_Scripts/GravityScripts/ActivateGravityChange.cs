using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateGravityChange : MonoBehaviour
{
    public InputAction activationAction;
    public InputAction cancelationAction;

    public Transform gravityIndicator;


    private void OnEnable()
    {
        activationAction.Enable();
        cancelationAction.Enable();
    }

    private void OnDisable()
    {
        activationAction.Disable();
        cancelationAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityIndicator.gameObject.activeSelf)
        {
            if(cancelationAction.WasPressedThisFrame())
            {
                gravityIndicator.gameObject.SetActive(false);
            }
            return;
        }

        if(activationAction.WasPressedThisFrame())
        {
            gravityIndicator.gameObject.SetActive(true);
        }
    }
}
