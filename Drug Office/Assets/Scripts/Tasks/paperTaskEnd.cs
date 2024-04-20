using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperTaskEnd : MonoBehaviour, iInteractable
{
    [SerializeField] TextMeshProUGUI papersTaskText;
    [SerializeField] float time = 3f;
    [SerializeField] GameObject docObj;
    [SerializeField] List<GameObject> deskDocsObjs = new List<GameObject>();
    public bool isStorageRoomDone;
    private int papersNumber;

    public void Interact()
    {
        if (gameObject.CompareTag("PaperStorageTask"))
        {
          isStorageRoomDone = true;
          papersNumber = 2;
          papersTaskText.text = $"- Great work, fella! Now leave the rest on boss desk ({papersNumber})";
        }
        else if(gameObject.CompareTag("BossDeskTask") && isStorageRoomDone)
        {
            papersNumber = 0;
            papersTaskText.text = $"- Noice mate ({papersNumber})";
            papersTaskText.text = "<s>" + papersTaskText.text + "</s>";
            docObj.SetActive(false);
            foreach(GameObject obj in deskDocsObjs)
            {
                obj.SetActive(true);
            }
            StartCoroutine(destroyOnTime());
        }
    }

    IEnumerator destroyOnTime()
    {
        yield return new WaitForSeconds(time);
       papersTaskText.enabled = false;
    }
}
