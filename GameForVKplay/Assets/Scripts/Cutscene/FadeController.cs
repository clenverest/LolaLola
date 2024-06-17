using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private GameObject scene;
    [SerializeField] private GameObject managerCutscene;
    private SecondCutscene manager;
    private Animator animatorScene;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorScene = scene.GetComponent<Animator>();
        manager = managerCutscene.GetComponent<SecondCutscene>();
    }

    public void ShowStart()
    {
        manager.NextScene();
    }

    public void ShowBadEnd()
    {
        animatorScene.SetTrigger("SetBadEnd");
        animator.SetTrigger("FadeBad");
    }

    public void AnimBadEnd() 
    {
        animatorScene.SetTrigger("Next");
    }
}
