using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitial : MonoBehaviour {

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(2736, 1824, false, 60);
        Debug.Log("screen");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
