using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixupGames.Contracts;
using System.Threading.Tasks;

public class Chest : MonoBehaviour, IChest
{
    [SerializeField] private Transform _lid;
    [SerializeField] private List<Money> _dollars;

    public void Open()
    {
        _lid.transform.DOLocalRotate(new Vector3(-90, 0, 0), 1f);
    }

    public void Close()
    {
        _lid.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHero hero))
        {
            Open();

            await Task.Delay(500);

            if (_dollars.Count > 0)
            {
                foreach (var dollar in _dollars)
                {
                    dollar.transform.DOMove(hero.transform.position, 0.3f)
                        .OnComplete(() => Destroy(dollar.gameObject));
                    hero.Wallet.Add(dollar.Amount);
                }

                _dollars.Clear();
            }
        }
    }
}
