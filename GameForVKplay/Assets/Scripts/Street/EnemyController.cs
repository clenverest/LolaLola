using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] moveSpots;
    private int randomSpot;
    private int randomTimeForPatrol;
    [SerializeField] float speed;
    [SerializeField] private GameObject minigameManager;
    private MinigameManager manager;

    private bool isPatrolActive;
    bool isDefeat = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isPatrolActive = false;
        randomSpot = Random.Range(0, moveSpots.Length);
        manager = minigameManager.GetComponent<MinigameManager>();
    }

    private bool isActionActive = false;
    private bool isGameActive = false;

    public void StartGame()
    {
        isGameActive = true;
        animator.SetTrigger("Walk");
    }

    void Update()
    {
        if(isGameActive)
        {
            Patrol();
            CheckDefeat();
            if (!isActionActive && !isDefeat)
            {
                Walk();
                if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.1f)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    randomTimeForPatrol = Random.Range(3, 8);
                    StartCoroutine(Action(randomTimeForPatrol));
                }
            }
        }
    }

    private void CheckDefeat()
    {
        if (isDefeat)
        {
            isGameActive = false;
            animator.SetTrigger("Defeat");
            manager.SetDefeat();
        }
    }

    private IEnumerator Action(int time)
    {
        isActionActive = true;
        animator.SetBool("Active", true);
        yield return new WaitForSeconds(time);
        animator.SetBool("Active", false);
        yield return new WaitForSeconds(1);
        isActionActive = false;
    }

    private void Walk()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        FlipEnemy(moveSpots[randomSpot].position.x);
    }

    private bool facingRight = true;

    private void Flip()
    {
        facingRight = !facingRight;
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void FlipEnemy(float nextPosition)
    {
        if (facingRight == false && transform.position.x < nextPosition)
        {
            Flip();
        }
        else if (facingRight == true && transform.position.x > nextPosition)
        {
            Flip();
        }
    }

    private void Patrol()
    {
        if (isPatrolActive && !isPlayerInSaveZone)
        {
            isDefeat = true;
        }
        else if (!isPatrolActive && !isPlayerInSaveZone)
        {
            if (facingRight == false && transform.position.x > player.transform.position.x)
            {
                isDefeat = true;
            }
            else if (facingRight == true && transform.position.x < player.transform.position.x)
            {
                isDefeat = true;
            }
        }
    }

    private bool isPlayerInSaveZone = true;


    public void SetPlayerInSafeZone()
    {
        isPlayerInSaveZone = true;
    }

    public void SetPlayerOutSafeZone()
    {
        isPlayerInSaveZone = false;
    }

    public void ActivetedPatrol()
    {
        isPatrolActive = true;
    }

    public void DisactivetedPatrol()
    {
        isPatrolActive = false;
    }

    public void SetPatrol()
    {
        animator.SetTrigger("Patrol");
        isPatrolActive = true;
    }

    public void SetWalk()
    {
        animator.SetTrigger("Walk");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isDefeat = true;
        }
    }
}
