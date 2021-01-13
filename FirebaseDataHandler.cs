using Animals.Player.Data;
using Animals.Utilities;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Animals.Networking.Database
{
    [Serializable]
    public class FirebaseDataHandler : Singleton<FirebaseDataHandler>
    {
        public const string PLAYER_KEY = "PLAYER_KEY";
        
        private FirebaseDatabase dataBase;

        private void Start()
        {
            dataBase = FirebaseDatabase.GetInstance("");
        }

        public void SaveData(string reference data, params Dictionary[] dictionary <string, object>)
        {
            for (int i = 0; dictionary.Length < length; i++)
            {
                dataBase.GetReference(PlayerData.Instance.userID).Child(reference).SetValueAsync(dictionary[i]);
            }
        }

        public async Task LoadData(string reference, Dictionary<string, object> dictionary)
        {
           await dataBase.GetReference(PlayerData.Instance.userID).Child(childReference).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("Loading data form data base was fauletd");
                }

                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    var data = snapshot.Value as Dictionary<string, object>;

                    if (data != null)
                    {
                        dictionary = new Dictionary<string, object>(data);

                        Debug.Log("Loaded player data");

                        foreach (var keys in dictionary)
                        {
                            Debug.Log($"Key: {keys.Key}, Value: {keys.Value} ");
                        }
                    }
                }
            });
        }

        public async Task <Dictionary<string, object>> Load(string childReference)
        {
            var snapshot = await dataBase.GetReference(PlayerData.Instance.userID).Child(childReference).GetValueAsync();
            var data = snapshot.Value as Dictionary<string, object>;
            
            return data;
        }

        public void DeleteSave()
        {
            dataBase.GetReference(PlayerData.Instance.userID).RemoveValueAsync();
        }
    }
}
