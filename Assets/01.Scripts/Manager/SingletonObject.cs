using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                var obj = GameObject.FindObjectOfType<T>();
                if (obj == null) {
                    var prefabs = Resources.Load<T>($"Prefabs/{typeof(T)}");
                    
                    if (prefabs != null) {
                        obj = prefabs;
                        Instantiate(prefabs.gameObject, Vector2.zero, Quaternion.identity);
                    }
                    else {
                        obj = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        var prefabPath = $"{Application.dataPath}/Resources/Prefabs/{typeof(T)}.prefab";

                        prefabPath = AssetDatabase.GenerateUniqueAssetPath(prefabPath);

                        PrefabUtility.SaveAsPrefabAssetAndConnect(obj.gameObject, prefabPath, InteractionMode.UserAction);
                    }
                }

                instance = obj;
            }

            return instance;
        }
    }

    public void Destroy() {
        instance = null;
    }
}
