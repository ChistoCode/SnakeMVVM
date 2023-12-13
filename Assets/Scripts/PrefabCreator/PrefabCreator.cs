using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class PrefabCreator
{
    private static Dictionary<string, MonoBehaviour> _prefabs = new Dictionary<string, MonoBehaviour>();

    static void Create<T>() where T : MonoBehaviour
    {
        var classType = typeof(T);
        var attributes = classType.GetCustomAttributes(false);
        var prefabAttribute = attributes.FirstOrDefault(x => x is DefaultPrefabAttribute) as DefaultPrefabAttribute;
        if(prefabAttribute == null)
        {
            throw new Exception($"[{nameof(PrefabCreator)}] cant find attribute: {nameof(DefaultPrefabAttribute)} on {nameof(T)}");
        }
        var path = prefabAttribute.PrefabPath;
    }
  
}