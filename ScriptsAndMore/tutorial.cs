using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject ControlUI;
    public GameObject TutorialUI;
    public void Start(){
        Time.timeScale = 0;
    }
    public void changeUI(){
        TutorialUI.GetComponent<Canvas>().enabled = false;
        ControlUI.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
    }
}
