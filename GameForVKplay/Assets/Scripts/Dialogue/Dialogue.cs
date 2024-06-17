using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] DialogueNode[] speeches;

    public DialogueNode[] Speeches() => speeches;
}

[System.Serializable]
public class DialogueNode
{
    [SerializeField] string name;
    [SerializeField] string mood;
    [SerializeField] string text;

    public string Name() => name;
    public string Mood() => mood;
    public string Text() => text;
}
