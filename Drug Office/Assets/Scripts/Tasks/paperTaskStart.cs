using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class paperTaskStart : MonoBehaviour, iInteractable
{ 
    [SerializeField] TextMeshProUGUI papersTaskText;
    [SerializeField] GameObject documentsObject;
    private int randomPapersNumber;

    void Start()
    {
        papersTaskText.enabled = false;
        randomPapersNumber = Random.Range(1, 4);
    }

    public void Interact()
    {
        papersTaskText.enabled = true;
        Debug.Log("essa");
        papersTaskText.text = $"Papers: {randomPapersNumber}";
        documentsObject.SetActive(true);
    }
}
