using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteraction : MonoBehaviour
{
	//public GameObject[] Button = new GameObject[10];
    // Start is called before the first frame update
   
	 public void LoadButton(int levelnumber)
    {
        if (levelnumber < 11)
        {
            SceneManager.LoadScene(("BlueLevel#" + levelnumber), LoadSceneMode.Single);
        }
        else if (levelnumber < 21)
        {
            levelnumber = levelnumber - 10;
            SceneManager.LoadScene(("RedLevel#" + levelnumber), LoadSceneMode.Single);
        }
        else if (levelnumber < 31)
        {
            levelnumber = levelnumber - 20;
            SceneManager.LoadScene(("GreenLevel#" + levelnumber), LoadSceneMode.Single);
        }
        
     }

    public void LoadWorld(int worldnumber)
    {
        if(worldnumber == 1)
        {
            SceneManager.LoadScene(("BlueLevels"), LoadSceneMode.Single);
        }
        else if( worldnumber == 2)
        {
            SceneManager.LoadScene(("RedLevels"), LoadSceneMode.Single);
        }
        else if( worldnumber == 3)
        {
            SceneManager.LoadScene(("GreenLevels"), LoadSceneMode.Single);
        }
    }
    public void LoadNewGameScreen()
    {
        SceneManager.LoadScene(("ResetJSON"), LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
