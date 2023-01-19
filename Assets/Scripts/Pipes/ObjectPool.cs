using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Camera _camera;

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

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(Vector2.zero);
        foreach (var obj in _pool)
            if (obj.activeSelf && obj.transform.position.x < disablePoint.x)
                obj.SetActive(false);
    }

    public void ResetPool()
    {
        foreach (var obj in _pool)
            obj.SetActive(false);
    }
}
