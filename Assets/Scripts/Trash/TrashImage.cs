using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashImage : MonoBehaviour
{
    private Animator animator;

    public void Set(Sprite sprite){
        GetComponent<Image>().sprite = sprite;
        animator = GetComponent<Animator>();

        animator.Rebind();
    }

    public void Throw(int xDirection){
        animator.SetInteger("ThrowDirection", xDirection);
        animator.SetBool("ThrowAway", true);
    }

    public void Action(){
        animator.SetBool("DoAction", true);
    }

    public void Vibrate(){
        animator.SetBool("Vibrate", true);
    }
}
