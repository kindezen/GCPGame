using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageB : Stage
{

    public Text nameText;
    public Button leftBtn;
    public Button rightBtn;
    public TrashImage trashImage;
    public RecycleBin leftBin;
    public RecycleBin rightBin;

    private TrashB trash;

    public override void Init(Trash _trash)
    {
        trash = _trash as TrashB;

        nameText.text = trash.trashName;

        leftBtn.onClick.AddListener(() =>
        {
            Choice(TrashB.Choice.LEFT);
        });
        leftBtn.GetComponentInChildren<Text>().text = trash.typeLeft.typeName;
        RegisterButton(leftBtn);

        rightBtn.onClick.AddListener(() =>
        {
            Choice(TrashB.Choice.RIGHT);
        });
        rightBtn.GetComponentInChildren<Text>().text = trash.typeRight.typeName;
        RegisterButton(rightBtn);

        trashImage = CreateTrashImage(trash.image);

        leftBin.Set(trash.typeLeft);
        rightBin.Set(trash.typeRight);
    }

    void Choice(TrashB.Choice choice){
        if(choice == TrashB.Choice.LEFT){
            trashImage.Throw(-1);
            leftBin.Shake(0.75f);
        }
        else{
            trashImage.Throw(1);
            rightBin.Shake(0.75f);
        }
        Finish(choice == trash.answer);
    }
}
