using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PixupGames.Contracts;
using System.Threading.Tasks;

public class Chest : GUIDSaveObject, IChest
{
    [SerializeField] private Transform _lid;
    [SerializeField] private List<Money> _dollars;

    private bool _isOpen;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(GUID))
        {
            Open();

            foreach (var dollar in _dollars)
                Destroy(dollar.gameObject);
        }
    }

    public void Open()
    {
        _lid.transform.DOLocalRotate(new Vector3(-90, 0, 0), 1f);
        _isOpen = true;
    }

    public void Close()
    {
        _lid.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHero hero))
        {
            if (_isOpen) 
                return;

            Open();

            await Task.Delay(800);

            if (_dollars.Count > 0)
            {
                foreach (var dollar in _dollars)
                {
                    dollar.transform.DOMove(hero.transform.position, 0.3f)
                        .OnComplete(() => Destroy(dollar.gameObject));
                    hero.Wallet.Add(dollar.Amount);
                }

                PlayerPrefs.SetString(GUID, GUID);
                _dollars.Clear();
            }
        }
    }
}
