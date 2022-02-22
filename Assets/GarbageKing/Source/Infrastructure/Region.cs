using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Region : MonoBehaviour, IRegion
    {
        [SerializeField] private string _name;

        public string Name => _name;

        public void Unlock()
        {

        }
    }
}