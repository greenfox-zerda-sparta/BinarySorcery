using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

 public GameObject happinessText;
 public GameObject hungerText;
 public GameObject nameText;

 public GameObject greenfox;

	void Update () {
  // not ideal, because updates every cycle, even when stats dont change
  happinessText.GetComponent<Text> ().text = "" + greenfox.GetComponent<Fox> ().happiness;
  hungerText.GetComponent<Text> ().text = "" + greenfox.GetComponent<Fox> ().hunger;
  nameText.GetComponent<Text> ().text = greenfox.GetComponent<Fox> ().name;
	}
}
