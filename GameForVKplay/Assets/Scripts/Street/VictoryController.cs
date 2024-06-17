using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    private bool isVictory = false;
    [SerializeField] private GameObject minigameManager;
    private MinigameManager manager;

    private void Start()
    {
        manager = minigameManager.GetComponent<MinigameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isVictory = true;
            manager.SetVictory();
        }
    }

    public bool IsVictory() => isVictory;
}
