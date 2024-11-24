using UnityEngine;
using TMPro; // Using TextMeshPro
using UnityEngine.UI;

public class ComputerScreenController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject computerScreen; 
    public TMP_Text emailContentDisplay; // Using TMP_Text
    public Button closeComputerButton; 
    public GameObject emailContent;
    public Button back;

    [Header("Answer Buttons")]
    public Button answerButton1; // Assign in Inspector
    public TMP_Text answerButton1Text; // Assign TMP_Text for Answer Button 1
    public Button answerButton2; // Assign in Inspector
    public TMP_Text answerButton2Text; // Assign TMP_Text for Answer Button 2

    [Header("Task Text")]
    [SerializeField] private TMP_Text mailTaskText; // Using TMP_Text
    [SerializeField] private string taskDoneMessage = "DONE!";

    void Start()
    {
        // Assign listeners with null checks
        if (closeComputerButton != null)
            closeComputerButton.onClick.AddListener(CloseComputerScreen);
        else
            Debug.LogError("CloseComputerButton is not assigned.");

        if (back != null)
            back.onClick.AddListener(GoBack);
        else
            Debug.LogError("Back button is not assigned.");

        if (answerButton1 != null)
            answerButton1.onClick.AddListener(() => AnswerSelected(1));
        else
            Debug.LogError("Answer Button 1 is not assigned.");

        if (answerButton2 != null)
            answerButton2.onClick.AddListener(() => AnswerSelected(2));
        else
            Debug.LogError("Answer Button 2 is not assigned.");
    }

    // Display the email content and the answer button text
    public void DisplayEmailContent(string content, string answer1, string answer2)
    {
        if (emailContentDisplay != null)
        {
            emailContentDisplay.text = content;
            emailContent.SetActive(true);
            Debug.Log("Email content displayed.");
        }
        else
        {
            Debug.LogError("EmailContentDisplay is not assigned.");
        }

        // Set the answer buttons' text
        if (answerButton1Text != null && answerButton2Text != null)
        {
            answerButton1Text.text = answer1;
            answerButton2Text.text = answer2;

            answerButton1.gameObject.SetActive(true);
            answerButton2.gameObject.SetActive(true);
            Debug.Log("Answer buttons are now active with updated text.");
        }
        else
        {
            Debug.LogError("Answer button texts are not assigned.");
        }
    }

    void CloseComputerScreen()
    {
        if (computerScreen != null)
        {
            computerScreen.SetActive(false);
            Debug.Log("Computer screen closed.");
        }
        else
        {
            Debug.LogError("ComputerScreen is not assigned.");
        }
    }

    public void GoBack()
    {
        if (emailContent != null)
        {
            emailContent.SetActive(false);
            Debug.Log("Returned from email content.");
        }

        if (mailTaskText != null)
        {
            mailTaskText.text = "<s> - " + taskDoneMessage + "</s>";
            Debug.Log("Task marked as done.");
        }
        else
        {
            Debug.LogError("MailTaskText is not assigned.");
        }

        // Deactivate answer buttons
        if (answerButton1 != null && answerButton2 != null)
        {
            answerButton1.gameObject.SetActive(false);
            answerButton2.gameObject.SetActive(false);
            Debug.Log("Answer buttons are now inactive.");
        }
    }

    void AnswerSelected(int answerNumber)
    {
        Debug.Log($"Answer {answerNumber} selected.");

        // Deactivate answer buttons and go back
        if (answerButton1 != null && answerButton2 != null)
        {
            answerButton1.gameObject.SetActive(false);
            answerButton2.gameObject.SetActive(false);
        }

        GoBack();
    }
}
