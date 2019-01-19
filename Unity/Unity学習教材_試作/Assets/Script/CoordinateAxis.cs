using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateAxis : MonoBehaviour {

    public float posX;
    public float posY;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = new Vector3(0,0,1);


        //z座標はカメラを基準とした奥行き．
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(posX, posY, 0));
        p.y = 0;
        transform.position = p;
	}
}
