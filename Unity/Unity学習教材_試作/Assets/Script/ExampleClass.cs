using System.Collections;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{ 
	void Start ()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.Translate(1,0,2);
        }
	}	
}
