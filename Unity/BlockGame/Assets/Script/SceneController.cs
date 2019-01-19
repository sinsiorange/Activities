using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Clear()
    {
        SceneManager.LoadScene("Clear");

    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Main");
    }
}
