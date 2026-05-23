using UnityEngine;

public class OuterBoundry : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.OnGameOver?.Invoke();
        }
    }
}
