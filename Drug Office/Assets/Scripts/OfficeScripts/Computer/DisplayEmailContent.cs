using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmailListController : MonoBehaviour
{
    [Header("UI References")]
    public List<Button> emailButtons = new List<Button>(); // Assign your 7 email buttons here
    public Button nextButton; // Assign your "Next" button here
    public ComputerScreenController computerScreenController; // Assign your ComputerScreenController here

    [Header("Email Data")]
    private List<string> emails = new List<string>();
    private int currentEmailIndex = 0; // Tracks the next email to assign

    void Start()
    {
        Debug.Log("Start method called in EmailListController");

        // Initialize email content
        InitializeEmails();

        Debug.Log("Emails added, total: " + emails.Count);

        // Initialize email buttons
        InitializeEmailButtons();

        // Initially hide all email buttons except the first one
        SetInitialButtonVisibility();

        // Add listener for the "Next" button to reveal the next email button
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(ShowNextEmailButton);
            Debug.Log("Next button listener added");
        }
        else
        {
            Debug.LogError("Next button is not assigned in the Inspector.");
        }
    }

    void InitializeEmails()
    {
        AddEmail("Subject: Welcome\n(1)Dear User, Welcome to our service!");
        AddEmail("Subject: Update\n(2)We have updated our terms of service.");
        AddEmail("Subject: Newsletter\n(3)Check out our latest news in this newsletter.");
        AddEmail("Subject: Welcome\n(4)Dear User, Welcome to our service!");
        AddEmail("Subject: Update\n(5)We have updated our terms of service.");
        AddEmail("Subject: Newsletter\n(6)Check out our latest news in this newsletter.");
        AddEmail("Subject: Final Notice\n(7)This is your final email.");
    }

    void InitializeEmailButtons()
    {
        Debug.Log("Initializing email buttons");

        // Ensure we have enough emails for the buttons
        if (emailButtons.Count > emails.Count)
        {
            Debug.LogWarning("More email buttons than emails. Some buttons will remain inactive.");
        }

        for (int i = 0; i < emailButtons.Count; i++)
        {
            if (emailButtons[i] == null)
            {
                Debug.LogError($"Email button at index {i} is not assigned in the Inspector.");
                continue;
            }

            if (i < emails.Count)
            {
                int index = i; // Local copy to avoid closure issues
                emailButtons[i].onClick.RemoveAllListeners(); // Clear existing listeners

                // Assign the email data to the button
                emailButtons[i].onClick.AddListener(() => OpenEmail(emails[index], emailButtons[index]));
                Debug.Log($"Email button {i} is set up with email: {emails[index]}");
            }
            else
            {
                emailButtons[i].gameObject.SetActive(false); // Hide buttons without emails
                Debug.Log($"Email button {i} has no assigned email and is hidden.");
            }
        }
    }

    void SetInitialButtonVisibility()
    {
        for (int i = 0; i < emailButtons.Count; i++)
        {
            if (i == 0)
            {
                emailButtons[i].gameObject.SetActive(true); // Show the first button
                Debug.Log($"Email button {i} is now visible.");
                currentEmailIndex = 1; // Next email to assign
            }
            else
            {
                emailButtons[i].gameObject.SetActive(false); // Hide all others initially
                Debug.Log($"Email button {i} is hidden.");
            }
        }
    }

    void OpenEmail(string emailContent, Button emailButton)
    {
        Debug.Log($"Opening email: {emailContent}");

        // Display the email content using ComputerScreenController
        if (computerScreenController != null)
        {
            computerScreenController.DisplayEmailContent(emailContent);
        }
        else
        {
            Debug.LogError("ComputerScreenController is not assigned.");
        }

        // Hide the button after the email is opened
        emailButton.gameObject.SetActive(false);
        Debug.Log("Email button hidden after opening.");

        // Check if all emails have been answered
        CheckIfAllEmailsAnswered();
    }

    void ShowNextEmailButton()
    {
        Debug.Log("Next button clicked");

        // Check if there are more emails to assign
        if (currentEmailIndex < emails.Count)
        {
            // Find the first hidden email button
            Button nextButtonToShow = null;
            int buttonIndex = -1;

            for (int i = 0; i < emailButtons.Count; i++)
            {
                if (!emailButtons[i].gameObject.activeSelf && i < emails.Count)
                {
                    nextButtonToShow = emailButtons[i];
                    buttonIndex = i;
                    break;
                }
            }

            if (nextButtonToShow != null)
            {
                // Assign the next email to this button
                int emailIndex = currentEmailIndex;
                nextButtonToShow.onClick.RemoveAllListeners(); // Clear existing listeners
                nextButtonToShow.onClick.AddListener(() => OpenEmail(emails[emailIndex], nextButtonToShow));
                // If using images to represent emails, you might want to set the image here
                // For example:
                // nextButtonToShow.GetComponent<Image>().sprite = yourEmailSprites[emailIndex];
                nextButtonToShow.gameObject.SetActive(true);
                Debug.Log($"Email button {buttonIndex} is now visible with email: {emails[emailIndex]}");

                currentEmailIndex++; // Increment for the next email
            }
            else
            {
                Debug.Log("No available email buttons to show.");
            }
        }
        else
        {
            Debug.Log("No more emails to show.");
        }
    }

    void CheckIfAllEmailsAnswered()
    {
        Debug.Log("Checking if all emails are answered");

        bool allAnswered = true;

        foreach (Button btn in emailButtons)
        {
            if (btn.gameObject.activeSelf)
            {
                allAnswered = false;
                break;
            }
        }

        if (allAnswered)
        {
            Debug.Log("All emails have been answered.");
            LogAllEmailsUsed();
        }
    }

    void LogAllEmailsUsed()
    {
        Debug.Log("Logging all answered emails:");

        foreach (string email in emails)
        {
            Debug.Log($"Answered email: {email}");
        }
    }

    // Method to manually add an email (if needed)
    public void AddEmail(string emailContent)
    {
        emails.Add(emailContent);
        Debug.Log($"Email added: {emailContent}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
