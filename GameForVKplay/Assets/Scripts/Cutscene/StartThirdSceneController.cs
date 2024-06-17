using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThirdSceneController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject managerCutscene;
    private ThirdCutscene manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = managerCutscene.GetComponent<ThirdCutscene>();
    }

    private bool isActivated = false;

    public void StartScene()
    {
        if(!isActivated)
        {
            StartCoroutine(Anim());
            isActivated = true;
        }
    }

    private IEnumerator Anim()
    {
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Next");
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("Next");
        yield return new WaitForSeconds(5f);
        manager.NextScene();
    }

    public void DoTransiton()
    {
        animator.SetTrigger("Transition");
    }
}
