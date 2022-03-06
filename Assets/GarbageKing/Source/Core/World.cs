using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Core
{
    public class World : IWorld
    {
        private const string HeroPath = "World/Hero";

        private List<Region> _regions;

        public World(List<Region> regions)
        {
            _regions = regions;
        }

        public IHero CreateHero(Vector3 position)
        {
            Hero prefab = Resources.Load<Hero>(HeroPath);
            IHero hero = Object.Instantiate(prefab, position, Quaternion.identity);

            return hero;
        }

        public void UnlockRegion(string guid)
        {
            foreach (var region in _regions)
            {
                if (region.GUID == guid)
                {
                    region.Unlock(false);
                }
            }
        }
    }
}