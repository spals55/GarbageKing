using PixupGames.Persitence.Models;
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
                    if (PlayerPrefs.HasKey(_saveKey))
                    {
                        var json = PlayerPrefs.GetString(_saveKey);

                        return json.ToDeserialized<Data>();
                    }
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
    }
}
