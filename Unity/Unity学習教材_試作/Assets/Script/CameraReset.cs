using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour {
    Vector3 cameraPosition;
    Quaternion cameraRotation;
	// Use this for initialization
	void Start () {
        cameraPosition = Camera.main.transform.position;
        cameraRotation = Camera.main.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PushCameraResetButton()
    {
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.rotation = cameraRotation;
    }
}
