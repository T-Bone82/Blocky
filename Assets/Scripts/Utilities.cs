using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;

public class Utilities : MonoBehaviour
{
    /// <summary>
    /// Search in prefab, activated or desactivated and returns a GameObject with name corresponding to string name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject FindGameObject(string name)
    {
        Object[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (Object obj in objs)
        {
            if (obj.name == name)
                return (GameObject)obj;
        }
        return null;
    }

}
