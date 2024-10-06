using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerScreenController : MonoBehaviour
{
    public GameObject computerScreen; 
    public TMP_Text emailContentDisplay; // For displaying the email content
    public Button closeComputerButton; 
    public GameObject emailContent;
    public Button back;

    public Button answerButton1; // Answer button 1
    public Button answerButton2; // Answer button 2

    [SerializeField] TextMeshProUGUI mailTaskText;
    [SerializeField] string taskDoneMessage = "DONE!";

    void Start()
    {
        if (closeComputerButton != null)
            closeComputerButton.onClick.AddListener(CloseComputerScreen);

        if (back != null)
            back.onClick.AddListener(GoBack);

        if (answerButton1 != null)
            answerButton1.onClick.AddListener(() => AnswerSelected(1));
        else
            Debug.LogError("Answer Button 1 not assigned!");

        if (answerButton2 != null)
            answerButton2.onClick.AddListener(() => AnswerSelected(2));
        else
            Debug.LogError("Answer Button 2 not assigned!");
    }

    public void DisplayEmailContent(string content)
    {
        emailContentDisplay.text = content;
        emailContent.gameObject.SetActive(true);

        // Activate answer buttons
        answerButton1.gameObject.SetActive(true);
        answerButton2.gameObject.SetActive(true);
    }

    void CloseComputerScreen()
    {
        computerScreen.SetActive(false);
    }

    public void GoBack()
    {
        emailContent.gameObject.SetActive(false);
        mailTaskText.text = "<s> - " + taskDoneMessage + "</s>";

        // Deactivate answer buttons
        answerButton1.gameObject.SetActive(false);
        answerButton2.gameObject.SetActive(false);
    }

    void AnswerSelected(int answerNumber)
    {
        Debug.Log("Answer " + answerNumber + " selected.");

        // Deactivate answer buttons and go back
        answerButton1.gameObject.SetActive(false);
        answerButton2.gameObject.SetActive(false);
        GoBack();
    }
}
