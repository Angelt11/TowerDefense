using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData _enemyData;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private UnityEvent _onInitialize;
    private bool _isRunning;
    private Vector3 _targetPosition;
    private Health _targetHealth;
    private void OnEnable()
    {
        _isRunning = false;
        _onInitialize?.Invoke();
        Invoke("GetTarget", 0.5f);
    }
    private void GetTarget()
    {
        GameObject target = GameObject.FindGameObjectWithTag(_enemyData.primaryTargetTag);
        if (target != null && !_isRunning)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x,
             transform.position.y, target.transform.position.z);
            _targetPosition = targetPosition;
            _targetHealth = target.GetComponent<Health>();
            _isRunning = true;
            _animator.Play(_enemyData.runAnimationName);
        }
    }
    private void Update()
    {
        if (_isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition,
             _enemyData.runSpeed * Time.deltaTime);
            transform.LookAt(_targetPosition);
            if (Vector3.Distance(transform.position, _targetPosition) <= _enemyData.attackRange)
            {
                _isRunning = false;
                StartCoroutine(Attack());
            }
        }
    }
    private IEnumerator Attack()
    {
        while (_targetHealth != null && _targetHealth.CurrentHealth > 0)
        {
            _animator.Play(_enemyData.attackAnimationName, 0, 0f);
            SoundManager.instance.Play(_enemyData.attackSoundName);
            yield return new WaitForSeconds(_enemyData.attackDuration);
            if (_targetHealth != null)
            {
                _targetHealth.TakeDamage(_enemyData.attackDamage);
            }
            yield return new WaitForSeconds(_enemyData.attackCooldown);
        }
        Win();
    }
    private void Win()
    {
        _animator.Play(_enemyData.winAnimationName);
    }
    public void Die()
    {
        StopAllCoroutines();
        _isRunning = false;
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        _animator.Play(_enemyData.dieAnimationName);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        _isRunning = false;
        _targetHealth = null;
    }

}
