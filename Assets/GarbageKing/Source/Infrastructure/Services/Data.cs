
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Persistence.Models
{
    [System.Serializable]
    public class Data
    {
        public World World;

        public Data(World world)
        {
            World = world;
        }
    }

    [System.Serializable]
    public class World
    {
        public MainCamera Camera;
        public Hero Hero;
        public List<Region> Regions;

        public World(List<Region> regions, MainCamera camera, Hero hero)
        {
            Regions = regions;
            Hero = hero;
            Camera = camera;
        }
    }

    [System.Serializable]
    public class MainCamera
    {
        public Vector3 LastPosition;

        public MainCamera(Vector3 lastPosition)
        {
            LastPosition = lastPosition;
        }
    }

    [System.Serializable]
    public class Hero
    {
        public Wallet Wallet;
        public Bag Bag;
        public Vector3 LastPosition;

        public Hero(Wallet wallet, Bag bag, Vector3 lastPosition)
        {
            Bag = bag;
            Wallet = wallet;
            LastPosition = lastPosition;
        }
    }

    [System.Serializable]
    public class Wallet
    {
        public int Money;

        public Wallet(int money)
        {
            Money = money;
        }
    }

    [System.Serializable]
    public class Bag
    {
        
    }

    [System.Serializable]
    public class Region
    {
        public string GUID;
        public bool IsOpen;

        public Region(string guid, bool isOpen)
        {
            GUID = guid;
            IsOpen = isOpen;
        }
    }
}