using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {


    float duration = 0;
    public GameObject ExplosionPrefab;

    public Transform rFoot,lFoot;

    bool dead = false;

    public Transform playerTrans;
    public float maxHealth = 100;
    float health;
    Animator anim;
    bool Ultimating = false;
    public Image bar;
     Fighter1 playerFigh;

    public AudioSource audio1;
    public AudioSource shinderu;
    public AudioSource Anthem;

    // Use this for initialization
    void Start () {
        playerFigh = playerTrans.gameObject.GetComponent<Fighter1>();

        anim = GetComponent<Animator>();
        health = maxHealth;
	}

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            if (health > 50)
            {
                if (GetDistanceTOPlayer() > 1.4f)
                {
                    if (duration <= 0)
                    {
                        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
                        anim.SetFloat("Horizontal", 0.5f);
                    }
                }
                else
                {
                    anim.SetFloat("Horizontal", 0);
                    if (duration <= 0)
                    {
                        duration += 1.5f;
                        DoATTACK();
                    }

                }
            }
            else
            {
                if (!Ultimating)
                {
                    shinderu.Play();
                    Anthem.Play();
                }
                Ultimating = true;
                anim.SetBool("Ultimate", true);
            }

            if (transform.position.z < playerTrans.position.z)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }


            if (duration > 0)
                duration -= Time.deltaTime;
            
        }


       
    }

    public void DoATTACK()
    {
        anim.SetTrigger("EnemyKick");
    }

    public float GetDistanceTOPlayer()
    {
        float dist = transform.position.z - playerTrans.position.z;
        if (dist < 0)
            dist = dist * -1;
        return dist;

    }

    public void KickHit()
    {
        GameObject exp = Instantiate(ExplosionPrefab);
        exp.transform.position = rFoot.position;
        Destroy(exp, 3);
        playerFigh.PlayExplosionSOund();

        if (CheckIfHit(rFoot))
        {
            playerFigh.DAMAGE();
        }

    }
    public void UltiLeft()
    {
        GameObject exp = Instantiate(ExplosionPrefab);
        exp.transform.position = lFoot.position;
        Destroy(exp, 3);
        playerFigh.PlayExplosionSOund();

        if (CheckIfHit(lFoot))
        {
            playerFigh.DAMAGE();
        }

    }
    public void UltiRight()
    {
        GameObject exp = Instantiate(ExplosionPrefab);
        exp.transform.position = rFoot.position;
        Destroy(exp, 3);
        playerFigh.PlayExplosionSOund();

        if (CheckIfHit(rFoot))
        {
            playerFigh.DAMAGE();
        }

    }




    public void Hit()
    {
        if (dead == false)
        {
            print(anim.name);
            if (!Ultimating)
                anim.SetTrigger("Hit");
            health -= 10;
            audio1.Play();

            transform.Translate(Vector3.back * 0.1f);
            bar.fillAmount = health / maxHealth;


            if (health <= 0)
            {
                Anthem.Stop();
                playerTrans.gameObject.GetComponent<Fighter1>().theLittleViewerScript.ReturnToLook();
                dead = true;
                anim.SetBool("Ultimate", false);
                anim.SetBool("dead", true);
                anim.SetTrigger("DIE");
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<CapsuleCollider>());
            }
        }
    }


    public bool CheckIfHit(Transform tPos)
    {
        float ZDistance = tPos.position.z - playerTrans.position.z;
        if (ZDistance < 0)
            ZDistance *= -1;
        float YDistance = tPos.position.y - playerTrans.position.y;



        if (ZDistance < 0.6 && YDistance < 1.85 && YDistance > 0)
            return true;
        return false;
    }

}
