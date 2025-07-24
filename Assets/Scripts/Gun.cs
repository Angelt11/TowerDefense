using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _turret;
    [SerializeField]
    private UnityEvent<Transform> _onFire;
    [SerializeField]
    private GunData _gunData;
    [SerializeField]
    private string _targetTag = "Enemy";
    private EnemyTarget _target;
    private void OnTriggerStay(Collider other)
    {
        if (_target == null && other.CompareTag(_targetTag))
        {
            _target = new EnemyTarget(other.transform, other.GetComponent<Health>());
            StartCoroutine(FireAtTarget());
        }
    }
    private IEnumerator FireAtTarget()
    {
        while (_target != null && _target.Health.CurrentHealth > 0  )
        {
            _turret.LookAt(_target.transform);
            _onFire?.Invoke(_target.transform);
            SoundManager.instance.Play(_gunData.fireSoundName);
            _target.Health.TakeDamage(_gunData.damage);
            yield return new WaitForSeconds(_gunData.fireRate);
        }
        _target = null;
    }

}
[System.Serializable]
public class EnemyTarget
{
    public Transform transform;
    public Health Health;

    public EnemyTarget(Transform targetTransform, Health targetHealth)
    {
        transform = targetTransform;
        Health = targetHealth;
    }

}