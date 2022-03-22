using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private int _capacity = 15;
    [SerializeField] private int _additionCapacity = 15;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnContainer;

    private List<PoolElement> _pool = new List<PoolElement>();

    private void OnValidate()
    {
        if (_template != null && _template.GetComponent<T>() == null)
        {
            _template = null;
            Debug.LogError($"Template must containe {typeof(T)} component");
        }

        if (_capacity < 1)
            _capacity = 1;

        if (_additionCapacity < 1)
            _additionCapacity = 1;
    }

    private void Awake()
    {
        SpawnElements(_capacity);
    }

    public T GetElement(Vector3 position)
    {
        PoolElement element = _pool.FirstOrDefault(e => e.CanUse);

        if (element != null)
        {
            element.Show();
            element.transform.position = position;

            return element.GetComponent<T>();
        }
        else
        {
            SpawnElements(_additionCapacity);
            return GetElement(position);
        }
    }

    public void SpawnElements(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject element = Instantiate(_template, _spawnContainer);
            element.SetActive(false);

            _pool.Add(element.GetComponent<PoolElement>());
        }
    }
}

