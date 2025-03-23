using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    SavedData savedData = new SavedData();

    public Animator animator = new Animator();
    

    int[] Levels = new int[10];
    public int level;
    string saveFile;
    // Start is called before the first frame update
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

        if (savedData.Character == 0 ){          
            if(animator.gameObject.activeSelf)
            {
		        animator.runtimeAnimatorController = Resources.Load("Animations/Player") as RuntimeAnimatorController;
                this.enabled = false;
        
            }            
        }
        else if (savedData.Character == 1){
            if(animator.gameObject.activeSelf)
            {
		        animator.runtimeAnimatorController = Resources.Load("Animations/GreenPlayer") as RuntimeAnimatorController;
                this.enabled = false;
        
            }  
        }
        else if (savedData.Character == 2){
            if(animator.gameObject.activeSelf)
            {
		        animator.runtimeAnimatorController = Resources.Load("Animations/Player3") as RuntimeAnimatorController;
                this.enabled = false;
        
            }  
        }
        
    }
    
    public void WinCondition()
    {
       
        if(level < 10){ savedData.BlueLevels[level] = true;}
        
        else if(level >= 10){ level = level % 10; savedData.RedLevels[level] = true;}
        
        string jsonString = JsonUtility.ToJson(savedData);
        Debug.Log(jsonString);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    } 

    public void Death()
    {
         if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            savedData = JsonUtility.FromJson<SavedData>(fileContents);
        }
        savedData.lives = savedData.lives - 1;
        string jsonString = JsonUtility.ToJson(savedData);
        Debug.Log(jsonString);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    public bool CheckLives()
    {
        bool EnoughForRestart = true;
         if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            savedData = JsonUtility.FromJson<SavedData>(fileContents);
        }
        if (savedData.lives < 1){
            EnoughForRestart = false;
            }

        return EnoughForRestart;
    }
    
}
