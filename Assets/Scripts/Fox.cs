﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fox : MonoBehaviour {
 
   [SerializeField]
   private int _hunger;
   [SerializeField]
   private int _happiness;
   [SerializeField]
   private string _name;
   [SerializeField]
   private int _fatigue;
  // ha mar van animacio, akkor ha csinalt valamit, attol no a faradtsag es ha eler vmilyen erteket, akkor 
  // aludni kell egyet - ejszakai hatter, csukott szem. Fatigue value szerinti esellyel nem csinalja meg a dolgokat :)

   private bool _serverTime;
   private int _clickCount;

	 void Start () {
    // PlayerPrefs.SetString("then", "01/27/2017 16:01:01"); // this line is only for testing purpose
     updateStatus ();
     if (!PlayerPrefs.HasKey ("name")) {
      PlayerPrefs.SetString ("name", "Greenfox");
     }
  _name = PlayerPrefs.GetString ("name");
	 }

  void Update() {
    
  GetComponent<Animator> ().SetBool ("jump", gameObject.transform.position.y > -1.1f);
 // GetComponent<Animator> ().SetBool ("jump_high", gameObject.transform.position.y > 1.1f);

    if (Input.GetMouseButtonUp (0)) {
      Vector2 v = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
      RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (v), Vector2.zero);
      if (hit) {
        if (hit.transform.gameObject.tag == "Greenfox") {
          _clickCount++;
          if (_clickCount >= 3) {
            _clickCount = 0;
            updateHappiness (1);
            if (happiness == 100) {
             GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 20000));
            } else {
             GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 10000));
            }
          }
        } 
      }
    }
  }

  void updateStatus(){
    if (!PlayerPrefs.HasKey ("_hunger")) {
      _hunger = 0;
      PlayerPrefs.SetInt ("_hunger", _hunger);
    } else {
      _hunger = PlayerPrefs.GetInt ("_hunger");
    }

    if (!PlayerPrefs.HasKey ("_happiness")) {
      _happiness = 100;
      PlayerPrefs.SetInt ("_happiness", _happiness);
    } else {
      _happiness = PlayerPrefs.GetInt ("_happiness");
    }

    if (!PlayerPrefs.HasKey ("_fatigue")) {
      _fatigue = 0;
      PlayerPrefs.SetInt ("_fatigue", fatigue);
    } else {
      _fatigue = PlayerPrefs.GetInt ("_fatigue");
    }

    if (!PlayerPrefs.HasKey ("then")) {
      PlayerPrefs.SetString ("then", getStringTime ());
    }

   //Debug.Log (getTimeSpan ().ToString ());   // for testing TimeSpan
  
    TimeSpan ts = getTimeSpan();

    _hunger += (int)(ts.TotalHours * 2);
    if (_hunger > 100) {
      _hunger = 100;
    }
    if (_hunger < 0) {
      _hunger = 0;
    }

    _happiness -= _hunger * (int)(ts.TotalHours / 5);
    if (_happiness < 0) {
      _happiness = 0;
    }     
    if (_happiness > 100) {
      _happiness = 100;
    }

    _fatigue += (int)(ts.TotalHours * 3);
    if (_fatigue > 100) {
      _fatigue = 100;
    }
    if (_fatigue < 0) {
      _fatigue = 0;
    }

    if (_serverTime) {
      updateServer ();
    } else {
      InvokeRepeating("updateDevice", 0f, 30f);
    }
  }

  void updateServer() {
  }

  void updateDevice() {
    PlayerPrefs.SetString("then", getStringTime());
  }

  TimeSpan getTimeSpan() {
    if (_serverTime) {
      return new TimeSpan ();
    } else {
      return DateTime.Now - Convert.ToDateTime (PlayerPrefs.GetString ("then"));
    }
  }

  string getStringTime() {
    DateTime now = DateTime.Now;
    return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
  }

  public int hunger {
    get { return _hunger; }
    set {_hunger = value;}
  }

  public int happiness {
    get { return _happiness; }
    set { _happiness = value; }
  }

 public string name {
  get { return _name; }
  set { _name = value; }
 }

  public int fatigue {
    get { return _fatigue; }
    set { _fatigue = value; }
  }

  void updateHappiness (int change){
    happiness += change;
    if (happiness > 100) {
       happiness = 100;
    }
  }

  public void saveFox() {
    if (!_serverTime) {
      updateDevice ();
    }
    PlayerPrefs.SetInt ("_hunger", _hunger);
    PlayerPrefs.SetInt ("_happiness", _happiness);
    PlayerPrefs.SetInt ("_fatigue", _fatigue);
  }
}
 