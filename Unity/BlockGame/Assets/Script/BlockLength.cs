using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLength : MonoBehaviour
{
    SceneController sc;

    // Use this for initialization
    void Start()
    {
        sc = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            sc.Clear();
        }
    }
}