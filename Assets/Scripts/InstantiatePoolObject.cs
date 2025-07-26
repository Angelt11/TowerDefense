using UnityEngine;
using System.Collections.Generic;

public class InstantiatePoolObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform _parent;
    private List<GameObject> _pool = new List<GameObject>();
    private GameObject _currentObject;
    private GameObject GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        var newObj = Instantiate(_prefab);
        _pool.Add(newObj);
        return newObj;
    }
    public GameObject GetCurrentObject()
    {
        return _currentObject;
    }
    public void InstantiateObject(Transform target)
    {
        _currentObject = GetObject();
        SetObjectPosition(_currentObject, target.position, target.rotation);
    }
    public void InstantiateObject(Vector3 position)
    {
        _currentObject = GetObject();
        SetObjectPosition(_currentObject, position, Quaternion.identity);
    }
    public void SetObjectPosition(GameObject obj, Vector3 position, Quaternion rotation)
    {
        if (_parent != null)
        {
            obj.transform.SetParent(_parent);
            obj.transform.SetLocalPositionAndRotation(position, rotation);
        }
        else
        {
            obj.transform.SetPositionAndRotation(position, rotation);
        }
        obj.SetActive(true);
    }
    public void DeactivateAllObjects()
    {
        foreach (var obj in _pool)
        {
            obj.SetActive(false);
        }
    }
}
