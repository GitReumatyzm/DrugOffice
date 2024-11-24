using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskText : MonoBehaviour
{
    public TextMeshProUGUI OneTaskText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
