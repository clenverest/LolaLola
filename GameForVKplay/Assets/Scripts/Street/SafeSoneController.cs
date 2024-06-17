using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSoneController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = enemy.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyController.SetPlayerInSafeZone();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyController.SetPlayerOutSafeZone();
        }
    }
}
