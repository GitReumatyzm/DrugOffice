using System.Collections.Generic;
using UnityEngine;

public class DaySwitcher : MonoBehaviour
{
    [Header("Day One (Disable)")]
    public List<GameObject> dayOneObjects = new List<GameObject>();

    [Header("Day Two (Enable)")]
    public List<GameObject> dayTwoObjects = new List<GameObject>();

    // Public method to toggle the objects
    public void SwitchDayTo2()
    {
        // Disable all objects in the Day One list
        foreach (GameObject obj in dayOneObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // Enable all objects in the Day Two list
        foreach (GameObject obj in dayTwoObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
