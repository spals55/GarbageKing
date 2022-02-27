using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashRecyclerCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _capacityText;

    public void RenderCapacity(int currentCount, int capacity)
    {
        _capacityText.text = $"{currentCount}/{capacity}";
    }

    public void Show()
    {
        _canvasGroup.Open();
    }

    public void Hide()
    {
        _canvasGroup.Close();
    }
}
