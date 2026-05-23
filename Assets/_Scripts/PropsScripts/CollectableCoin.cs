using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.instance.AddCoinToMaxScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.CoinCollected();
            Destroy(gameObject);
        }

    }
}
