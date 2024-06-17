using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Push()
    {
        animator.SetTrigger("Push");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
