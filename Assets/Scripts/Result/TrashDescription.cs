using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashDescription : MonoBehaviour
{
    public Text nameText;
    public Image image;
    public Text descText;
    public Button prevBtn;
    public Button nextBtn;

    public void Set(Trash trash){
        nameText.text = trash.trashName;
        image.sprite = trash.GetDefaultSprite();
        descText.text = trash.trashDescription;

        prevBtn.onClick.AddListener(() => {
            ResultManager.Instance.PrevPage();
        });

        nextBtn.onClick.AddListener(() => {
            ResultManager.Instance.NextPage();
        });
    }
}
