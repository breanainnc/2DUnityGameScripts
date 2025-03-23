using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedDataManager : MonoBehaviour
{
        // Create a field for the save file.
    string saveFile;
    public GameObject[] buttons;
    const int FULL_LIVES = 5;
    public Sprite GreenImage;
    public Sprite RedImage; 
    public Sprite GreyImage;
    public Sprite LightColour;
   
    // Create a GameData field.
    SavedData savedData = new SavedData();
    bool[] Levels = new bool[10];

    void Awake()
    {
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/gamedata.json";
        int IsFirst = PlayerPrefs.GetInt("IsFirst") ;
        if (IsFirst == 0)
        {
            resetFile();
            PlayerPrefs.SetInt("IsFirst", 1);
        } 
        readFile();
    }
    void Start(){
        
        //buttons[savedData.Character].GetComponent<Image>().sprite = GreenImage;
        
        
        
        
    }
    public void readFile()
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
    }
    public void refillLives(){
        readFile();
        savedData.lives = FULL_LIVES;
        writeFile();
    }

    public void death(){
        savedData.lives = savedData.lives - 1;
        writeFile();
    }

    public void CheckIfoutOfLives(){
        readFile();
        if (savedData.lives < 1){
            for(int i = 0; i < 10; i++){
                buttons[i].GetComponent<Button>().enabled = false;
                buttons[i].GetComponent<Image>().sprite = GreyImage;
                
            }
            
        }
        
    }
    public int returnProgress(int world){
        int count = 0;
        if(world == 1){
            for(int i = 0; i < 10; i++){
                if(savedData.BlueLevels[i] == true){count++;}
            }
        }
        else if(world == 2){
            for(int i = 0; i < 10; i++){
                if(savedData.RedLevels[i] == true){count++;}
            }
        }
        else{
            for(int i = 0; i < 10; i++){
                if(savedData.GreenLevels[i] == true){count++;}
            }
        }
        int choice = 0;
        if(count > 2){choice++;}
        if(count > 3){choice++;}
        if(count > 6){choice++;}
        

        return choice;
    }
    public void writeFile()
    {
        // Work with JSON
        string jsonString = JsonUtility.ToJson(savedData);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    public void resetFile()
    {
        readFile();
        savedData = new SavedData();
        writeFile();
        
    }

    public void CharacterSelect(int i)
    {
        savedData.Character = i;

        for(int j = 0; j < buttons.Length; j++){
            buttons[j].GetComponent<Image>().sprite = RedImage;
        }
        buttons[i].GetComponent<Image>().sprite = GreenImage;

        writeFile();
    }
    public void CharacterButtons(){
        int i = savedData.Character;
        Debug.Log(i);
        buttons[i].GetComponent<Image>().sprite = GreenImage;

    }
    public int ArrangeWorldLevels()
    {
        int choice = 0;
        readFile();
        int count = 0;
        for(int i = 0; i < 10; i++){
            if(savedData.BlueLevels[i] == true){count++;};
        }
        if(count < 10){ 
            GameObject Button = GameObject.Find("Button");
            Button.GetComponent<Button>().enabled = false;
            Button.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GreyImage;
            
        }
        else {
            GameObject Button = GameObject.Find("Button2");
            Button.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GreenImage;
            Button.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = LightColour;
            choice++;
        }
        for(int j = 0; j < 10; j++){
            if(savedData.RedLevels[j] == true){count++;};
        }
        if(count > 19){
            GameObject Button = GameObject.Find("ButtonGreen");
            Button.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GreenImage;
        }
        else {
            GameObject Button = GameObject.Find("ButtonGreen");
            Button.GetComponent<Button>().enabled = false;
            Button.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GreyImage;
        }
        return choice;
    }
    public void ArrangeLevels(int world)
    {
        readFile();
        if(world == 1){
            for(int i = 0; i < 10; i++){
                Levels[i] = savedData.BlueLevels[i];
            } 
        }
        else if (world == 2){ 
            for(int i = 0; i < 10; i++){
                Levels[i] = savedData.RedLevels[i];
            } 
        }
        else if (world == 3){ 
            for(int i = 0; i < 10; i++){
                Levels[i] = savedData.GreenLevels[i];
            } 
        }

        int count = 0;
        for(int i = 0; i < 10; i++){
            if(Levels[i] == true){count++;}
        }

        if(Levels[0] == true){ buttons[0].GetComponent<Image>().sprite = GreenImage; LightLinks(1);} else { buttons[0].GetComponent<Image>().sprite = RedImage; }
        if(Levels[1]  == true){ buttons[1].GetComponent<Image>().sprite = GreenImage; LightLinks(2);} else { buttons[1].GetComponent<Image>().sprite = RedImage; }
        if(Levels[2] == true){ buttons[2].GetComponent<Image>().sprite = GreenImage; LightLinks(3);} else { buttons[2].GetComponent<Image>().sprite = RedImage; }
        
        if(Levels[3] == true){ buttons[3].GetComponent<Image>().sprite = GreenImage; LightLinks(4);} 
        else if (count < 3) { buttons[3].GetComponent<Image>().sprite = GreyImage; buttons[3].GetComponent<Button>().enabled = false;} 
        else { buttons[3].GetComponent<Image>().sprite = RedImage; }
        
        if(Levels[4] == true){ buttons[4].GetComponent<Image>().sprite = GreenImage; LightLinks(5);} 
        else if (count < 4) { buttons[4].GetComponent<Image>().sprite = GreyImage; buttons[4].GetComponent<Button>().enabled = false;} 
        else { buttons[4].GetComponent<Image>().sprite = RedImage; }

        if(Levels[5] == true){ buttons[5].GetComponent<Image>().sprite = GreenImage; LightLinks(6);} 
        else if (count < 4) { buttons[5].GetComponent<Image>().sprite = GreyImage; buttons[5].GetComponent<Button>().enabled = false;} 
        else { buttons[5].GetComponent<Image>().sprite = RedImage; }

        if(Levels[6] == true){ buttons[6].GetComponent<Image>().sprite = GreenImage; LightLinks(7);} 
        else if (count < 4) { buttons[6].GetComponent<Image>().sprite = GreyImage; buttons[6].GetComponent<Button>().enabled = false;} 
        else { buttons[6].GetComponent<Image>().sprite = RedImage; }

        if(Levels[7] == true){ buttons[7].GetComponent<Image>().sprite = GreenImage; LightLinks(8);} 
        else if (count < 7) { buttons[7].GetComponent<Image>().sprite = GreyImage; buttons[7].GetComponent<Button>().enabled = false;} 
        else { buttons[7].GetComponent<Image>().sprite = RedImage; }

        if(Levels[8] == true){ buttons[8].GetComponent<Image>().sprite = GreenImage; } 
        else if (count < 8) { buttons[8].GetComponent<Image>().sprite = GreyImage; buttons[8].GetComponent<Button>().enabled= false;} 
        else { buttons[8].GetComponent<Image>().sprite = RedImage;}

        if(Levels[9] == true){ buttons[9].GetComponent<Image>().sprite = GreenImage; } 
        else if (count < 8) { buttons[9].GetComponent<Image>().sprite = GreyImage; buttons[9].GetComponent<Button>().enabled = false;} 
        else { buttons[9].GetComponent<Image>().sprite = RedImage; }

    }

    public void LightLinks(int level)
    {
        level = level % 10;
        string levelLinkName = "Level" + level + "Link";

        GameObject levelLink = GameObject.Find(levelLinkName);
        GameObject currentImage;

        if(level == 1 || level == 3 || level == 5 || level == 7){
            currentImage = levelLink.transform.GetChild(0).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(1).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(2).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            
        }
        else if(level == 2 || level == 6 ){
            currentImage = levelLink.transform.GetChild(0).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
        }
        else if(level == 4){
            currentImage = levelLink.transform.GetChild(0).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(1).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(2).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(3).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(4).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(5).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(6).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
        }
        else if (level == 8){
            currentImage = levelLink.transform.GetChild(0).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(1).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(2).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
            currentImage = levelLink.transform.GetChild(3).gameObject;
            currentImage.GetComponent<Image>().sprite = LightColour;
        }
    }
    
}
