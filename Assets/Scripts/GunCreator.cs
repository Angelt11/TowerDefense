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
    private bool _gunPlaced = false;
    private void Update()
    {
        if (_gun == null)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _raycastDistance, _raycastLayerMask))
            {

                if (hit.transform.CompareTag(_floorTag))
                {
                    _gun.position = hit.point;
                    _gunPlaced = true;
                }
            }
            else
            {
                _gunPlaced = false;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            _gun.gameObject.SetActive(false);
            _gunPlaced = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!_gunPlaced)
            {
                _gun.gameObject.SetActive(false);
            }
            _gun = null;
        }
    }

    public void SetGun(Transform gun)
    {
        _gun = gun;
        _gunPlaced = false;
    }
}
