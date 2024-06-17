using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    [SerializeField] Dialogue dialogue;
    private Inventory inventory;
    [SerializeField] private GameObject addItem;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        inventory = player.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Freeze();
            animator.SetBool(Animator.StringToHash("Start"), true);
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
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}
