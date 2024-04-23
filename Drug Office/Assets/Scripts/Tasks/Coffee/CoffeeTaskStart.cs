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
    public bool isCoffeTaken;

    void Start()
    {
        Debug.Log("damn");
    }

    public void Interact()
    {
        infoCollider.enabled = true;
        coffeeTaskText.enabled = true;
        Debug.Log("1234");
        coffeeTaskText.text = "Get this coffee to your bosses desk";
        CoffeeCupMachine.SetActive(true);
        StartCoroutine(ActivateCupAfterDelay(2.0f)); // Set delay here
        isCoffeTaken = true;
    }

    IEnumerator ActivateCupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for specified delay
        CoffeeCup.SetActive(true);
        CoffeeCupMachine.SetActive(false);
    }
}
