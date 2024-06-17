using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCutscene
{
    private DialogueCutsceneNode[] speeches;
    public DialogueCutscene(DialogueCutsceneNode[] speeches)
    {
        this.speeches = speeches;
    }
    public DialogueCutsceneNode[] Speeches() => speeches;
}

public class DialogueCutsceneNode
{
    private string name;
    private string text;

    public DialogueCutsceneNode(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    public string Name() => name;
    public string Text() => text;
}
