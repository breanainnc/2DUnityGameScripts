using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBlueMenu : MonoBehaviour
{
    public void LoadBlue()
    {
        SceneManager.LoadScene("BlueLevels", LoadSceneMode.Single);
    }
}
