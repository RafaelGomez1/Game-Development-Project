using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAnimation : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
        animator.SetBool("IsLifeHud", true);

    }


}
