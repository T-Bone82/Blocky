using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{

    public static GameObject findGameObject(string name)
    {
        Object[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (Object obj in objs)
        {
            if (obj.name == name)
                return (GameObject)obj;
        }
        return null;
    }

    public static bool hasNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        return nextScene < SceneManager.sceneCount;
    }
}
