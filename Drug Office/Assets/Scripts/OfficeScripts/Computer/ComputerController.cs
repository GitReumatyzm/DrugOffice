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

    char Response = 'Z';

    [SerializeField] TextMeshProUGUI mailTaskText;
    [SerializeField] string taskDoneMessage = "DONE!";

    void Start()
    {
        closeComputerButton.onClick.AddListener(CloseComputerScreen);
        back.onClick.AddListener(GoBack);
    }

    public void DisplayEmailContent(string content)
    {
        emailContentDisplay.text = content;
        emailContent.gameObject.SetActive(true);
    }

    void CloseComputerScreen()
    {
        computerScreen.SetActive(false);
    }

    public void GoBack()
    {
        emailContent.gameObject.SetActive(false);
        mailTaskText.text = "<s> - " + taskDoneMessage + "</s>";
    }
}
