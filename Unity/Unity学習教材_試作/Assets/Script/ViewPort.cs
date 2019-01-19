using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = new Vector3(0, 0, 1);

        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0.5f, 1.0f));
        
        transform.position = p;
    }
}
