using UnityEngine;

public class CoinInitializer : MonoBehaviour
{
    private Coin _coin;
    private CoinCollectorBridge _bridge;
    private void Awake()
    {
        _coin = GetComponent<Coin>();
        _bridge = FindFirstObjectByType<CoinCollectorBridge>();
        InstantiatePoolObject _normalParticlePool = GameObject.Find("InstantiateCoinParticles")?.GetComponent<InstantiatePoolObject>();
        InstantiatePoolObject _specialParticlePool = GameObject.Find("InstantiateSpecialCoinParticles")?.GetComponent<InstantiatePoolObject>();
        if (_normalParticlePool != null && _coin.GetValue() == 1)
        {
            _coin.SetParticlePool(_normalParticlePool);
        }
        else if (_specialParticlePool != null && _coin.GetValue()  >= 3)
        {
            _coin.SetParticlePool(_specialParticlePool);
        }
    }

    private void OnEnable()
    {
        if (_coin == null || _bridge == null) return;

        _coin.OnCollectedRemoveAllListeners();
        _coin.OnCollectedAddListener(_bridge);
    }
}