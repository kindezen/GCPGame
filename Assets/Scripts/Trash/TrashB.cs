using UnityEngine;

[CreateAssetMenu(fileName = "Trash B Data", menuName = "ScriptableObjects/Trash B", order = 1)]
public class TrashB : Trash
{
    public Sprite image;

    public RecycleType typeLeft, typeRight;
    
    public Choice answer;

    public enum Choice { LEFT, RIGHT }

    public override Sprite GetDefaultSprite()
    {
        return image;
    }
}
