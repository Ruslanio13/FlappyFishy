using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] protected Camera _camera;

    private List<GameObject> _pool = new List<GameObject>(); 

    protected void Initialize(GameObject prefab)
    {
        for(int i = 0;i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Pipe result)
    {
        _pool.FirstOrDefault(p => p.activeSelf == false).TryGetComponent(out result);
        return result != null;
    }

    protected bool DisableObjectAbroadScreen()
    {
        bool result = false;
        Vector3 disablePoint = _camera.ViewportToWorldPoint(Vector2.zero);
        foreach (var obj in _pool)
            if (obj.activeSelf && obj.transform.position.x < disablePoint.x)
            {
                obj.SetActive(false);
                result = true;
            }

        return result;
    }

    public void ResetPool()
    {
        foreach (var obj in _pool)
            obj.SetActive(false);
    }

    protected bool AllPoolDisabled()
    {
        return _pool.FirstOrDefault(p => p.activeSelf == true) == null;
    }

    public void SetAllObjectsColliders(bool isActive)
    {
        foreach (var obj in _pool)
            if (TryGetComponent(out BoxCollider2D box))
                box.enabled = isActive;
    }
}
