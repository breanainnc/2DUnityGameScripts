using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
        }
    }
    public void ContinueButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name.Contains("Red")){
            SceneManager.LoadScene("RedLevels", LoadSceneMode.Single);
        }
        else if(scene.name.Contains("Blue")){
            SceneManager.LoadScene("BLueLevels", LoadSceneMode.Single);
        }
        else if(scene.name.Contains("Green")){
            SceneManager.LoadScene("GreenLevels", LoadSceneMode.Single);
        }
        
    }
}
