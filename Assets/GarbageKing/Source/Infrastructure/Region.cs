using DG.Tweening;
using PixupGames.Infrastracture.Services;
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Region : MonoBehaviour, IRegion
    {
        [SerializeField] private List<BuyZone> _unlockZone;

        private IDataPersistence _persistence;

        public string Name { get; private set; }

        private void OnValidate()
        {
            Name = gameObject.name;
        }

        public void Init(IDataPersistence persistence)
        {
            _persistence = persistence;
        }

        public void Show(bool animate)
        {
            gameObject.SetActive(true);
            ShowZones();
        }

        private void ShowZones()
        {
            foreach (var buyZone in _unlockZone)
            {
                if(buyZone.GUID == "Lala")
                {
                    buyZone.Buy(false);
                }
            }
        }
    }
}

