using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Reference to the UI Text component for displaying dialogue
    public Button[] optionButtons; // References to the UI Button components for dialogue options

    private string[][] dialogueLines; // 2D array to hold the dialogue lines for each call
    private int currentLine = 0; // Index of the current dialogue line
    private int currentCallCount; // Variable to store the current call count

    void Start()
    {
        // Initialize the dialogue lines for the different calls
        dialogueLines = new string[][]
        {
            new string[] // Call 1
            {
                "Hello, this is John calling.",
                "How can I assist you today?",
                "...",
                "..."
            },
            new string[] // Call 2
            {
                "Hi, this is Sarah from customer support.",
                "I'm calling to follow up on your recent order.",
                "...",
                "..."
            },
            new string[] // Call 3
            {
                "Good morning, this is Mike from the sales team.",
                "I have a special offer for you today.",
                "...",
                "..."
            },
            new string[] // Call 4
            {
                "Hello, this is Emily from the marketing department.",
                "I wanted to invite you to our upcoming event.",
                "...",
                "..."
            }
        };
    }

    public void InitializeCall(int callIndex, int callCount)
    {
        // Reset the dialogue state
        currentLine = 0;
        currentCallCount = callCount; // Store the call count

        // Display the first dialogue line for the current call
        dialogueText.text = dialogueLines[callIndex - 1][currentLine];

        // Set up the dialogue options
        SetupDialogueOptions(callIndex);
    }

    void SetupDialogueOptions(int callIndex)
    {
        // Clear any existing options
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(false);
        }

        // Add new options based on the current dialogue line
        switch (currentLine)
        {
            case 1:
                optionButtons[0].gameObject.SetActive(true);
                optionButtons[0].GetComponentInChildren<Text>().text = "Option 1";
                optionButtons[1].gameObject.SetActive(true);
                optionButtons[1].GetComponentInChildren<Text>().text = "Option 2";
                break;
            // Add more cases for different dialogue lines and options
        }
    }

    public void SelectOption(int optionIndex)
    {
        // Handle the selected option
        // ...

        // Advance to the next dialogue line
        currentLine++;
        if (currentLine < dialogueLines[currentCallCount - 1].Length)
        {
            dialogueText.text = dialogueLines[currentCallCount - 1][currentLine];
            SetupDialogueOptions(currentCallCount);
        }
        else
        {
            // End of dialogue, reset for the next call
            currentLine = 0;
        }
    }
}