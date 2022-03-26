using DG.Tweening;
using PixupGames.Infrastracture.Game;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour, IPanel
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _content;
    [SerializeField] private Trader _trader;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Hide);
    }

    public void Hide()
    {
        _canvasGroup.Close();
        _trader.Wave();
    }

    public void Show()
    {
        _canvasGroup.Open();
        _content.transform.localScale = Vector3.zero;
        _content.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }
}
