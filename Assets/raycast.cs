using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class raycast : MonoBehaviour {

    public Transform[] views;
    public float transSpeed;
    Transform currentView;
    bool TargetChosen = false;
    public GameObject player;

    public GameObject  enemy,lifeBars;
    public GameObject[] fighter;
    public GameObject[] npc;

    Transform parent;


    bool isFighting = false;

    public GameObject objectToToggle;
    //public bool activateHUD = false;

	// Use this for initialization
	void Start () {
        currentView = views[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (isFighting == false)
        {
            bool looking = false;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                //Debug.Log(hit.transform.name);
                if (isNpc(hit.transform.gameObject))
                {

                    objectToToggle.SetActive(true);
                    {
                        int index = GetFighterIndex(hit.transform.gameObject);

                        Debug.Log("target is hit");
                        looking = true;
                        if (Input.GetButtonDown("Fire1"))
                        {
                            fighter[index].SetActive(true);
                            enemy.SetActive(true);
                            lifeBars.SetActive(true);
                            npc[index].SetActive(false);
                            enemy.GetComponent<Fighter1>().enemy = fighter[index].transform;

                            player.GetComponent<FirstPersonController>().isInuse = false;
                            print("FAGGOT!");
                            currentView = views[1];
                            parent = transform.parent;
                            transform.parent = null;
                            isFighting = true;
                            objectToToggle.SetActive(false);

                        }
                    }
                }

            }
            if (!looking)
            {
                objectToToggle.SetActive(false);
            }


        }
    }

    bool isNpc(GameObject target)
    {
        for (int i = 0; i < npc.Length; i++)
        {
            if (target == npc[i])
                return true;
        }
        return false;
    }

    int GetFighterIndex(GameObject target)
    {
        for (int i = 0; i < npc.Length; i++)
        {
            if (target == npc[i])
                return i;
        }
        return 1000;
    }


    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transSpeed);
    }

    public void ReturnToLook()
    {
        transform.parent = parent;
        currentView = views[0];
        player.GetComponent<FirstPersonController>().isInuse = true;
        lifeBars.SetActive(false);
        enemy.SetActive(false);
        isFighting = false;
    }
}
