using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToTheNextScene : MonoBehaviour, iInteractable 
{
    public void Interact()
    {
        TeleportToNext();
    }

    public void TeleportToNext()
    {
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator teleportAferDelay(float time = 5f)
    {
        TeleportToNext();
        yield return new WaitForSeconds(time);
    }
}
