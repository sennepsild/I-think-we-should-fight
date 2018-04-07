using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBotTrigger : MonoBehaviour {
    Animator animator;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<BotWaypointPatrol>().patroling == true)
            animator.SetBool("walking", true);
        else
            animator.SetBool("walking", false);


    }
}
