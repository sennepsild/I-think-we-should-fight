using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter1 : MonoBehaviour {

    Animator animator;
    float kickSpeedMultiplier = 1;
    public float jumpHeight;
    public ParticleSystem explosion;
    float cool = 0;
   
    AudioSource audio2;

    // Use this for initialization
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        cool -= Time.deltaTime;

        float h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") < 0)
            animator.SetBool("Crouching", true);
        else
            animator.SetBool("Crouching", false);


        if (h > 0||IsGrounded()==false)
            h = h * 2;

        transform.Translate(Vector3.forward * h * Time.deltaTime* kickSpeedMultiplier);
        animator.SetFloat("Horizontal", h);

        if (Input.GetButtonDown("Fire1")&& kickSpeedMultiplier!=0)
            animator.SetTrigger("Punch1");

        if (Input.GetButtonDown("Fire2") )
            animator.SetTrigger("Kick1");

        if (Input.GetAxis("Vertical") > 0 && cool <= 0 && IsGrounded() && kickSpeedMultiplier ==1)
        {
            print("jump!");
            cool = 0.5f;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);

        }


        if (IsGrounded() == false)
            animator.SetBool("Grounded", false);
        else
            animator.SetBool("Grounded", true);
    }


    public void StartKick()
    {
        kickSpeedMultiplier = 0;
        
    }
    public void EndKick()
    {
        kickSpeedMultiplier = 1;
        print("end KICK!");
    }
    public void Hit()
    {
        explosion.Play();
        audio2.Play();
    }


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.04f);

    }

    public void Jump()
    {

        
    }


}
