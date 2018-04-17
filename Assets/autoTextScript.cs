using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class autoTextScript : MonoBehaviour {

    public TextMeshProUGUI textMesh;

    string textToAppear = "Some text here";

	// Use this for initialization
	void Start () {

        textMesh = GetComponent<TextMeshProUGUI>();

        StartCoroutine("AutoType");
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}

    public IEnumerator AutoType()
    {
        foreach (char letter in textToAppear.ToCharArray())
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(0.3f);
            
        }
    }
}
