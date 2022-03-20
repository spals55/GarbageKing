using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMaxIcon : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _offsetY = 1.5f;

    private void Awake()
    {
        Hide();
    }

    public void Show(float positionY)
    {
        _canvasGroup.Open();
        ChangePosition(positionY);
    }

    public void Hide()
    {
        _canvasGroup.Close();
    }

    private void ChangePosition(float positionY)
    {
        transform.position = new Vector3(transform.position.x, positionY + _offsetY, transform.position.z);
    }
}
