using UnityEngine;
using System.Collections;

public class GameObjectUtils : MonoBehaviour
{

    public GameObject GetInactiveObject(string name)
    {
        Object[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject));

        foreach (Object obj in objs)
        {
            if (obj.name == name)
            {
                return (GameObject) obj;

            }

        }
        return null;
    }

}
