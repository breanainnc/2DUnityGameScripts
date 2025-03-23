using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject Image;
    public GameObject Resumebutton;
    public GameObject Exitbutton;
    public GameObject Pause;
    public GameObject[] Controls;
    public GameObject Options;
    bool OptionAct = false;
 
    public void PauseButton()
    {
        Image.SetActive(true);
        Resumebutton.SetActive(true);
        Exitbutton.SetActive(true);
        Pause.SetActive(false);
        for(int i = 0; i < 4; i++)
        {
            Controls[i].SetActive(false);
        }
        Time.timeScale = 0;
    }
   

    public void ResumeButton(bool normalLevel)
    {
        int i;
        Image.SetActive(false);
        Resumebutton.SetActive(false);
        Exitbutton.SetActive(false);
        Pause.SetActive(true);
        if(normalLevel){i = 0;}
        else{i = 2;} 
        while (i < 4)
        {
            Controls[i].SetActive(true);
            i++;
        }
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }
     public void CharacterButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CharacterSelect", LoadSceneMode.Single);
    }
    public void GreenExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GreenLevels", LoadSceneMode.Single);
    }
    public void RedExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("RedLevels", LoadSceneMode.Single);
    }
     public void BlueExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BlueLevels", LoadSceneMode.Single);
    }
    public void ActivatePauseButton()
    {
        Pause.SetActive(true);
    }
    public void DeactivatePauseButton()
    {
        Pause.SetActive(false);
    }

    public void OptionsInteraction()
    {
        if(OptionAct == false){
            Options.GetComponent<Image>().enabled = true;
            Options.transform.GetChild(0).GetComponent<Image>().enabled = true;
            Options.transform.GetChild(1).GetComponent<Image>().enabled = true;
            Options.transform.GetChild(2).GetComponent<Image>().enabled = true;
            Options.transform.GetChild(1).GetComponent<Button>().enabled = true;
            Options.transform.GetChild(2).GetComponent<Button>().enabled = true;
            Options.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().enabled = true;
            Options.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().enabled = true;
            OptionAct = true;
        }
        else
        {
            Options.GetComponent<Image>().enabled = false;
            Options.transform.GetChild(0).GetComponent<Image>().enabled = false;
            Options.transform.GetChild(1).GetComponent<Image>().enabled = false;
            Options.transform.GetChild(2).GetComponent<Image>().enabled = false;
            Options.transform.GetChild(1).GetComponent<Button>().enabled = false;
            Options.transform.GetChild(2).GetComponent<Button>().enabled = false;
            Options.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().enabled = false;
            Options.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().enabled = false;
            OptionAct = false;
        }
        
    }
}
