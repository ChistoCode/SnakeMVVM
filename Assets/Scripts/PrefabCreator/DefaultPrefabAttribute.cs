using System;

[AttributeUsage(AttributeTargets.Class)]
public class DefaultPrefabAttribute : Attribute
{
    public string PrefabPath { get; }
    public DefaultPrefabAttribute(string prefabPath)
    {
        PrefabPath = prefabPath;
    }
}
