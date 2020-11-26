using UnityEngine;

public abstract class Trash : ScriptableObject
{
    public string trashName;
    public string trashDescription;

    public abstract Sprite GetDefaultSprite();
}