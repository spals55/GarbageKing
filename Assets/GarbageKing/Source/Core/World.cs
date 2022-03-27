using DG.Tweening;
using PixupGames.Contracts;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixupGames.Core
{
    public class World : MonoBehaviour, IWorld
    {
        [SerializeField] private MainCamera _camera;
        [SerializeField] private Hero _heroTemplate;
        [SerializeField] private List<Region> _regions;
        [SerializeField] private Jetski _jetski;

        private IHero _hero;

        public ICamera Camera => _camera;

        public IHero SpawnHero(Vector3 position)
        {
            _hero = Instantiate(_heroTemplate, position, Quaternion.identity);
            return _hero;
        }

        public void RespawnHero(Vector3 position)
        {
            if (_hero == null)
                throw new System.NullReferenceException("Spawn hero before respawn");

            _hero.transform.position = position;
            _hero.transform.DOComplete(true);
            _hero.transform.DOShakeScale(1);
        }


        public void UnlockRegion(string name)
        {
            foreach (var region in _regions)
                if (region.Name == name)
                    region.Show(false);
        }
    }
}