using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Stage : MonoBehaviour
{
    private bool done = false;

    private List<Button> buttons = new List<Button>();

    public GameObject trashImagePrefab;

    public abstract void Init(Trash trash);

    public void RegisterButton(Button button){
        buttons.Add(button);
    }

    public void Finish(bool isSuccess){
        if(done) return;
        done = true;

        if(isSuccess)
            SoundManager.Instance.PlaySFX("Win", 0.0f, 0.3f);
        else
            SoundManager.Instance.PlaySFX("Lose", 0.0f, 0.3f);

        // TODO: Animation?
        foreach (Button button in buttons){
            Destroy(button.gameObject);
        }

        GameManager.Instance.GoToNextStage(this, isSuccess);
    }

    protected TrashImage CreateTrashImage(Sprite sprite){
        TrashImage trashImage = Instantiate(trashImagePrefab).GetComponent<TrashImage>();
        trashImage.Set(sprite);
        trashImage.transform.SetParent(transform, false);
        trashImage.transform.SetAsFirstSibling();
        return trashImage;
    }
}
