using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMove : MonoBehaviour {

    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        float moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
        transform.Translate(moveH,0.0f,moveV);
		/*if (Input.GetKey(KeyCode.RightArrow))
			transform.position += new Vector3(3.0f , 0.0f , 0.0f) * Time.deltaTime;

		if (Input.GetKey(KeyCode.LeftArrow))
			transform.position += new Vector3(-3.0f , 0.0f , 0.0f) * Time.deltaTime;*/
	}
}
