using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public void ChangeScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        PlayerPrefs.SetInt("sceneToLoad", sceneToLoad);
        PlayerPrefs.Save();
    }
}
