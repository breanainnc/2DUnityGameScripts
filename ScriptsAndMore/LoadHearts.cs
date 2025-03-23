using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class LoadHearts : MonoBehaviour
{
    // Start is called before the first frame update
   SavedData savedData = new SavedData();

   const int FULL_LIVES = 5;
   string saveFile;
   
    void Start(){
        saveFile = Application.persistentDataPath + "/gamedata.json";
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            Debug.Log(fileContents);
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            savedData = JsonUtility.FromJson<SavedData>(fileContents);
        }
    }

    void Update()
    {

        
        if(savedData.lives < 1)
        {
            GetComponent<Button>().enabled = true;
            Sprite sprite = GetComponent<Image>().sprite;
            GetComponent<Image>().sprite = this.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
            this.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprite;
            GetComponent<RectTransform>().sizeDelta = new Vector2(130, 65);
        }
        else {
            this.transform.GetChild(savedData.lives).gameObject.SetActive(true);
        }
        this.enabled = false;                 
    }

    public void getHearts()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            Debug.Log(fileContents);
            // Work with JSON
             savedData = JsonUtility.FromJson<SavedData>(fileContents);
        }
        savedData.lives = FULL_LIVES;
        string jsonString = JsonUtility.ToJson(savedData);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    
    public void AdvertScene(){
        SceneManager.LoadScene("Adverts", LoadSceneMode.Single);
    }
    
}
