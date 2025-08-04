using UnityEngine;

public class CoinInitializer : MonoBehaviour
{
    private Coin _coin;
    private CoinCollectorBridge _bridge;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
        _bridge = FindFirstObjectByType<CoinCollectorBridge>(); // Busca automáticamente en la escena
    }

    private void OnEnable()
    {
        if (_coin == null || _bridge == null) return;

        _coin.OnCollectedRemoveAllListeners();
        _coin.OnCollectedAddListener(_bridge);
    }
}