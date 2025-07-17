using UnityEngine.Events;
using UnityEngine;

public class CoinsNumber : MonoBehaviour
{
    [SerializeField]
    private int _coins = 0;
    [SerializeField]
    private UnityEvent<int> _onCoinsUpdated;
    public void AddCoins(int amount)
    {
        _coins += amount;
        _onCoinsUpdated?.Invoke(_coins);
    }
    public void SetCoins(int amount)
    {
        _coins = amount;
        _onCoinsUpdated?.Invoke(_coins);
    }
    public void SubtractCoins(int amount)
    {
        _coins -= amount;
        _onCoinsUpdated?.Invoke(_coins);
    }
}
