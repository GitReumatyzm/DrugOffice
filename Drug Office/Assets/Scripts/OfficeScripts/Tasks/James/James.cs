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

    private decimal[] amounts = new decimal[4]; // Store amounts for calculation
    private decimal totalAmount;                // Total amount

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

            // Generate a random amount between 1.00 and 10.00, to two decimal places
            int amountInCents = rnd.Next(100, 1001); // 100 to 1000 cents
            decimal amount = amountInCents / 100m;

            if (isCost)
            {
                amount = -amount; // Make it negative for costs
            }

            // Store the amount for later calculation
            amounts[i] = amount;

            // Display the item name and amount
            itemTexts[i].text = itemName;
            amountTexts[i].text = amount.ToString("F2"); // Format to two decimal places
        }

        // Calculate the total amount
        totalAmount = 0;
        foreach (decimal amt in amounts)
        {
            totalAmount += amt;
            Debug.Log(totalAmount);
        }

        // Attach the listener to the submit button
        submitButton.onClick.AddListener(CheckAnswer);
    }

    private void CheckAnswer()
    {
        decimal userTotal;
        string userInput = inputField.text.Replace('.', ','); // Allow for dot instead of comma
        if (decimal.TryParse(userInput, out userTotal))
        {
            // Allow a small tolerance in the comparison
            decimal tolerance = 0.01m;
            if (Mathf.Abs((float)(userTotal - totalAmount)) < (float)tolerance)
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
