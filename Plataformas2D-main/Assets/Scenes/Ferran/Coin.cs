using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        CoinCounter.Instance.AddCoin(coinValue);

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }


        Destroy(gameObject);
    }
}
