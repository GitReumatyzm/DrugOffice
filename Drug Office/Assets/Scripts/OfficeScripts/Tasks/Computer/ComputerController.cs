using UnityEngine;
using TMPro; // Using TextMeshPro
using UnityEngine.UI;
using System.Collections;


public class ComputerScreenController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject computerScreen; 
    public TMP_Text emailContentDisplay; 
    public Button closeComputerButton; 
    public GameObject TasksText;
    public GameObject emailContent;
    public Button back;
    public GameObject player;
    public GameObject dullPlayer;
    public BoxCollider computerCollider;
    public SittingOnTheChair Script;
    public TaskText CloseTaskText;

    [Header("Answer Buttons")]
    public Button answerButton1; 
    public TMP_Text answerButton1Text; 
    public Button answerButton2; 
    public TMP_Text answerButton2Text; 

    [Header("Task Text")]
    [SerializeField] private TMP_Text mailTaskText; 
    [SerializeField] private string taskDoneMessage = "DONE!";

    void Start()
    {
        // Assign listeners with null checks
        if (closeComputerButton != null)
            closeComputerButton.onClick.AddListener(CloseComputerScreen);

        if (back != null)
            back.onClick.AddListener(GoBack);

        if (answerButton1 != null)
            answerButton1.onClick.AddListener(() => AnswerSelected(1));

        if (answerButton2 != null)
            answerButton2.onClick.AddListener(() => AnswerSelected(2));
    }

    // Display the email content and the answer button text
    public void DisplayEmailContent(string content, string answer1, string answer2)
    {
        if (emailContentDisplay != null)
        {
            emailContentDisplay.text = content;
            emailContent.SetActive(true);
        }

        // Set the answer buttons' text
        if (answerButton1Text != null && answerButton2Text != null)
        {
            answerButton1Text.text = answer1;
            answerButton2Text.text = answer2;

            answerButton1.gameObject.SetActive(true);
            answerButton2.gameObject.SetActive(true);
        }
    }

    void CloseComputerScreen()
    {
        if (computerScreen != null)
        {
            computerScreen.SetActive(false);
            CloseTaskText.CloseAfterTime();
            Script.StandUp();
        }
    }
    public void GoBack()
    {
        if (emailContent != null)
        {
            emailContent.SetActive(false);
        }

        if (mailTaskText != null)
        {
            mailTaskText.text = "<s> - " + taskDoneMessage + "</s>";
        }

        // Deactivate answer buttons
        if (answerButton1 != null && answerButton2 != null)
        {
            answerButton1.gameObject.SetActive(false);
            answerButton2.gameObject.SetActive(false);
        }
    }

    void AnswerSelected(int answerNumber)
    {
        // Deactivate answer buttons and go back
        if (answerButton1 != null && answerButton2 != null)
        {
            answerButton1.gameObject.SetActive(false);
            answerButton2.gameObject.SetActive(false);
        }

        GoBack();
    }
}
