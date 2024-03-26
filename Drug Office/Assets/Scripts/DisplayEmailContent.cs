using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic; // For using List

public class EmailListController : MonoBehaviour
{
    public GameObject emailItemPrefab; // Assign your EmailItemPrefab in the inspector
    public Transform emailListContentTransform; // Assign the content transform of your EmailScrollView
    public ComputerScreenController computerScreenController; // Reference to the ComputerScreenController script

    private List<string> emails = new List<string>(); // Example email list

    void Start()
    {
        AddEmail("Subject: Welcome\nDear User, Welcome to our service!");
        AddEmail("Subject: Update\nWe have updated our terms of service.");
        AddEmail("Subject: Newsletter\nCheck out our latest news in this newsletter.");
        
        PopulateEmailList();
    }

    void PopulateEmailList()
    {
        foreach (string email in emails)
        {
            GameObject emailItem = Instantiate(emailItemPrefab, emailListContentTransform);
            TMP_Text emailText = emailItem.GetComponentInChildren<TMP_Text>();
            Button emailButton = emailItem.GetComponent<Button>();

            if (emailText != null && emailButton != null)
            {
                emailText.text = email;
                string localEmail = email; // Local copy to avoid capturing loop variable
                emailButton.onClick.AddListener(() => OpenEmail(localEmail));
            }

        }
    }

    void OpenEmail(string emailContent)
    {
        // Assuming you have a method in ComputerScreenController to display email content
        computerScreenController.DisplayEmailContent(emailContent);
        computerScreenController.ToggleEmailListDisplay(false);
    }

    // Method to add emails to the list (for testing)
    public void AddEmail(string emailContent)
    {
        emails.Add(emailContent);
    }
}
