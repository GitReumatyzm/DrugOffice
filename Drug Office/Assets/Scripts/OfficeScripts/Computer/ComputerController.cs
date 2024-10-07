using UnityEngine;
using UnityEngine.UI; // For UI elements like buttons
using TMPro; // For TextMeshPro elements
using System.Collections.Generic;
using System.Collections;

public class ComputerScreenController : MonoBehaviour
{
    public GameObject computerScreen; // The "ComputerScreenPanel"
    public TMP_Text emailContentText; // The "EmailContentText" TextMeshPro element
    public TMP_Text emailResponse1Text;
    public TMP_Text emailResponse2Text;

    
    public Button emailResponse1;
    public Button emailResponse2;
    public GameObject emailScrollView; // The "EmailScrollView"
    public Button closeComputerButton; // The "CloseButton" as a standard Button, not TMP_Button

    public GameObject emailContent;
    public GameObject InstructionsText;

    public Button back;
    char Response = 'Z';

    [SerializeField] TextMeshProUGUI mailTaskText;
    [SerializeField] string taskDoneMessage = "DONE!";


    void Start()
    {
        //computerScreen.SetActive(false); // Hide on start
        closeComputerButton.onClick.AddListener(CloseComputerScreen);
        back.onClick.AddListener(GoBack);
        emailResponse1.onClick.AddListener(EmailResponse1act);
        emailResponse2.onClick.AddListener(EmailResponse2act);
    }

// Add this method to your ComputerScreenController.cs script

    public TMP_Text emailContentDisplay; // Assign in inspector, use a TextMeshPro - Text component from your UI

    public global::System.Char Response1 { get => Response; set => Response = value; }

    public void GoBack()
    {
        emailScrollView.SetActive(true);
        emailContent.gameObject.SetActive(false);
        mailTaskText.text = "<s> - " + taskDoneMessage + "</s>";
        StartCoroutine(destroyOnTime());
    }
    public void DisplayEmailContent(string content)
    {
        emailContentDisplay.text = content; // Display the email content in the UI
        
        // Show the content area (assuming emailContentDisplay's gameObject is the container for the content)
        emailContentDisplay.gameObject.SetActive(true);

        // Hide the email list ScrollView
        emailScrollView.SetActive(false);
        emailContent.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseComputerScreen();
        }
    }

    public void ToggleComputerScreen()
    {
        computerScreen.SetActive(!computerScreen.activeSelf);
    }

    void CloseComputerScreen()
    {
        computerScreen.SetActive(false);
        InstructionsText.SetActive(true);
        FirstPersonCamera.mouseSesnsitivity = 1000f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ToggleEmailListDisplay(bool show)
    {
        // This line shows or hides the email ScrollView based on the passed boolean
        emailScrollView.SetActive(show);

        // Optionally, when showing the email list, you might want to hide the email content display.
        if(show)
        {
            emailContentDisplay.gameObject.SetActive(false);
        }
    }

    void EmailResponse1act()
    {
        Response = 'A';
        SendEmailResponse();
    }
    void EmailResponse2act()
    {
        Response = 'B';
        SendEmailResponse();
    }
    void SendEmailResponse()
    {
        Debug.Log("Email response sent: " + Response1);
        GoBack();
        CloseComputerScreen();

    }

    IEnumerator destroyOnTime(float time = 3f)
    {
        yield return new WaitForSeconds(time);
        mailTaskText.enabled = false;
    }
}
