using System;
using UnityEngine;
using UnityEditor;

public class GUIDSaveObject : MonoBehaviour
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
    [ContextMenu("Regenerate GUID")]
    public void RegenerateGUID()
    {
        _guid = Guid.NewGuid().ToString();
        EditorUtility.SetDirty(gameObject);
    }
#endif
}
