using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantWaterTask : MonoBehaviour, iInteractable
{
    [SerializeField] GameObject waterPlantTaskText;
    [SerializeField] string EndTaskMessage = "*sounds of draining water*";
    [SerializeField] GameObject plantTaskInfoCollider;
    [SerializeField] float time = 3f;

    public void Start()
    {
        if (waterPlantTaskText.activeSelf)
        {
            plantTaskInfoCollider.SetActive(true);
        }
    }
    public void Interact()
    {
        //waterPlantTaskText. = "<s> - " + EndTaskMessage + "</s>";
        StartCoroutine(destroyOnTime());
    }

    IEnumerator destroyOnTime()
    {
        yield return new WaitForSeconds(time);
        waterPlantTaskText.SetActive(false);
    }
}
