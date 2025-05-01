using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   [Header("Refference")]
    //[SerializeField] private GameObject heartUi;
    [SerializeField] private GameObject gameOverUi;

    private void Awake()
    {
        gameOverUi.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
