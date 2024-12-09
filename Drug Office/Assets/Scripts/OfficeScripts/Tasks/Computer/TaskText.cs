
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI OneTaskText;
    void Start()
    {
        
    }
    public void CloseAfterTime()
    {
        StartCoroutine(DisableOneTaskTextAfterDelay());
    }
        private IEnumerator DisableOneTaskTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        OneTaskText.enabled = false;
    }
}
