using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    [SerializeField] private Dialogue dialogue1;
    [SerializeField] private Dialogue dialogue2;
    [SerializeField] private GameObject dialogueManager;
    private DialogueManager manager;
    private Inventory inventory;
    [SerializeField] private GameObject addItem;

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        manager = dialogueManager.GetComponent<DialogueManager>();
        inventory = player.GetComponent<Inventory>();
    }

    private bool isActivated = false;
    private bool playerDetected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = true;
            TriggerDialogue(dialogue1);
        }
    }

    private void Update()
    {
        if(playerDetected)
        {
            if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && !isActivated)
            {
                playerController.Freeze();
                animator.SetBool(Animator.StringToHash("Start"), true);
                isActivated = true;
            }
        }
    }

    public void ExitSearch()
    {
        animator.SetBool(Animator.StringToHash("Start"), false);
    }

    public void AddItem()
    {
        ExitSearch();
        inventory.AddItem(addItem);
    }

    public void ActivateDialogue()
    {
        playerController.Unfreeze();
        TriggerDialogue(dialogue2);
    }

    public void SetBookTrigger()
    {
        animator.SetTrigger("Book");
    }
}
