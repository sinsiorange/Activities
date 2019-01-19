using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

	

    public void PushMenuButton()//メニューボタンが押されたら呼ばれる
    {
        SceneManager.LoadScene("Menu");
    }
}
