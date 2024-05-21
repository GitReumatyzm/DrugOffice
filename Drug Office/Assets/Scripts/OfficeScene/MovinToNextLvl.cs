using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovinToNextLvl : MonoBehaviour, iInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene(0);
    }
}
