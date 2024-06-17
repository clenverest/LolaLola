using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFirstScene : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneManager;
    private FirstCutscene manager;

    private void Start()
    {
        manager = cutsceneManager.GetComponent<FirstCutscene>();
    }

    public void StartScene()
    {
        manager.StartScene();
    }
}
