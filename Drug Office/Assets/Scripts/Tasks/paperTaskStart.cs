using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class paperTaskStart : MonoBehaviour, iInteractable
{ 
    public TextMeshProUGUI papersTaskText;
    [SerializeField] GameObject documentsObject;
    public int PapersNumber = 3;

    public void Interact()
    {
        papersTaskText.enabled = true;
        papersTaskText.text = $"- Get this documents to the shelf in storage room({PapersNumber})";
        documentsObject.SetActive(true);
    }
}
