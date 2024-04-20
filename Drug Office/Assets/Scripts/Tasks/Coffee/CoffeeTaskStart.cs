using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoffeeTaskStart : MonoBehaviour, iInteractable
{ 
    [SerializeField] TextMeshProUGUI coffeeTaskText;
    [SerializeField] GameObject CoffeeCup;

    void Start()
    {
        Debug.Log("damn");
    }

    public void Interact()
    {
        coffeeTaskText.enabled = true;
        Debug.Log("essa");
        coffeeTaskText.text = $"Get this coffee to your bosses";
        CoffeeCup.SetActive(true);
    }
}
