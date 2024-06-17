using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeachingWASD : MonoBehaviour
{
    [SerializeField] private GameObject dialogueManager;
    private DialogueManager manager;
    [SerializeField] private GameObject canvas;
    private Animator canvasAnimator;
    [SerializeField] private TMP_Text textForMessage;
    [SerializeField] private string message;

    private void Start()
    {
        manager = dialogueManager.GetComponent<DialogueManager>();
        canvasAnimator = canvas.GetComponent<Animator>();

    }

    private bool isMessageActive = false;

    // Update is called once per frame
    void Update()
    {
        if(!isMessageActive && manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive())
        {
            textForMessage.text = message;
            canvasAnimator.SetBool("Show", true);
            isMessageActive = true;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            canvasAnimator.SetBool("Show", false);
            Destroy(gameObject);
        }
    }
}
