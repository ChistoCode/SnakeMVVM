using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;

public static class PrefabCreator
{
    private static Dictionary<string, MonoBehaviour> _prefabs = new Dictionary<string, MonoBehaviour>();

    [CanBeNull]
    public static T Create<T>(Transform parent = null) where T : MonoBehaviour
    {
        
        var classType = typeof(T);
        var attributes = classType.GetCustomAttributes(false);
        var prefabAttribute = attributes.FirstOrDefault(x => x is DefaultPrefabAttribute) as DefaultPrefabAttribute;
        if(prefabAttribute == null)
        {
            Debug.LogError($"[{nameof(PrefabCreator)}] cant find attribute: {nameof(DefaultPrefabAttribute)} on {classType.Name}");
            return null;
        }
        var path = prefabAttribute.PrefabPath;

        if (_prefabs.TryGetValue(path, out var prefab))
            return Object.Instantiate(prefab, parent) as T;

        prefab = Resources.Load<T>(path);
        if(prefab == null)
        {
            Debug.LogError($"[{nameof(PrefabCreator)}] cant find prefab: {classType.Name} on {path}");
            return null;
        }
        _prefabs.Add(path, prefab);
        return Object.Instantiate(prefab, parent) as T;
    }
  
}