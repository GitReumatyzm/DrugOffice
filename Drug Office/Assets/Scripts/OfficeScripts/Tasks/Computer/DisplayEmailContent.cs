using UnityEngine;
using TMPro; // Using TextMeshPro
using UnityEngine.UI;
using System.Collections.Generic;

public class EmailListController : MonoBehaviour
{
    [Header("UI References")]
    public List<Button> emailButtons = new List<Button>(); // Assign your email buttons here
    public Button nextButton; // Assign your "Next" button here
    public ComputerScreenController computerScreenController; // Assign your ComputerScreenController here

    [Header("Email Data")]
    private List<EmailData> allEmails = new List<EmailData>(); // All available emails
    private List<EmailData> currentEmails = new List<EmailData>(); // Emails currently displayed
    private int nextEmailIndex = 0; // Index of the next email to be added

    [System.Serializable]
    public struct EmailData
    {
        public string emailContent;
        public string answer1Text;
        public string answer2Text;

        public EmailData(string content, string answer1, string answer2)
        {
            emailContent = content;
            answer1Text = answer1;
            answer2Text = answer2;
        }
    }

    void Start()
    {
        Debug.Log("Start method called in EmailListController");

        // Initialize all emails
        InitializeAllEmails();

        Debug.Log("Total emails available: " + allEmails.Count);

        // Add the first email to the current emails list
        if (allEmails.Count > 0)
        {
            currentEmails.Add(allEmails[nextEmailIndex]);
            nextEmailIndex++;
        }

        // Initialize email buttons
        RebuildEmailButtons();

        // Add listener for the "Next" button to reveal the next email
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(ShowNextEmail);
            Debug.Log("Next button listener added");
        }
        else
        {
            Debug.LogError("Next button is not assigned in the Inspector.");
        }
    }

    void InitializeAllEmails()
    {
        allEmails.Add(new EmailData("Subject: Welcome\n(1)Dear User, Welcome to our service!", "Yes", "No"));
        allEmails.Add(new EmailData("Subject: Update\n(2)We have updated our terms of service.", "Accept", "Decline"));
        allEmails.Add(new EmailData("Subject: Newsletter\n(3)Check out our latest news in this newsletter.", "Read", "Ignore"));
        allEmails.Add(new EmailData("Subject: Welcome\n(4)Dear User, Welcome to our service!", "Got it", "Ignore"));
        allEmails.Add(new EmailData("Subject: Update\n(5)We have updated our terms of service.", "Agree", "Disagree"));
        allEmails.Add(new EmailData("Subject: Newsletter\n(6)Check out our latest news in this newsletter.", "Explore", "Skip"));
        allEmails.Add(new EmailData("Subject: Final Notice\n(7)This is your final email.", "Take Action", "Ignore"));
    }

    void RebuildEmailButtons()
    {
        Debug.Log("Rebuilding email buttons");

        // First, clear all button listeners and hide all buttons
        foreach (Button btn in emailButtons)
        {
            btn.onClick.RemoveAllListeners();
            btn.gameObject.SetActive(false);
        }

        // Assign emails to buttons
        int buttonCount = Mathf.Min(emailButtons.Count, currentEmails.Count);
        for (int i = 0; i < buttonCount; i++)
        {
            int index = i; // Local copy to avoid closure issues
            emailButtons[i].onClick.AddListener(() => OpenEmail(index));

            // Update button text (using TMP_Text)
            TMP_Text buttonText = emailButtons[i].GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = currentEmails[i].emailContent;
            }

            emailButtons[i].gameObject.SetActive(true);
        }
    }

    void OpenEmail(int emailIndex)
    {
        EmailData emailData = currentEmails[emailIndex];
        Debug.Log($"Opening email: {emailData.emailContent}");

        // Display the email content using ComputerScreenController
        if (computerScreenController != null)
        {
            computerScreenController.DisplayEmailContent(emailData.emailContent, emailData.answer1Text, emailData.answer2Text);
        }
        else
        {
            Debug.LogError("ComputerScreenController is not assigned.");
        }

        // Remove the email from the current emails list
        currentEmails.RemoveAt(emailIndex);

        // Rebuild the email buttons
        RebuildEmailButtons();

        // Check if all emails have been answered
        CheckIfAllEmailsAnswered();
    }

    void ShowNextEmail()
    {
        Debug.Log("Next button clicked");

        // Check if there are more emails to add
        if (nextEmailIndex < allEmails.Count)
        {
            // Add the next email to the current emails list
            currentEmails.Add(allEmails[nextEmailIndex]);
            nextEmailIndex++;

            // Rebuild the email buttons
            RebuildEmailButtons();
        }
        else
        {
            Debug.Log("No more emails to show.");
        }
    }

    void CheckIfAllEmailsAnswered()
    {
        Debug.Log("Checking if all emails are answered");

        if (currentEmails.Count == 0 && nextEmailIndex >= allEmails.Count)
        {
            Debug.Log("All emails have been answered.");
            LogAllEmailsUsed();
        }
    }

    void LogAllEmailsUsed()
    {
        Debug.Log("Logging all answered emails:");
        foreach (EmailData email in allEmails)
        {
            Debug.Log($"Answered email: {email.emailContent}");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
