using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject icon;
    [SerializeField] GameObject dialogue;
    Animator animatorIcon;
    Animator animatorDialogue;
    private bool isDialogueActive = false;

    private Queue<DialogueNode> speeches;

    private void Start()
    {
        speeches = new Queue<DialogueNode>();
        animatorIcon = icon.GetComponent<Animator>();
        animatorDialogue = dialogue.GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueOn();
        speeches.Clear();
        animatorDialogue.SetBool(Animator.StringToHash("Start"), true);

        foreach (var speech in dialogue.Speeches())
        {
            speeches.Enqueue(speech);
        }
        DisplayNextSpeech();
    }

    public void DisplayNextSpeech()
    {
        if (speeches.Count == 0)
        {
            EndDialogue();
            return;
        }

        var dialogueNode = speeches.Dequeue();
        nameText.text = dialogueNode.Name();
        animatorIcon.SetTrigger(dialogueNode.Mood());
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueNode.Text()));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        DialogueOff();
        animatorDialogue.SetBool(Animator.StringToHash("Start"), false);
    }

    public void DialogueOn()
    {
        isDialogueActive = true;
    }

    public void DialogueOff()
    {
        isDialogueActive = false;
    }

    public bool IsDialogueActive() => isDialogueActive;

    public bool IsSpeechesCountIsZero() => speeches.Count == 0;
}
