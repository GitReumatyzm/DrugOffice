using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperTaskEnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI papersTaskText;
    [SerializeField] float time = 3f;
    [SerializeField] string taskCompletedString = "DONE!";

    private void OnTriggerEnter(Collider other)
    {
        papersTaskText.text = taskCompletedString;
        StartCoroutine(destroyOnTime());
    }

    IEnumerator destroyOnTime()
    {
        yield return new WaitForSeconds(time);
       papersTaskText.enabled = false;
    }
}
