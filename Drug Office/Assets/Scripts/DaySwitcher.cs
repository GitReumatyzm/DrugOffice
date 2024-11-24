using UnityEngine;

public class DaySwitcher : MonoBehaviour
{
    // Reference to game objects that need to be toggled
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    void Start()
    {
        if (GameManager.Instance.hasVisitedScene2)
        {
            // Activate certain objects
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }

            // Deactivate certain objects
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            // Default state when first entering Scene 1
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(true);
            }
        }
    }
}
