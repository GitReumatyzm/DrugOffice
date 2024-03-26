using UnityEngine;
using UnityEngine.UI; // For UI elements like buttons
using TMPro; // For TextMeshPro elements

public class ComputerScreenController : MonoBehaviour
{
    public GameObject computerScreen; // The "ComputerScreenPanel"
    public TMP_Text emailContentText; // The "EmailContentText" TextMeshPro element
    public TMP_InputField emailResponseInput; // The "EmailResponseInput" TextMeshPro element
    public GameObject emailScrollView; // The "EmailScrollView"
    public Button closeComputerButton; // The "CloseButton" as a standard Button, not TMP_Button

    public GameObject emailContent;

    public Button back;
    public Button send;

    void Start()
    {
        computerScreen.SetActive(false); // Hide on start
        closeComputerButton.onClick.AddListener(CloseComputerScreen);
        back.onClick.AddListener(GoBack);
        send.onClick.AddListener(SendEmailResponse);
        send.onClick.AddListener(CloseComputerScreen);
    }

// Add this method to your ComputerScreenController.cs script

    public TMP_Text emailContentDisplay; // Assign in inspector, use a TextMeshPro - Text component from your UI

    public void GoBack()
    {
        emailScrollView.SetActive(true);
        emailContent.gameObject.SetActive(false);
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
    void SendEmailResponse()
    {
        if (!string.IsNullOrWhiteSpace(emailResponseInput.text))
        {
            // Log the response to the console
            Debug.Log("Email response sent: " + emailResponseInput.text);

            // Clear the input field after sending
            emailResponseInput.text = "";
            
            // Optionally, shift focus away from the input field or do additional UI management here
            // For example, to hide the response input field or to show a "response sent" message
        }
    }
}
