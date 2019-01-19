using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private float speed = 30f;    //これを追加
    private Rigidbody rb;
    private SceneController sc;
    
	// Use this for initialization
	void Start () {
        sc = GameObject.Find("SceneController").GetComponent<SceneController>();
        //以下を追加
        rb = this.gameObject.GetComponent<Rigidbody>();
		rb.AddForce((transform.forward + transform.right) * speed,ForceMode.VelocityChange);
        
	}	
	// Update is called once per frame
	void Update () {
        
        if (this.gameObject.transform.position.z < -3.0f)
        {
            Destroy(this.gameObject);
            sc.GameOver();
        }
	}

    void OnCollisionEnter(Collision other)
    {
        rb.velocity = rb.velocity.normalized * 30; //衝突する度に正しい値を再設定して減速しないようにする
    }
}
