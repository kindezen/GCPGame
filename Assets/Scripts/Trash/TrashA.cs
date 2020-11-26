using UnityEngine;

[CreateAssetMenu(fileName = "Trash A Data", menuName = "ScriptableObjects/Trash A", order = 1)]
public class TrashA : Trash
{
    public Sprite[] images;
    public int targetStep;

    public Sprite GetSprite(int step){
        return images[Mathf.Min(step - 1, images.Length - 1)];
    }

    public override Sprite GetDefaultSprite()
    {
        return images[0];
    }
}
