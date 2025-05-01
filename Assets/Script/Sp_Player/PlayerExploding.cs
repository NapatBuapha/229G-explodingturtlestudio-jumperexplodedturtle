using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExploding : MonoBehaviour
{
    public int detonationCount;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject gameoverUI;
    void Start()
    {
        detonationCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(detonationCount <= 0)
        {
            gameoverUI.SetActive(true);
            Destroy(playerObject);
        }

    }

   private void OnTriggerEnter2D(Collider2D col) 
   {
        if(!col.CompareTag("Player") && !col.CompareTag("Background"))
        detonationCount--;
   }
}
