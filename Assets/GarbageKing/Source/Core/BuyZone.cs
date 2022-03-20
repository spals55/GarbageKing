using DG.Tweening;
using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using System.Collections;
using TMPro;
using UnityEngine;

public class BuyZone : Zone
{
    [SerializeField] private int _totalCost = 100;
    [SerializeField] private TMP_Text _totalCostLabel;
    [SerializeField] private Unlocker _unlocker;
    [SerializeField] private BuyZoneTrigger _trigger;

    private ObjectPool _objectPool;
    private Coroutine _tryBuyCoroutine;

    private void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnEnable()
    {
        _trigger.Entered += OnEntered;
        _trigger.Exit += OnExit;
    }

    private void OnDisable()
    {
        _trigger.Entered -= OnEntered;
        _trigger.Exit -= OnExit;
    }

    private void OnEntered(IHero hero)
    {
        if (_tryBuyCoroutine != null)
            StopCoroutine(_tryBuyCoroutine);

        _tryBuyCoroutine = StartCoroutine(TryBuy(hero.Wallet, hero.Movement));
    }

    private void OnExit(IHero hero)
    {
        StopCoroutine(_tryBuyCoroutine);
    }

    private IEnumerator TryBuy(IWallet wallet, IMovement movement)
    {
        const int IterationMultiplier = 15;
        var iteration = 0;

        while (true)
        {
            if (movement.Stopped && wallet.Money > 0)
            {
                var multiplierCoefficient = iteration / IterationMultiplier;

                if (_totalCost < multiplierCoefficient)
                    multiplierCoefficient = _totalCost;

                multiplierCoefficient = Mathf.Clamp(multiplierCoefficient, 1, wallet.Money);

                GetMoney(wallet, multiplierCoefficient);

                if (_totalCost < 1)
                    Buy(true);
            }

            iteration++;
            yield return null;
        }
    }

    public override void Buy(bool animate)
    {
        _unlocker.Unlock(animate);
        _unlocker.transform.parent = null;

        Hide();
    }

    private void GetMoney(IWallet wallet, int multiplierCoefficient)
    {
        wallet.Spend(multiplierCoefficient);
        _totalCost -= multiplierCoefficient;
        _totalCostLabel.text = _totalCost.ToString();

        MoneyTransfer(wallet.Container.position, _unlocker.transform.position);
    }

    private void MoneyTransfer(Vector3 from, Vector3 to)
    {
        var money = _objectPool.Get(from);
        money.transform.DORotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)), 1f);
        money.transform.DOJump(new Vector3(to.x + Random.Range(-3, 3), to.y, to.z + Random.Range(-3, 3)), 5f, 1, 1.5f)
            .OnComplete(() =>
            {
                money.transform.DOScale(Vector3.zero, 0.2f)
                .OnComplete(() =>
                {
                    money.DOComplete(true);
                    money.gameObject.SetActive(false);
                });
            });
    }
}
