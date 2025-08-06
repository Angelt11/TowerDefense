using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private InstantiatePoolObject _instantiateParticlePool;
    [SerializeField]
    private string _appearAnimationName = "CoinAppear";
    [SerializeField]
    private string _disappearAnimationName = "CoinDisappear";
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _timeToDisappear = 3f;
    [SerializeField]
    private UnityEvent<Transform> _onCoinCollected;
    [SerializeField]
    private int _value = 1;
    [SerializeField]
    private string _coinSoundCollected = "CoinCollected";
    private Collider _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        _collider.enabled = true;
        StartCoroutine(AppearCoroutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Collect()
    {
        if (!string.IsNullOrEmpty(_coinSoundCollected))
        {
            SoundManager.instance.Play(_coinSoundCollected);
        }
        if (_instantiateParticlePool != null)
        {
            _instantiateParticlePool.InstantiateObject(transform.position);
        }
        StartCoroutine(DisappearCoroutine());
        _onCoinCollected?.Invoke(this.transform);
    }

    private IEnumerator AppearCoroutine()
    {
        _animator.Play(_appearAnimationName);
        yield return new WaitForSeconds(_timeToDisappear);
        StartCoroutine(DisappearCoroutine());
    }
    private IEnumerator DisappearCoroutine()
    {
        _collider.enabled = false;
        _animator.Play(_disappearAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
    public int GetValue()
    {
        return _value;
    }
    public void OnCollectedAddListener(CoinCollectorBridge bridge)
    {
        _onCoinCollected.AddListener(bridge.CollectCoin);
    }
    public void OnCollectedRemoveAllListeners()
    {
        _onCoinCollected.RemoveAllListeners();
    }
    public void SetParticlePool(InstantiatePoolObject pool)
    {
        _instantiateParticlePool = pool;
    }
}