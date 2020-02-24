using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
  public GameObject startButton;
  public GameObject startButton2;
  public GameObject credits;
  public GameObject startText;
  public GameObject tutText;
  void Start() {
    tutText.SetActive(false);
    startButton2.SetActive(false);
  }
  public void PlayGame() {
    SceneManager.LoadScene("MainScene");
  }

  public void tutorial() {
    SceneManager.LoadScene("Tutorial");
  }
  public void tutorial1() {
    SceneManager.LoadScene("Tutorial 1");
  }

  public void mainMenu() {
    SceneManager.LoadScene("StartScene");
  }

  public void goCredits() {
    SceneManager.LoadScene("Credits");
  }


  public void StartButton() {
    startButton.SetActive(false);
    startText.SetActive(false);
    tutText.SetActive(true);
    startButton2.SetActive(true);
    credits.SetActive(true);

    }
}
