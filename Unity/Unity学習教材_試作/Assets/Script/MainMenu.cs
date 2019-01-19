using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    List<GameObject> subMenu;
	// Use this for initialization
	void Start ()
    {
        subMenu = new List<GameObject>();
        subMenu.Add(transform.Find("Explanation").gameObject);
        for(int i = 1;i <= 2;i++)
        {
            subMenu.Add(transform.Find("SubMenu"+ i).gameObject);
        }       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickMainMenu()
    {
        foreach (var x in subMenu)
        {
            if (x.activeSelf == false)
            {
                x.SetActive(true);
            }
            else
            {
                x.SetActive(false);
            }
        }
        

    }
}
