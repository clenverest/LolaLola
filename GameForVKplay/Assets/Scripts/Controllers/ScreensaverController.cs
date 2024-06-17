using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensaverController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    private Animator animator;
    [SerializeField] private GameObject startTriggerZone;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        startTriggerZone.SetActive(true);
        playerController.Unfreeze();
        StartCoroutine(Action());
    }

    private IEnumerator Action()
    {
        yield return new WaitForSeconds(3f);
        startTriggerZone.GetComponent<TeachingWASD>().enabled = true;
    }

}
