using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoffeeTaskEnd : MonoBehaviour, iInteractable
{
    [SerializeField] TextMeshProUGUI coffeeTaskText;
    [SerializeField] float time = 3f;
    [SerializeField] GameObject CoffeeCupPlayer;
    [SerializeField] GameObject CoffeeCupDesk1;
    [SerializeField] GameObject CoffeeCupDesk2;

    public void Interact()
    {
        coffeeTaskText.text = "<s>" + coffeeTaskText.text + "</s>";
        StartCoroutine(destroyOnTime());
        CoffeeCupPlayer.SetActive(false);
        CoffeeCupDesk1.SetActive(true);
        CoffeeCupDesk2.SetActive(true);
    }

    IEnumerator destroyOnTime()
    {
        yield return new WaitForSeconds(time);
       coffeeTaskText.enabled = false;
    }
}
