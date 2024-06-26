using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoffeeTaskStart : MonoBehaviour, iInteractable
{ 
    [SerializeField] TextMeshProUGUI coffeeTaskText;
    [SerializeField] GameObject CoffeeCup;
    [SerializeField] GameObject CoffeeCupMachine;
    [SerializeField] BoxCollider infoCollider;
    [SerializeField] GameObject firstInfoCollider;
    public List<GameObject> playerObjects;
    public bool isCoffeTaken;

    void Start()
    {
        Debug.Log("damn");

        if(coffeeTaskText.IsActive())
        {
            firstInfoCollider.SetActive(true);
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

        if (coffeeTaskText.IsActive() && !isObjectsActive)
        {
            infoCollider.enabled = true;
            coffeeTaskText.enabled = true;
            Debug.Log("1234");
            coffeeTaskText.text = "Get this coffee to your bosses desk";
            CoffeeCupMachine.SetActive(true);
            StartCoroutine(ActivateCupAfterDelay(4.0f)); // Set delay here
            isCoffeTaken = true;
        }
    }

    IEnumerator ActivateCupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for specified delay
        CoffeeCup.SetActive(true);
        CoffeeCupMachine.SetActive(false);
    }
}
