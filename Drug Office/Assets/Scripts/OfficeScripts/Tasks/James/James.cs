using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class James : MonoBehaviour 
{
    public TMP_Text[] itemTexts;      // Text components for item names
    public TMP_Text[] amountTexts;    // Text components for amounts
    public TMP_InputField inputField; // Input field for user to enter total
    public Button submitButton;       // Submit button
    public GameObject canvasToClose;  // Canvas to close after submission

    private int[] amounts = new int[4]; // Store amounts as integers for calculation
    private int totalAmount;           // Total amount as integer

    private void Start()
    {
        // Initialize lists of cost and profit items
        List<string> costItems = new List<string>()
        {
            "Shipping",
            "Hiring Contractor",
            "Office Supplies",
            "Equipment Rental",
            "Utility Bills"
        };

        List<string> profitItems = new List<string>()
        {
            "Sold Equipment",
            "Grants from the EU",
            "Consulting Income",
            "Product Sales",
            "Service Fees"
        };

        System.Random rnd = new System.Random();

        for (int i = 0; i < 4; i++)
        {
            // Randomly decide if the item is a cost or profit
            bool isCost = rnd.Next(0, 2) == 0;

            string itemName;

            if (isCost && costItems.Count > 0)
            {
                // Select a random cost item
                int index = rnd.Next(costItems.Count);
                itemName = costItems[index];
                costItems.RemoveAt(index); // Remove to avoid duplicates
            }
            else if (!isCost && profitItems.Count > 0)
            {
                // Select a random profit item
                int index = rnd.Next(profitItems.Count);
                itemName = profitItems[index];
                profitItems.RemoveAt(index);
            }
            else if (costItems.Count > 0)
            {
                // If profit items are exhausted, select from cost items
                isCost = true;
                int index = rnd.Next(costItems.Count);
                itemName = costItems[index];
                costItems.RemoveAt(index);
            }
            else
            {
                // If cost items are exhausted, select from profit items
                isCost = false;
                int index = rnd.Next(profitItems.Count);
                itemName = profitItems[index];
                profitItems.RemoveAt(index);
            }

            // Generate a random whole number amount between 1 and 10
            int amount = rnd.Next(1, 11); // 1 to 10 inclusive

            if (isCost)
            {
                amount = -amount; // Make it negative for costs
            }

            // Store the amount for later calculation
            amounts[i] = amount;

            // Display the item name and amount
            itemTexts[i].text = itemName;
            amountTexts[i].text = amount.ToString(); // No decimal places
        }

        // Calculate the total amount
        totalAmount = 0;
        foreach (int amt in amounts)
        {
            totalAmount += amt;
            Debug.Log(totalAmount);
        }

        // Attach the listener to the submit button
        submitButton.onClick.AddListener(CheckAnswer);
    }

    private void CheckAnswer()
    {
        int userTotal;
        if (int.TryParse(inputField.text, out userTotal))
        {
            if (userTotal == totalAmount)
            {
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("Wrong");
            }
            
            // Close the canvas after submission
            canvasToClose.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Debug.Log("Please enter a valid number.");
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
