using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;
    [SerializeField] private TextMeshProUGUI coinText;
    private int coins = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }


    private void UpdateUI()
    {
        coinText.text = coins.ToString("00");
    }
}
