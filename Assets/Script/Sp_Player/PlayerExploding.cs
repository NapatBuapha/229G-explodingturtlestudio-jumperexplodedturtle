using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExploding : MonoBehaviour
{
    public int detonationCount;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private DeadCheck deadCheck;
    void Start()
    {
        deadCheck = GameObject.Find("DeadCheck").GetComponent<DeadCheck>();
        detonationCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(detonationCount <= 0)
        {
            gameoverUI.SetActive(true);
            deadCheck.isPlayerDead = true;
            Destroy(playerObject);
        }

    }

   private void OnTriggerEnter2D(Collider2D col) 
   {
        if(!col.CompareTag("Player") && !col.CompareTag("Background"))
        detonationCount--;
   }
}
