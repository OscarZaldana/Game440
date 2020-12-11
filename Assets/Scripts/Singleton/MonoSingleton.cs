/*Is used to make sure that only a single instance of an object will exist.
 The purpose for this is when dealing with multiple scenes we want to bring in 
items that still carry the same data. best example is player data and camera
if you carry over a camera to the next scene then the scene will have two cameras*/

using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance = null;
    private static bool isQuitting = false;
    public static T Instance
    {
        get
        {
            if (instance == null && !isQuitting)
                FindOrCreateInstance();
            return instance;
        }
    }

    static private void FindOrCreateInstance()
    {
        T[] instanceArray = FindObjectsOfType<T>();
        if (instanceArray.Length == 0)
        {
            GameObject singleton = new GameObject(string.Empty);
            instance = singleton.AddComponent<T>();
            singleton.name = singleton.GetComponent<T>().ToString();
            DontDestroyOnLoad(singleton);
        }
        else if (instanceArray.Length == 1)
        {
            instance = instanceArray[0];
            DontDestroyOnLoad(instance);
        }
        else if (instanceArray.Length > 1)
        {
            Debug.LogError("Multiple instances of a singleton exists.");
            Debug.Break();
        }
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
