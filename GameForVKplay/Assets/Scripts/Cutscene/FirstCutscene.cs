using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstCutscene : MonoBehaviour
{
    private DialogueCutscene[] speeches;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject canvas;
    private Animator cutsceneAnimator;
    private Animator canvasAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueCutsceneManager manager;


    void Start()
    {
        cutsceneAnimator = cutscene.GetComponent<Animator>();
        canvasAnimator = canvas.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueCutsceneManager>();
        var nameDiller = "Диллер";
        var nameLola = "Лола";

        speeches = new DialogueCutscene[]
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, "Слушай, ты мне по большому счету ничего не должна, но видит Бог, твоя мамаша оставила после себя пару неоплаченных долгов.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "И сколько там стоило то, что она смыла в унитаз?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, "Шесть с половиной.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "И где мне столько найти за несколько дней? Даже сестра матери потратила последние на кремацию…")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, "Меня не особо волнует, где и как, но если не найдешь до четверга - отправишься за мамочкой вслед, ты меня знаешь…")
            })
        };
    }

    public void StartScene()
    {
        manager.StartDialogue(speeches[i]);
        i++;
    }

    private int i = 0;
    public void NextScene()
    {
        if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && i < speeches.Length)
        {
            StartCoroutine(Next(speeches[i]));
            i++;
        }
        else if (!manager.IsDialogueActive() && i == speeches.Length)
        {
            canvasAnimator.SetTrigger("Next");
        }
    }


    IEnumerator Next(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        cutsceneAnimator.SetTrigger("Next");
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }
}
