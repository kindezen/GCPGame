using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageC : Stage
{
    public Text nameText;
    public Button stopBtn;
    public Image trashImage;
    public Animator trashImageAnimator;
    public Animator handAnimator;
    public Image handImage;
    public RecycleBin bin;
    public Image timer;

    private TrashC trash;
    
    public float delayTime = 3f;

    private Coroutine throwCoroutine;
    

    public override void Init(Trash _trash)
    {
        trash = _trash as TrashC;

        nameText.text = trash.trashName;

        stopBtn.onClick.AddListener(() =>
        {
            trashImageAnimator.SetBool("Stop", true);
            handAnimator.SetBool("Stop", true);

            if(throwCoroutine != null){
                StopCoroutine(throwCoroutine);
                throwCoroutine = null;
            }
            
            Finish(!trash.throwingIsAnswer);
        });
        RegisterButton(stopBtn);

        trashImage.sprite = trash.image;

        bin.Set(trash.typeBottom);

        throwCoroutine = StartCoroutine(Throw());

        //Vector2 handSize = handImage.rectTransform.sizeDelta;
        //handSize = new Vector2(Mathf.Lerp(500f, 850f, trash.handDepth), handSize.y);
        //handImage.rectTransform.sizeDelta = handSize;
    }

    IEnumerator Throw(){
        float start = Time.time;
        while(Time.time - start < delayTime){
            timer.rectTransform.localScale = new Vector3(1f - (Time.time - start) / delayTime, 1f);
            yield return null;
        }
        timer.rectTransform.localScale = new Vector3(0, 1, 1);

        Finish(trash.throwingIsAnswer);
        bin.Shake(0.75f);
    }
}