using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    int selection = 1;
    public GameObject Option1;
    public GameObject Option2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selection == 1)
            {
                selection++;
                Option1.SetActive(false);
                Option2.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selection == 2)
            {
                selection--;
                Option1.SetActive(true);
                Option2.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(selection == 1)
            {
                SceneManager.LoadScene("Level#1", LoadSceneMode.Single);
            }
            else if(selection == 2)
            {

            }
        }
    }

}

