using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Datafile : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {

        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
            SaveData data = new SaveData();
            data.savedLives = 5;
            bf.Serialize(file, data);
            file.Close();
        }
    }

    [Serializable]
    class SaveData
    {
        public int savedLives;
       
    }
}
