using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfTheLoop : MonoBehaviour, iInteractable
{
    public List<GameObject> taskTexts;
    public GameObject endDayText;
    public elevatorOpen elevatorOpenScript;


    public void Interact()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        bool isDayEnded = true;
        foreach (GameObject tTexts in taskTexts)
        {
            if (tTexts.activeSelf)
            {
                Debug.Log("foreach");
                isDayEnded = false;
                break;
            }
        }

        if(isDayEnded)
        {
            elevatorOpenScript.enabled = true;
            endDayText.SetActive(true);
        }
    }
}
