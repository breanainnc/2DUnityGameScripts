using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameoverScreen;
    public GameObject WinScreen;
    public GameObject DPad;
    public GameObject Button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        GameoverScreen.GetComponent<Canvas>().enabled = true;
        GameoverScreen.GetComponent<PauseControls>().enabled = true;
        GameObject Player =  GameObject.Find("Player");
        Player.GetComponent<PlayerMovement>().enabled = false;
        DPad.GetComponent<Canvas>().enabled = false;

        if(Player.GetComponent<LoadCharacter>().CheckLives() == false )
        {
           
           Button.GetComponent<Image>().enabled = false;
           Button.GetComponent<Button>().enabled = false;
           Button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
           //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        //GameObject.Find("Canvas").GetComponent<PauseControls>().enabled = true;
        
        DPad.GetComponent<Canvas>().enabled = false;
        //Invoke("stoptime",2);
    }
    
    public void noLives()
    {

    }
    public void winGame()
    {
        DPad.GetComponent<Canvas>().enabled = false;
        WinScreen.GetComponent<Canvas>().enabled = true;
        WinScreen.GetComponent<Continue>().enabled = true;
        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        //GameObject.Find("Canvas").GetComponent<Continue>().enabled = true;
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    void stoptime()
    {
        Time.timeScale = 0;
    }
}
