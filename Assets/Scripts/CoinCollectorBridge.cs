using UnityEngine;

public class CoinCollectorBridge : MonoBehaviour
{
    [SerializeField] private CoinsNumber _coinsNumber;

    public void CollectCoin(Transform coinTransform)
    {
        Coin coin = coinTransform.GetComponent<Coin>();
        if (coin == null || _coinsNumber == null) return;

        _coinsNumber.AddCoins(coin.GetValue());
    }
}