using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Example game state variables
    public bool hasVisitedScene2 = false;
    public int playerLevel = 1;
    // Add more variables as needed

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
