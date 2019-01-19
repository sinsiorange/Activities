using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScene : MonoBehaviour {

    public static int sceneBefore;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static int SceneBefore
    {
        get { return sceneBefore; }
        set { sceneBefore = value; }
    }

    public void PushReturnButton()
    {
    
        SceneManager.LoadScene(ReturnScene.SceneBefore);
        ReturnScene.SceneBefore = 3;
    }
    
}
