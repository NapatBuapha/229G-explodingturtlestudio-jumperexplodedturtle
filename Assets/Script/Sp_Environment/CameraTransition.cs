using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private GameObject displayCamera;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            displayCamera.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
            if(col.CompareTag("Player"))
        {
            displayCamera.SetActive(false);
        }
    }
}
