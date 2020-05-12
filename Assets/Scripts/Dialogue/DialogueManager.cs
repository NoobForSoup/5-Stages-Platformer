using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    private bool activeDialogue = false;

    [Header("Dialogue")]
    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueContent;

    [Header("Events")]
    [Space]
    public UnityEvent OnEndEvent;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && activeDialogue)
        {
            DisplayNextSentence();
        }
    }

    private void Start()
    {
        sentences = new Queue<string>();

        if (OnEndEvent == null)
            OnEndEvent = new UnityEvent();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        activeDialogue = true;
        dialogueBox.GetComponent<Animator>().SetBool("Open", true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string content = sentence;

        StopAllCoroutines();

        bool newName = false;
        bool textStyle = false;

        if (sentence.Contains("@newname"))
        {
            string[] split = sentence.Split('\n');
            dialogueName.text = split[0].Substring(9);
            newName = true;
        }

        if (sentence.Contains("@cursive") && sentence.Contains("@bold"))
        {
            dialogueContent.fontStyle = FontStyle.BoldAndItalic;
            textStyle = true;
        }
        else
        if (sentence.Contains("@cursive"))
        {
            dialogueContent.fontStyle = FontStyle.Italic;
            textStyle = true;
        }
        else
        if (sentence.Contains("@bold"))
        {
            dialogueContent.fontStyle = FontStyle.Bold;
            textStyle = true;
        }
        else
        {
            dialogueContent.fontStyle = FontStyle.Normal;
        }

        int i = 0;

        if(newName)
        {
            i++;
        }
        if(textStyle)
        {
            i++;
        }

        content = GetLines(sentence, i);

        StartCoroutine(TypeSentence(content));
    }

    private string GetLines(string sentence, int startLine)
    {
        string[] split = sentence.Split('\n');

        string content = "";

        for (int i = startLine; i < split.Length; i++)
        {
            content += split[i] + "\n";
        }

        return content;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueContent.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueContent.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        OnEndEvent.Invoke();
        activeDialogue = false;
        dialogueBox.GetComponent<Animator>().SetBool("Open", false);
    }
}
