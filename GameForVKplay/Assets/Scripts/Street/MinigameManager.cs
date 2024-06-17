using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;

    private Animator canvasAnimator;
    private EnemyController enemyController;
    private PlayerController playerController;

    private void Start()
    {
        canvasAnimator = canvas.GetComponent<Animator>();
        enemyController = enemy.GetComponent<EnemyController>();
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        
    }

    public void SetVictory()
    {
        canvasAnimator.SetTrigger("Victory");
    }

    public void SetDefeat()
    {
        canvasAnimator.SetTrigger("Defeat");
    }

    public void NextPage()
    {
        canvasAnimator.SetTrigger("Next");
    }

    public void StartGame()
    {
        canvasAnimator.SetTrigger("Next");
        enemyController.StartGame();
        playerController.Unfreeze();
    }
}
