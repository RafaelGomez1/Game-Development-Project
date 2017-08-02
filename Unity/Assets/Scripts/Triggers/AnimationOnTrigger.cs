using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnTrigger : MonoBehaviour {

    public AudioSource painAudio;
    public Animator ani;
  

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl.sharedInstance.animator.SetTrigger("Transform");
        painAudio.Play();
        Destroy(gameObject);

       
    }




}


