using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperTaskEnd : MonoBehaviour, iInteractable
{
    public TextMeshProUGUI papersTaskText;
    public string deskBossTaskText = "- Great work, fella! Now leave the rest on boss desk";
    public bool isStorageRoomDone;
    public int papersNumber;
    public GameObject bossDeskTaskInfoCollider;

    public void Interact()
    {
        Debug.Log("ock");
        if (gameObject.CompareTag("PaperStorageTask"))
        {
            Debug.Log("click");
          isStorageRoomDone = true;
          papersNumber = 2;
          papersTaskText.text = deskBossTaskText + $" ({papersNumber})";
          bossDeskTaskInfoCollider.SetActive(true);
        }
    }
}
