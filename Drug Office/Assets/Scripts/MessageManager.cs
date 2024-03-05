using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public List<Message> messages = new List<Message>();
    public GameObject messageButtonPrefab;
    public Transform messageListTransform;
    public Text contentDisplay;
    public InputField replyInputField;

    void Start()
    {
        // Inicjalizacja wiadomości
        InitializeSampleMessages();

        // Generowanie przycisków
        GenerateMessageButtons();
    }

    void InitializeSampleMessages()
    {
        messages.Add(new Message("Spotkanie", "Hej! Czy jesteś dostępny na spotkanie jutro o 10:00?"));
        messages.Add(new Message("Zaproszenie", "Zapraszam Cię na urodziny Ani w następny piątek. Daj znać, czy będziesz!"));
        messages.Add(new Message("Projekt", "Cześć, przesyłam najnowszą wersję projektu. Proszę o sprawdzenie i feedback."));
    }

    void GenerateMessageButtons()
    {
        foreach (var message in messages)
        {
            var buttonObj = Instantiate(messageButtonPrefab, messageListTransform);
            buttonObj.GetComponentInChildren<Text>().text = message.subject;
            
            Message localMessage = message;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => DisplayMessageContent(localMessage));
        }
    }

    void DisplayMessageContent(Message message)
    {
        if (contentDisplay != null)
        {
            contentDisplay.text = message.content;
            message.hasBeenRead = true;
        }
        else
        {
            Debug.LogError("ContentDisplay nie został przypisany.");
        }
    }

    public void SendReply()
    {
        if (replyInputField != null)
        {
            var replyText = replyInputField.text;
            Debug.Log("Odpowiedź wysłana: " + replyText);
        }
        else
        {
            Debug.LogError("ReplyInputField nie został przypisany.");
        }
    }
}
