        using UnityEngine;
using System.Collections.Generic;

public class InstantiatePoolObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform _parent;
    private List<GameObject> _pool = new List<GameObject>();
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
    public void InstantiateObject(Transform target)
    {
        var obj = GetObject();
        SetObjectPosition(obj, target.position, target.rotation);
    }
    public void InstantiateObject(Vector3 position)
    {
        var obj = GetObject();
        SetObjectPosition(obj, position, Quaternion.identity);
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
