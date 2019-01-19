using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubMenu : MonoBehaviour {
    static Toggle clearCheckBox;
    static Toggle clearCheckBox2;

    // Use this for initialization
    void Start()
    {
        
        GameController.GameClear = PlayerPrefs.GetInt("GameClearKey", 0); //セーブデータの呼び出し。前回クリアしていれば1になる
        GameController2.GameClear2 = PlayerPrefs.GetInt("GameClearKey2", 0);
        clearCheckBox = GameObject.Find("MainMenu1").transform.Find("SubMenu1").GetComponentInChildren<Toggle>();
        clearCheckBox2 = GameObject.Find("MainMenu1").transform.Find("SubMenu2").GetComponentInChildren<Toggle>();

    }
	
	// Update is called once per frame
	void Update ()
    {    

        if (GameController.GameClear == 1)
        {
            //Toggleにチェックをいれる
            clearCheckBox.isOn = true;
        }

        if (GameController2.GameClear2 == 1)
        {
            //Toggleにチェックをいれる
            clearCheckBox2.isOn = true;
        }

    }

    public void ClickSubMenu()
    {
        switch (transform.name)
        {
            case "Explanation":
                ReturnScene.SceneBefore = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Explanation");
                break;

            case "SubMenu1":
                SceneManager.LoadScene("Transform.Translate1");
                break;

            case "SubMenu2":
                if (GameController.GameClear == 1)
                {
                    SceneManager.LoadScene("Transform.Translate2");
                }               
                break;
        }
        
    }
}
