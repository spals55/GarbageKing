using DG.Tweening;
using PixupGames.Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoneyMagnit : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _attractDuration = 0.05f;
    [SerializeField] private float _reduceDuration = 0.1f;

    private void Attract(Money money)
    {
        _wallet.Add(money.Amount);

        money.transform.DOComplete(true);

        money.transform.DOLocalRotate(Vector3.zero, _attractDuration);
        money.transform.DOLocalMove(_wallet.Container.transform.position, _attractDuration).OnComplete(() =>
        {
            money.transform.DOScale(0, _reduceDuration).OnComplete(() => money.gameObject.SetActive(false));
        });
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out MoneyStack stack))
        {
            if (stack.CanGet)
            {
                Attract(stack.Get());
            }
        }
    }
}
