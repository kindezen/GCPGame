using UnityEngine;

[CreateAssetMenu(fileName = "Trash C Data", menuName = "ScriptableObjects/Trash C", order = 1)]
public class TrashC : Trash
{
    public Sprite image;

    public RecycleType typeBottom;

    public bool throwingIsAnswer;

    // 얇은 물체를 집을 수 있도록 적절히 조정
    // 0 : 정사각형 모양에서, 오른쪽 끝을 잡음
    // 1 : 왼쪽 끝을 잡음
    [Range(0f, 1f)]
    public float handDepth;

    public override Sprite GetDefaultSprite()
    {
        return image;
    }
}
