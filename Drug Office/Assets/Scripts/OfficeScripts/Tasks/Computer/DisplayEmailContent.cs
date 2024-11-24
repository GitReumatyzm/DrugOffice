using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmailListController : MonoBehaviour
{
    [Header("UI References")]
    public List<Button> emailButtons = new List<Button>();
    public Button nextButton;
    public ComputerScreenController computerScreenController;

    [Header("Email Data")]
    private List<EmailData> allEmails = new List<EmailData>();
    private List<EmailData> currentEmails = new List<EmailData>();
    private int nextEmailIndex = 0;

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
        InitializeAllEmails();

        if (allEmails.Count > 0)
        {
            currentEmails.Add(allEmails[nextEmailIndex]);
            nextEmailIndex++;
        }

        RebuildEmailButtons();

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(ShowNextEmail);
        }

        OpenEmail(0);
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
        foreach (Button btn in emailButtons)
        {
            btn.onClick.RemoveAllListeners();
            btn.gameObject.SetActive(false);
        }

        int buttonCount = Mathf.Min(emailButtons.Count, currentEmails.Count);
        for (int i = 0; i < buttonCount; i++)
        {
            int index = i;
            emailButtons[i].onClick.AddListener(() => OpenEmail(index));

            TMP_Text buttonText = emailButtons[i].GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = currentEmails[i].emailContent;
            }

            emailButtons[i].gameObject.SetActive(true);
        }
    }

    public void OpenEmail(int emailIndex)
    {
        EmailData emailData = currentEmails[emailIndex];

        if (computerScreenController != null)
        {
            computerScreenController.DisplayEmailContent(emailData.emailContent, emailData.answer1Text, emailData.answer2Text);
        }

        currentEmails.RemoveAt(emailIndex);
        RebuildEmailButtons();
        CheckIfAllEmailsAnswered();
    }

    void ShowNextEmail()
    {
        if (nextEmailIndex < allEmails.Count)
        {
            currentEmails.Add(allEmails[nextEmailIndex]);
            nextEmailIndex++;
            RebuildEmailButtons();
        }
    }

    void CheckIfAllEmailsAnswered()
    {
        if (currentEmails.Count == 0 && nextEmailIndex >= allEmails.Count)
        {
            LogAllEmailsUsed();
        }
    }

    void LogAllEmailsUsed()
    {
        foreach (EmailData email in allEmails)
        {
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
