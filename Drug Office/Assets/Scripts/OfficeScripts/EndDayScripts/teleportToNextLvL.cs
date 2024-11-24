using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportToNextLvL : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.hasVisitedScene2 = true;
        SceneManager.LoadScene(2);
    }
}
