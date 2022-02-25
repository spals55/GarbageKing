using PixupGames.Infrastracture.Services;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Region : MonoBehaviour, IRegion
    {
        [SerializeField] private int _id;
        [SerializeField] private List<BuyZone> _buyZones;

        private IDataPersistence _persistence;

        public int Id => _id;

        public void Init(IDataPersistence persistence)
        {
            _persistence = persistence;
        }

        public void Unlock()
        {
            UnlockCommodity();
        }

        private void UnlockCommodity()
        {
            foreach (var buyZone in _buyZones)
            {
                if(buyZone.Id == 1337)
                {
                    buyZone.UnlockCommodity(false);
                }
            }
        }
    }
}

