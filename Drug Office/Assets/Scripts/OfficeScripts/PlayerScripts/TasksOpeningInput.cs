using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksOpeningInput : MonoBehaviour
{
    [SerializeField] GameObject tasksContainer;
    private void Update()
    {
        PressToAcessTasks();
    }

    void PressToAcessTasks()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tasksContainer.SetActive(!tasksContainer.activeSelf);
        }
    }
}
