using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageA : Stage
{

    public Text nameText;
    public Button doneBtn;
    public Button actionBtn;
    public TrashImage trashImage;
    public RecycleBin bin;

    private TrashA trash;

    private int currentStep;

    private bool lockChange;

    public override void Init(Trash _trash)
    {
        trash = _trash as TrashA;

        currentStep = 1;

        nameText.text = trash.trashName;

        doneBtn.onClick.AddListener(() =>
        {
            if(lockChange) return;
            
            trashImage.Throw(0);
            bin.Shake(0.75f);
            Finish(currentStep == trash.targetStep);
        });
        RegisterButton(doneBtn);

        actionBtn.onClick.AddListener(() =>
        {
            ChangeState();
        });
        RegisterButton(actionBtn);

        trashImage = CreateTrashImage(trash.GetSprite(1));
    }

    void ChangeState(){
        // 애니메이션 도중 변형을 못하도록 막음
        if(lockChange) return;

        if(currentStep >= trash.targetStep)
        {
            trashImage.Vibrate();
            Finish(false);
            return;
        }

        currentStep++;

        StartCoroutine(ChangeAnimation());
    }

    IEnumerator ChangeAnimation()
    {
        lockChange = true;

        trashImage.Action();
        yield return new WaitForSeconds(0.5f);
        
        Destroy(trashImage.gameObject);

        trashImage = CreateTrashImage(trash.GetSprite(currentStep));

        yield return new WaitForSeconds(0.5f);

        lockChange = false;
    }
}
