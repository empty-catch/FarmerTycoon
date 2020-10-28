using System.IO;
using NaughtyAttributes;
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

    [SerializeField]
    private ulong coin;

    public ulong Coin {
        get => coin;
        set => coin = value;
    }

    private Item selectCloset;

    public Item SelectCloset {
        get => selectCloset;
        set => selectCloset = value;
    }

    private Item selectTool;

    public Item SelectTool {
        get => selectTool;
        set => selectTool = value;
    }

    public Item[] SelectPlants { get; } = new Item[6];

    private Item currentSelectItem;

    public Item CurrentSelectItem {
        get => currentSelectItem;
        set => currentSelectItem = value;
    }

    [Button("Log")]
    private void Log() {
        Debug.Log(selectCloset.ItemSprite);
    }

    [Button("Reset UserData")]
    private void ResetUserData() {
        coin = 0;
        currentSelectItem = null;
        selectCloset = null;
        selectTool = null;

        for (int i = 0; i < SelectPlants.Length; i++) {
            SelectPlants[i] = null;
        }
        
        
        
        
    }
}