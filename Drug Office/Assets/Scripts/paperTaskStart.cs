using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class paperTaskStart : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI papersTaskText;
    [SerializeField] GameObject documentsObject;
    private int randomPapersNumber;

    void Start()
    {
        papersTaskText.enabled = false;
        randomPapersNumber = Random.Range(1, 4);
    }

    void OnTriggerEnter(Collider other)
    {
        papersTaskText.enabled = true;
        Debug.Log("essa");
        papersTaskText.text = $"Papers: {randomPapersNumber}";
        //Destroy(documentsObject);
    }
}
