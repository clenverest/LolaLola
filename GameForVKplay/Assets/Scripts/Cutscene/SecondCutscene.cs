using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecondCutscene : MonoBehaviour
{
    private List<DialogueCutscene> speeches;
    private List<DialogueCutscene> choiceToAdree;
    private List<DialogueCutscene> choiceToForego;
    private List<DialogueCutscene> currentSpeeches;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject canvasWithScene;
    private Animator animatorFade;
    private Animator cutsceneAnimator;
    private Animator dialogueAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueCutsceneManager manager;
    private string triggerEnd;

    void Start()
    {
        cutsceneAnimator = cutscene.GetComponent<Animator>();
        dialogueAnimator = dialogue.GetComponent<Animator>();
        animatorFade = canvasWithScene.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueCutsceneManager>();
        var nameFriend = "Тейвел";
        var nameLola = "Лола";

        speeches = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Что будешь делать с этим? Реально искать шесть с половиной штук за три дня?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Ну, у меня уже есть целая тысяча… матушка хоть что-то успела припрятать до того как коньки отбросила…")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Этого все равно слишком мало, ты же понимаешь.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Давай, еще ты меня жизни поучи, я же сама не понимаю своего положения…")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Прости… Слушай, я завтра уезжаю…")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Куда?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "К матери, на запад."),
                new (nameFriend, "Поехали со мной? Там то они тебя в жизни не найдут, поживешь пока у меня.")
            })
        };

        choiceToAdree = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Я даже не знаю… это все так внезапно происходит…")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Пошли, помогу собрать твои вещи, автобус завтра в 9:15, не набирай лишнего.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Ага, сейчас пойдем… О боже, Тейвел, мне придется знакомиться с твоей мамой?")
            })
        };

        choiceToForego = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Прости, не могу, эта работа матери меня на другом конце земли достанет, я же давно их всех знаю, они не отстанут.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Ты уверена?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Да.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Смотри, не хочу плакать на твоих поминках раньше времени…")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "Ты всегда о смерти.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Возьми это, откладывал с подработки, немного, но хоть что-то.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "А ты как же?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "Еще заработаю, как обычно!")
            })
        };

        currentSpeeches = new(speeches);
    }

    private int i = 0;
    public void NextScene()
    {
        if(i == 0)
        {
            StartCoroutine(StartSpeech(currentSpeeches[i]));
            i++;
        }
        else if(i == speeches.Count && manager.IsDialogueActive())
        {
            dialogueAnimator.SetTrigger("SetChoice");
        }
        else if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && i < currentSpeeches.Count)
        {
            StartCoroutine(Next(currentSpeeches[i]));
            i++;
        }
        else if (i == currentSpeeches.Count && manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive())
        {
            StartCoroutine(ShowEnd());
        }
    }

    private IEnumerator StartSpeech(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }

    private IEnumerator ShowEnd()
    {
        yield return new WaitForSeconds(3f);
        animatorFade.SetTrigger(triggerEnd);
    }

    private IEnumerator Next(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        cutsceneAnimator.SetTrigger("Next");
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }

    public void Agree()
    {
        triggerEnd = "FadeBad";
        currentSpeeches.AddRange(choiceToAdree);
        manager.EndDialogue();
        NextScene();
    }

    public void Forego()
    {
        triggerEnd = "FadeGood";
        currentSpeeches.AddRange(choiceToForego);
        manager.EndDialogue();
        NextScene();
    }
}
