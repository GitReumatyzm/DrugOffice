using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperTaskEnd : MonoBehaviour, iInteractable
{
    [SerializeField] TextMeshProUGUI papersTaskText;
    [SerializeField] float time = 3f;
    [SerializeField] string taskCompletedString = "DONE!";
    [SerializeField] GameObject playerDocumentsObject;
    public void Interact()
    {
        papersTaskText.text = taskCompletedString;
        StartCoroutine(destroyOnTime());
        playerDocumentsObject.SetActive(false);
    }

    IEnumerator destroyOnTime()
    {
        yield return new WaitForSeconds(time);
       papersTaskText.enabled = false;
    }
}
