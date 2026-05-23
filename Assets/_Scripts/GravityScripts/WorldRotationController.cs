using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class WorldRotationController : MonoBehaviour
{
    #region Singleton
    public static WorldRotationController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion /Singleton

    public Transform player;
    public Transform cameraTransform;

    public float rotationDuration = 0.5f;

    private bool isRotating = false;
    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        if (isRotating)
            return;
    }

    public void HandleInput(Vector2 currentInput)
    {

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 flattenedForward = Vector3.ProjectOnPlane(cameraForward, Vector3.up).normalized;
        Vector3 nearestForward = GetNearestWorldAxis(flattenedForward);
        Vector3 nearestRight = Vector3.Cross(Vector3.up, nearestForward).normalized;

        if (currentInput.y > 0)
        {
            StartCoroutine(RotateWorld(nearestRight, 90f)); //up
        }
        else if (currentInput.y < 0)
        {
            StartCoroutine(RotateWorld(nearestRight, -90f)); //down
        }
        else if (currentInput.x > 0)
        {
            StartCoroutine(RotateWorld(nearestForward, -90f)); //right
        }
        else if (currentInput.x < 0)
        {
            StartCoroutine(RotateWorld(nearestForward, 90f)); //left
        }
    }

    //find the nearest world axis to a given direction
    Vector3 GetNearestWorldAxis(Vector3 direction)
    {
        Vector3[] axes = {Vector3.forward, Vector3.back, Vector3.right, Vector3.left};

        float bestDot = -Mathf.Infinity;
        Vector3 bestAxis = Vector3.forward;
        foreach (Vector3 axis in axes)
        {
            float dot = Vector3.Dot(direction, axis);
            if (dot > bestDot)
            {
                bestDot = dot;
                bestAxis = axis;
            }
        }
        return bestAxis;
    }

    IEnumerator RotateWorld(Vector3 axis, float angle)
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion rotationStep = Quaternion.AngleAxis(angle, axis);
        targetRotation = rotationStep * startRotation;
        Vector3 pivot = player.position;
        float elapsed = 0f;

        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / rotationDuration);
            Quaternion currentRotation =Quaternion.Slerp(startRotation,targetRotation, t);
            Quaternion delta = currentRotation * Quaternion.Inverse(transform.rotation);

            // Rotate around player
            Vector3 offset = transform.position - pivot;
            offset = delta * offset;
            transform.position = pivot + offset;
            transform.rotation = currentRotation;

            yield return null;
        }

        //snap to target rotation to avoid precision issues
        transform.rotation = targetRotation;
        SnapTo90Degrees();
        isRotating = false;
    }

    void SnapTo90Degrees()
    {
        Vector3 euler = transform.eulerAngles;

        euler.x = Mathf.Round(euler.x / 90f) * 90f;
        euler.y = Mathf.Round(euler.y / 90f) * 90f;
        euler.z = Mathf.Round(euler.z / 90f) * 90f;

        transform.eulerAngles = euler;
    }
}