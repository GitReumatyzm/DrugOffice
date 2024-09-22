using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class paperTaskStart : MonoBehaviour, iInteractable
{ 
    public TextMeshProUGUI papersTaskText;
    public List<GameObject> playerObjects;
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
        bool isObjectsActive = false;
        foreach (GameObject pObj in playerObjects)
        {
            if (pObj.activeSelf)
            {
                isObjectsActive = true;
                break;
            }
        }
        if (papersTaskText.IsActive() && !isObjectsActive)
        {
            papersTaskText.text = $"- Get this documents to the shelf in storage room({PapersNumber})";
            documentsObject.SetActive(true);
            shelfInfoCollider.SetActive(true);
        }
        else
        {
            Debug.Log("gówno");
        }
    }

}
