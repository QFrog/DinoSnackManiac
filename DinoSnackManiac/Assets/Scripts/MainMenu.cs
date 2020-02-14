using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject startButton2;
    public GameObject startText;
    public GameObject tutText;
    void Start()
    {
        tutText.SetActive(false);
        startButton2.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StartButton()
    {
        startButton.SetActive(false);
        startText.SetActive(false);
        tutText.SetActive(true);
        startButton2.SetActive(true);

    }
}
