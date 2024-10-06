using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmailListController : MonoBehaviour
{
    public List<Button> emailButtons = new List<Button>(); // Your 7 email buttons
    public Button nextButton; // Button to reveal the next email button
    public ComputerScreenController computerScreenController;

    private List<string> emails = new List<string>();
    private int currentEmailIndex = 0; // Tracks the current email being shown

    void Start()
    {
        Debug.Log("Start method called in EmailListController");

        // Adding email content
        AddEmail("Subject: Welcome\n(1)Dear User, Welcome to our service!");
        AddEmail("Subject: Update\n(2)We have updated our terms of service.");
        AddEmail("Subject: Newsletter\n(3)Check out our latest news in this newsletter.");
        AddEmail("Subject: Welcome\n(4)Dear User, Welcome to our service!");
        AddEmail("Subject: Update\n(5)We have updated our terms of service.");
        AddEmail("Subject: Newsletter\n(6)Check out our latest news in this newsletter.");

        Debug.Log("Emails added, total: " + emails.Count);

        // Populate email buttons and check if they are working
        PopulateEmailButtons();
        
        Debug.Log("Email buttons populated");

        // Initially hide all mail buttons except the first one
        for (int i = 0; i < emailButtons.Count; i++)
        {
            if (i == 0)
            {
                emailButtons[i].gameObject.SetActive(true); // Show first email button
            }
            else
            {
                emailButtons[i].gameObject.SetActive(false); // Hide others
            }
        }

        Debug.Log("First email button visible, others hidden");

        // Add listener for the Next button to reveal the next email
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(ShowNextEmailButton);
            Debug.Log("Next button listener added");
        }
        else
        {
            Debug.LogError("Next button is null, check assignment in Inspector");
        }
    }


    void PopulateEmailButtons()
    {
        Debug.Log("Populating email buttons");

        for (int i = 0; i < emailButtons.Count; i++)
        {
            if (emailButtons[i] == null)
            {
                Debug.LogError("Email button at index " + i + " is null!");
                continue;
            }

            int index = i; // Local copy to avoid closure issues

            if (i < emails.Count)
            {
                // We don't need to set the text since the buttons are photos, but we still need to attach the listener
                Debug.Log("Setting up email button " + i + " for email: " + emails[i]);

                emailButtons[i].onClick.AddListener(() => OpenEmail(emails[index], emailButtons[index]));
            }
            else
            {
                Debug.LogError("Not enough emails for button " + i);
            }
        }
    }




    void OpenEmail(string emailContent, Button emailButton)
    {
        Debug.Log("Opening email: " + emailContent);

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

        // Show the next email button, if there is one
        ShowNextEmailButton();

        // Check if all emails have been answered
        CheckIfAllEmailsAnswered();
    }

    void ShowNextEmailButton()
    {
        Debug.Log("Next button clicked");

        // Reveal the next hidden email button, if there is one
        if (currentEmailIndex < emailButtons.Count - 1)
        {
            currentEmailIndex++; // Move to the next email
            Debug.Log("Current email index: " + currentEmailIndex);

            emailButtons[currentEmailIndex].gameObject.SetActive(true); // Show the next email button
            Debug.Log("Email button " + currentEmailIndex + " is now visible.");
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
            Debug.Log("Answered email: " + email);
        }
    }

    // Method to manually add an email (if needed)
    public void AddEmail(string emailContent)
    {
        emails.Add(emailContent);
        Debug.Log("Email added: " + emailContent);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
