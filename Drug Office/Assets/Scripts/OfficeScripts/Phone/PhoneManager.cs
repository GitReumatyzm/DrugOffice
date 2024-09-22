using UnityEngine;
using System.Collections;

public class PhoneManager : MonoBehaviour
{
    public AudioClip ringTone; // Reference to the ring tone audio clip
    public AudioSource audioSource; // Reference to the audio source component

    private bool isRinging = false; // Flag to track if the phone is ringing
    private bool isAnswered = false; // Flag to track if the call is answered

    private int callCount = 0; // Track the number of calls received
    public int maxCalls = 4; // Maximum number of calls to receive

    private DialogueManager dialogueManager; // Reference to the DialogueManager script

    void Start()
    {
        // Initialize the audio source component
        audioSource = GetComponent<AudioSource>();

        // Find the DialogueManager script
        dialogueManager = FindObjectOfType<DialogueManager>();

        // Start the first call after a delay
        Invoke("ReceiveCall", 5f);
    }

    void Update()
    {
        // Check for user input to answer the phone
        if (isRinging && Input.GetKeyDown(KeyCode.Space))
        {
            AnswerCall();
        }
    }

    public void ReceiveCall()
    {
        // Start ringing the phone
        isRinging = true;
        audioSource.clip = ringTone;
        audioSource.Play();

        // Increment the call count
        callCount++;

        // If the maximum number of calls is reached, stop receiving new calls
        if (callCount >= maxCalls)
        {
            return;
        }

        // Schedule the next call after a random delay
        float delay = Random.Range(10f, 20f);
        Invoke("ReceiveCall", delay);
    }

    void AnswerCall()
    {
        // Stop ringing and mark the call as answered
        isRinging = false;
        isAnswered = true;
        audioSource.Stop();

        // Initialize the DialogueManager with the appropriate call data
        dialogueManager.InitializeCall(callCount, callCount);
    }
}