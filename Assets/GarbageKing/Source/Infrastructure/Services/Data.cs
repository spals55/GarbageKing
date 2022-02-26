
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Persitence.Models
{
    [System.Serializable]
    public class Data
    {
        public World World;
        public Character Character;

        public Data(World world, Character character)
        {
            World = world;
            Character = character;
        }
    }

    [System.Serializable]
    public class World
    {
        public List<Region> Regions;

        public World(List<Region> regions)
        {
            Regions = regions;
        }
    }

    [System.Serializable]
    public class Character
    {
        public int Money;
        public Bag Bag;
        public Vector3 LastPosition;

        public Character(int money, Bag bag, Vector3 lastPosition)
        {
            Bag = bag;
            Money = money;
            LastPosition = lastPosition;
        }
    }

    [System.Serializable]
    public class Bag
    {
        
    }

    [System.Serializable]
    public class Region
    {
        public int Id;
        public bool IsOpen;

        public Region(int id, bool isOpen)
        {
            Id = id;
            IsOpen = isOpen;
        }
    }
}