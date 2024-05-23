using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperTaskBoss : MonoBehaviour, iInteractable
{
    public paperTaskEnd paperTaskEndScript;
    [SerializeField] float time = 3f;
    [SerializeField] GameObject docObj;
    [SerializeField] List<GameObject> deskDocsObjs = new List<GameObject>();
    [SerializeField] string taskEndMessage = "Noice mate";

    public void Interact()
    {
        if (gameObject.CompareTag("BossDeskTask") && paperTaskEndScript.isStorageRoomDone == true)
        {
            paperTaskEndScript.papersNumber = 0;
            paperTaskEndScript.papersTaskText.text = "<s> - " + taskEndMessage + $" ({paperTaskEndScript.papersNumber})" + "</s>";
            docObj.SetActive(false);
            foreach (GameObject obj in deskDocsObjs)
            {
                obj.SetActive(true);
            }
            StartCoroutine(destroyOnTime());
        }
    }

    IEnumerator destroyOnTime()
    {
        yield return new WaitForSeconds(time);
        paperTaskEndScript.papersTaskText.enabled = false;
        paperTaskEndScript.bossDeskTaskInfoCollider.SetActive(false);
    }
}
