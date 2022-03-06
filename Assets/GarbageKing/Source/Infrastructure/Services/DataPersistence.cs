using PixupGames.Persistence.Models;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PixupGames.Infrastracture.Services
{
    public class DataPersistence : IDataPersistence
    {
        private readonly string _saveKey;

        private Data _data;

        public DataPersistence(string saveKey)
        {
            _saveKey = saveKey;
        }

        public Data Data
        {
            get
            {
                if (_data == null)
                {
                    //if (PlayerPrefs.HasKey(_saveKey))
                    //{
                    //    var json = PlayerPrefs.GetString(_saveKey);

                    //    _data = json.ToDeserialized<Data>();
                    //}
                    //else
                    //{
                        _data = GetDefaultValues();                      
                    //}
                }

                return _data;
            }
            set
            {
                if (value != null)
                   _data = value;
            }
        }

        public void Save() =>
            PlayerPrefs.SetString(_saveKey, _data.ToJson());

        private Data GetDefaultValues()
        {
            var camera = new MainCamera(new Vector3(0, 0, 0));
            var hero = new Hero(new Wallet(2500), new Bag(), new Vector3(9.8f, -2.39f, 24.2f));
            var world = new World(new List<Region>(), camera, hero);
            return new Data(world);
        }
    }
}
