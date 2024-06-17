using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCutscene : MonoBehaviour
{
    private List<DialogueCutscene> speeches;
    private List<DialogueCutscene> choiceToAdree;
    private List<DialogueCutscene> choiceToForego;
    private List<DialogueCutscene> currentSpeeches;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject dialogue;
    private Animator cutsceneAnimator;
    private Animator dialogueAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueCutsceneManager manager;

    private string trigger;


    void Start()
    {
        trigger = "Next";
        cutsceneAnimator = cutscene.GetComponent<Animator>();
        dialogueAnimator = dialogue.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueCutsceneManager>();
        var nameLola = "Лола";

        speeches = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Ничего себе ему там набросали, а главное - за что? Хоть бы пел или на гитаре играл…"),
                new (nameLola, "Интересно, он спит? Если я заберу его мелочь… Мне сейчас неважно, откуда деньги…"),
                new ("", "")
            })
        };

        choiceToAdree = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Я буду гореть в аду за такое, но зато сейчас поживу подольше, не так плохо!")
            }),
        };

        choiceToForego = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Да, его деньги помогли бы немного, но ничего, придумаю что-нибудь другое…")
            }),
        };

        currentSpeeches = new(speeches);
    }

    private int i = 0;
    public void NextScene()
    {
        if (i == speeches.Count && manager.IsSpeechesCountIsZero() && manager.IsDialogueActive())
        {
            dialogueAnimator.SetTrigger("SetChoice");
        }
        else if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && i < currentSpeeches.Count)
        {
            StartCoroutine(Next(currentSpeeches[i]));
            i++;
        }
        else if (currentSpeeches.Count == i && manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive())
        {
            cutsceneAnimator.SetTrigger("Transition");
        }
    }

    IEnumerator Next(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        cutsceneAnimator.SetTrigger(trigger);
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }

    public void Agree()
    {
        currentSpeeches.AddRange(choiceToAdree);
        manager.EndDialogue();
        trigger = "Agree";
        NextScene();
    }

    public void Forego()
    {
        currentSpeeches.AddRange(choiceToForego);
        manager.EndDialogue();
        trigger = "Forego";
        NextScene();
    }
}
