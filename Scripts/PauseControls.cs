using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
    // Start is called before the first frame update
    public int selection = 0;
    public GameObject[] rawImage = new GameObject[4];

    public float Control;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Control = Input.GetAxis("Vertical");
        if (Control < 0)
        {
            if (selection == 0)
            {
                selection++;
                rawImage[0].SetActive(false);
                rawImage[1].SetActive(false);
                rawImage[2].SetActive(true);
                rawImage[3].SetActive(true);
            }
        }
        if (Control > 0)
        {
            if (selection == 1)
            {
                selection--;
                rawImage[0].SetActive(true);
                rawImage[1].SetActive(true);
                rawImage[2].SetActive(false);
                rawImage[3].SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(selection == 0)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                
            }
            else
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void Quit()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }
      public void BlueExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BlueLevels", LoadSceneMode.Single);
    }
    public void RedExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("RedLevels", LoadSceneMode.Single);
    }
    public void GreenExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("RedLevels", LoadSceneMode.Single);
    }
}
