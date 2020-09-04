using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text npcNameText;
    public Text dialogueText;

    private List<string> conversation;
    private int convoIndex;

    public void Start()
    {
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void StartDialogue(string npcName, List<string> convo)
    {
        npcNameText.text = npcName;
        conversation = new List<string>(convo);
        dialoguePanel.SetActive(true);
        convoIndex = 0;
        ShowText();
    }

    public void StopDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    private void ShowText()
    {
        dialogueText.text = conversation[convoIndex];
    }

    public void NextSentence()
    {
        if(convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
    }

}
