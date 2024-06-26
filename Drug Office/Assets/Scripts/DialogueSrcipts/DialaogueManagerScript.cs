using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialaogueManagerScript : MonoBehaviour
{
    [SerializeField] Queue<string> sentences;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI npcNameText;

    private void Start()
    {
        speechText.enabled = false;
        npcNameText.enabled = false;
        sentences = new Queue<string>();
    }
    public void StartDialaogue(Dialaogue dialaogue)
    {
        speechText.enabled = true;
        npcNameText.enabled = true;

        npcNameText.text = dialaogue.npcName;

        sentences.Clear();

        foreach (string sentence in dialaogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialaogue();
            return;
        }

        string sentence = sentences.Dequeue();
        speechText.text = sentence;
    }

    public void EndDialaogue()
    {
        Debug.Log("[END]");
        speechText.enabled = false;
        npcNameText.enabled = false;
        PlayerMovement.playerSpeed = 5f;
    }


}

[System.Serializable]
public class Dialaogue
{
    public string npcName;

    [TextArea(3, 10)]
    public string[] sentences;
}
