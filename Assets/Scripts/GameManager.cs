using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public GameObject happinessText;
  public GameObject hungerText;
  public GameObject nameText;
  public GameObject fatigueText;

  public GameObject namePanel;
  public GameObject nameInput;

  public GameObject background;
  public GameObject backgroundPanel;
  public Sprite[] backgroundOptions;

  public GameObject foxPanel;

  public GameObject greenfox;

  void Start() {
    // DOES NOT WORK
  //  if (!PlayerPrefs.HasKey ("background")) {
  //    PlayerPrefs.SetInt("background", 1);
  //    background.GetComponent<SpriteRenderer> ().sprite = backgroundOptions [1];
  //  }
   // changeBackground (PlayerPrefs.GetInt ("background"));
  }

	void Update () {
  // not ideal, because updates every cycle, even when stats dont change
    happinessText.GetComponent<Text> ().text = "" + greenfox.GetComponent<Fox> ().happiness;
    hungerText.GetComponent<Text> ().text = "" + greenfox.GetComponent<Fox> ().hunger;
    nameText.GetComponent<Text> ().text = greenfox.GetComponent<Fox> ().name;
    fatigueText.GetComponent<Text> ().text = "" + greenfox.GetComponent<Fox> ().fatigue;
  }

  public void triggerNamePanel(bool isActive) {
    namePanel.SetActive (!namePanel.activeInHierarchy);
    if (isActive) {
      greenfox.GetComponent<Fox> ().name = nameInput.GetComponent<InputField> ().text;
      PlayerPrefs.SetString("name", greenfox.GetComponent<Fox>().name);
    }
  }

  public void buttonBehaviour (int buttonSelect) {
    switch (buttonSelect) {
    case (0): // Bottom Foxes
    default:
      foxPanel.SetActive(!foxPanel.activeInHierarchy);
      if (backgroundPanel.activeInHierarchy) {
        backgroundPanel.SetActive(false);
      }
      break;
    case(1): // Bottom Bg
      backgroundPanel.SetActive(!backgroundPanel.activeInHierarchy);
      if (foxPanel.activeInHierarchy) {
        foxPanel.SetActive(false);
      }
      break;
    case(2): // Bottom Quit
      greenfox.GetComponent<Fox> ().saveFox ();
      Application.Quit ();
      break;
    case(3): // Left Chicken
      greenfox.GetComponent<Fox> ().hunger -= 3;
      if (greenfox.GetComponent<Fox> ().hunger < 0) {
        greenfox.GetComponent<Fox> ().hunger = 0;
      }
      break; 
    case(4): // Left Egg
      greenfox.GetComponent<Fox> ().hunger -= 1;
      if (greenfox.GetComponent<Fox> ().hunger < 0) {
        greenfox.GetComponent<Fox> ().hunger = 0;
      }
      break;
    case(5): // Left Pizza
      greenfox.GetComponent<Fox> ().hunger -= 2;
      if (greenfox.GetComponent<Fox> ().hunger < 0) {
        greenfox.GetComponent<Fox> ().hunger = 0;
      }
      greenfox.GetComponent<Fox> ().happiness += 1;
      if (greenfox.GetComponent<Fox> ().happiness > 100) {
        greenfox.GetComponent<Fox> ().happiness = 100;
      }
      break;
    case(6): // Left Beer
      greenfox.GetComponent<Fox> ().happiness += 5;
      if (greenfox.GetComponent<Fox> ().happiness > 100) {
        greenfox.GetComponent<Fox> ().happiness = 100;
      }
      break;
    case(7): // Left Coffee
      greenfox.GetComponent<Fox> ().happiness += 2;
      if (greenfox.GetComponent<Fox> ().happiness > 100) {
        greenfox.GetComponent<Fox> ().happiness = 100;
      }
      greenfox.GetComponent<Fox> ().fatigue -= 1;
      if (greenfox.GetComponent<Fox> ().fatigue < 0) {
        greenfox.GetComponent<Fox> ().fatigue = 0;
      }
      break;
    case(8): // Right Sleep
      greenfox.GetComponent<Fox> ().fatigue = 0;
   //   greenfox.GetComponent<Animation> ().Play ("Sleeper");
      break;
    }
  }

//  public void changeBackground(int bgNumber) {
//    background.GetComponent<SpriteRenderer> ().sprite = backgroundOptions [bgNumber];
 //   if (background.activeInHierarchy) {
 //     background.SetActive (false);
 //   }
 //   PlayerPrefs.SetInt ("background", bgNumber);
 // }
}
