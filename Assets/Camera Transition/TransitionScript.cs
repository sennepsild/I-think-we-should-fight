using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour {

    public Transform[] views;
    public float transSpeed;
    Transform currentView;

	void Start () {
		
	}

	void Update() {
		
        if (Input.GetKeyDown (KeyCode.A)) {
            currentView = views[0];
        }
        if (Input.GetKeyDown (KeyCode.B)) {
            currentView = views[1];
        }
	}
	void LateUpdate () {

        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transSpeed);

	}
}
