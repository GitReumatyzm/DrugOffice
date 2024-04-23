using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class paperTaskStart : MonoBehaviour, iInteractable
{ 
    public TextMeshProUGUI papersTaskText;
    [SerializeField] GameObject startInfoBoxCollider;
    [SerializeField] GameObject shelfInfoCollider;
    [SerializeField] GameObject documentsObject;
    public int PapersNumber = 3;

    public void Start()
    {
        if(papersTaskText.IsActive())
        {
            startInfoBoxCollider.SetActive(true);
        }
    }
    public void Interact()
    {
        if (papersTaskText.IsActive())
        {
            papersTaskText.text = $"- Get this documents to the shelf in storage room({PapersNumber})";
            documentsObject.SetActive(true);
            shelfInfoCollider.SetActive(true);
        }
    }
}
