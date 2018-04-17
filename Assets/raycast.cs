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

    public GameObject fighter, enemy,lifeBars;
    public GameObject npc;



    public GameObject objectToToggle;
    //public bool activateHUD = false;

	// Use this for initialization
	void Start () {
        currentView = views[0];
    }
	
	// Update is called once per frame
	void Update () {
        bool looking = false;
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.name == "NpcPrefab1")
            {
                objectToToggle.SetActive(true);
                {
                    Debug.Log("target is hit");
                    looking = true;
                    if (Input.GetButtonDown("Fire1"))
                    {
                        fighter.SetActive(true);
                        enemy.SetActive(true);
                        lifeBars.SetActive(true);
                        npc.SetActive(false);

                        Destroy( player.GetComponent<FirstPersonController>());
                        print("FAGGOT!");
                        currentView = views[1];
                        transform.parent = null;

                        
                    }
                }
            }
            
        }
        if(!looking)
        {
            objectToToggle.SetActive(false);
        }



    }


    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transSpeed);
    }
}
