using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject continueButton;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        var sceneToLoad = PlayerPrefs.GetInt("sceneToLoad");
        SceneManager.LoadScene(sceneToLoad);
    }

    private bool isMenuLoad = false;

    private void Update()
    {
        if (!isMenuLoad)
        {
            LoadMenuGame();
            isMenuLoad = true;
        }
    }

    public void LoadMenuGame()
    {
        var sceneToLoad = PlayerPrefs.GetInt("sceneToLoad");
        if(sceneToLoad == 0 && continueButton.activeInHierarchy)
        {
            continueButton.SetActive(false);
        }
        else if(sceneToLoad > 0 && !continueButton.activeInHierarchy)
        {
            continueButton.SetActive(true);
        }
    }
}
