using System.IO;
using UnityEditor;
using UnityEngine;

public class UserData : ScriptableObject {
    private static UserData instance;

    public static UserData Instance {
        get {
            if (instance is null) {
                var userData = Resources.Load<UserData>("GameData/UserData");
                if (userData is null) {
                    var path = "Assets/Resources/GameData";

                    var prefabsFolder = new DirectoryInfo(path);
                    if (prefabsFolder.Exists == false) {
                        prefabsFolder.Create();
                    }

                    userData = ScriptableObject.CreateInstance<UserData>();
                    AssetDatabase.CreateAsset(userData, $"{path}/UserData.asset");
                }

                instance = userData;
            }

            return instance;
        }
    }

    private ulong coin;

    public ulong Coin {
        get => coin;
        set => coin = value;
    }
}