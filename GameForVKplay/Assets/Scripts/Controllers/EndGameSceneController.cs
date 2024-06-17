using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject telephoneTrigger;
    private Telephone telephone;
    [SerializeField] private GameObject player;
    private Inventory inventory;
    [SerializeField] private GameObject money;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject canvas;
    private Animator canvasAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueManager manager;

    private void Start()
    {
        telephone = telephoneTrigger.GetComponent<Telephone>();
        inventory = player.GetComponent<Inventory>();
        canvasAnimator = canvas.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueManager>();
    }

    private bool isEndScene = false;
    private bool isFadeScene = false;

    private void Update()
    {
        if (!isEndScene && telephone.IsDialogActivated() && inventory.Contains(knife) && inventory.CheckAmount(money, 2))
        {
            isEndScene = true;
            StartCoroutine(Stay());
        }
        else if (isFadeScene && !manager.IsDialogueActive())
        {
            StartCoroutine(Fade());
        }
    }

    private IEnumerator Stay()
    {
        yield return new WaitForSeconds(5f);
        isFadeScene = true;
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(5f);
        canvasAnimator.SetTrigger("Next");
    }
}
