using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecycleBin : MonoBehaviour
{
    
    public Image image;

    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    public void Set(RecycleType type){
        image.sprite = type.image;
    }

    public void Shake(float after){
        StartCoroutine(WaitAndShake(after));
    }

    IEnumerator WaitAndShake(float delay){
        yield return new WaitForSeconds(delay);
        animator.SetBool("Shake", true);
        SoundManager.Instance.PlaySFX("IntoBin", 0.0f, 0.2f);
    }
}
