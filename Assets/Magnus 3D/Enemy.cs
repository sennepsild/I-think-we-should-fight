using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

    public float maxHealth = 100;
    float health;
    public Animator anim;
    public Image bar;

    public AudioSource audio1;

    // Use this for initialization
    void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public void Hit()
    {
        anim.SetTrigger("Hit");
        health-= 10;
        audio1.Play();

        transform.Translate(Vector3.back*0.1f);
        bar.fillAmount = health / maxHealth;
    }
}
