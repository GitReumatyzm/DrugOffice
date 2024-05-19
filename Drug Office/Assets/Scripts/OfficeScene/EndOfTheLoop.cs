using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfTheLoop : MonoBehaviour
{
    public List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    public GameObject endDayText;
    public Animator elevatorAnim1;
    public Animator elevatorAnim2;
    private string elevatorDoorOpen1 = "elevatorDoorOpen";
    private string elevatorDoorOpen2 = "elevatorDoorOpen2";

    public void Start()
    {
        taskTexts.Add(GameObject.Find("PapersTaskText").GetComponent<TextMeshProUGUI>());
        taskTexts.Add(GameObject.Find("CoffeeTaskText").GetComponent<TextMeshProUGUI>());
        taskTexts.Add(GameObject.Find("PlantTaskText").GetComponent<TextMeshProUGUI>());
        taskTexts.Add(GameObject.Find("MailTaskText").GetComponent<TextMeshProUGUI>());
    }

    public void Update()
    {
        bool isDayEnded = true;
        foreach (TextMeshProUGUI tTexts in taskTexts)
        {
            if (tTexts.enabled)
            {
                Debug.Log("foreach");
                isDayEnded = false;
                break;
            }

        }

        if (isDayEnded)
        {
            endDayText.SetActive(true);
            StartCoroutine(openingElevatorAfterDelay());
        }

    }

    IEnumerator openingElevatorAfterDelay(float time = 1f)
    {
        yield return new WaitForSeconds(time);
        elevatorAnim1.Play(elevatorDoorOpen1, 0, 0f);
        elevatorAnim2.Play(elevatorDoorOpen2, 0, 0f);
    }
}
