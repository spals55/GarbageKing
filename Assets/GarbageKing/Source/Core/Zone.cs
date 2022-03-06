using System;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public abstract class Zone : MonoBehaviour, IZone
{
#if UNITY_EDITOR
    [ReadOnly]
#endif
    [SerializeField] private string _guid;

    public string GUID => _guid;

    private void OnValidate()
    {
#if UNITY_EDITOR
        if (string.IsNullOrEmpty(_guid))
        {
            _guid = Guid.NewGuid().ToString();
            EditorUtility.SetDirty(gameObject);
        }
#endif
    }

#if UNITY_EDITOR
    [ContextMenu("Regenerate Zone GUID")]
    public void RegenerateGUID()
    {
        _guid = Guid.NewGuid().ToString();
        EditorUtility.SetDirty(gameObject);
    }
#endif

    public void Hide() => Destroy(gameObject);

    public void Show() => gameObject.SetActive(true);

    public abstract void Unlock(bool animate);
}
