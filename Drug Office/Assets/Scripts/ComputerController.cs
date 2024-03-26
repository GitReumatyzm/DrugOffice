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

    void Start()
    {
        computerScreen.SetActive(false); // Hide on start
        closeComputerButton.onClick.AddListener(CloseComputerScreen);
    }

// Add this method to your ComputerScreenController.cs script

    public TMP_Text emailContentDisplay; // Assign in inspector, use a TextMeshPro - Text component from your UI

    public void DisplayEmailContent(string content)
    {
        emailContentDisplay.text = content; // Display the email content in the UI
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseComputerScreen();
            FirstPersonCamera.mouseSesnsitivity = 1000f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ToggleComputerScreen()
    {
        computerScreen.SetActive(!computerScreen.activeSelf);
    }

    void CloseComputerScreen()
    {
        computerScreen.SetActive(false);
    }
}
