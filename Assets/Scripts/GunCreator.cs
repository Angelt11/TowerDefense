using UnityEngine;

public class GunCreator : MonoBehaviour
{
    [SerializeField]
    private float _raycastDistance = 100f;
    [SerializeField]
    private LayerMask _raycastLayerMask;
    [SerializeField]
    private string _floorTag = "Floor";
    private Transform _gun;
    private bool _gunplaced = false;
    private void Update()
    {
        if (_gun == null)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _raycastDistance, _raycastLayerMask))
            {
                if (hit.transform.CompareTag(_floorTag))
                {
                    _gun.position = hit.point;
                    _gunplaced = true;
                }
                else
                {
                    _gunplaced = false;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            _gun.gameObject.SetActive(false);
            _gunplaced = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!_gunplaced)
            {
                _gun.gameObject.SetActive(false);
            }
            _gun = null;
        }
    }
    public void SetGun(Transform gun)
    {
        _gun = gun;
        _gunplaced = false;
    }
}
