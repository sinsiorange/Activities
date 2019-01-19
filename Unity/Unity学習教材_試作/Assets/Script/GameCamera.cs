using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
        }

        // WASDで移動する
        float x = 0.0f;
        float z = 0.0f;
        float y = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            x += 0.5f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 0.5f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            z += 0.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z -= 0.5f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            y += 0.5f;
        }
        if (Input.GetKey(KeyCode.C))
        {
            y -= 1.0f;
        }


        transform.Translate(x,y,z);
    }
}
