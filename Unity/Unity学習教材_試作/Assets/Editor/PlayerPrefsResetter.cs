using UnityEngine;
using UnityEditor;

public class PlayerPrefsResetter
{

    [MenuItem("Tools/Reset PlayerPrefs")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Reset PlayerPrefs");
    }
}
