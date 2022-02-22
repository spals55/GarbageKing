
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
        public Bag Bag;
        public Vector3 LastPosition;

        public Character(Bag bag, Vector3 lastPosition)
        {
            Bag = bag;
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
        public string Name;
        public bool IsOpen;

        public Region(string name, bool isOpen)
        {
            Name = name;
            IsOpen = isOpen;
        }
    }
}