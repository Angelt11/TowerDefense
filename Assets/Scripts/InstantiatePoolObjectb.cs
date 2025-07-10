using UnityEngine;
using System.Collections.Generic;

public class InstantiatePoolObjectb : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
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
        obj.transform.SetPositionAndRotation(target.position, target.rotation);
        obj.SetActive(true);
    }
}
