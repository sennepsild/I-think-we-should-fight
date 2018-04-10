using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour {

    public GameObject objectToToggle;
    //public bool activateHUD = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.name == "SkelMesh_Bodyguard_04")
            {
                objectToToggle.SetActive(true);
                Debug.Log("target is hit");
                
            }
            else
            {
                objectToToggle.SetActive(false);
            }
        }
    }
}
