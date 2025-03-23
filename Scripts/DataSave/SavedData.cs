using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData 
{
    public int Character = 1;
    public int lives = 5;
    public bool[] BlueLevels = {false,false,false,false,false,false,false,false,false,false};
    public bool[] RedLevels = {false,false,false,false,false,false,false,false,false,false};
    public bool[] GreenLevels = {false,false,false,false,false,false,false,false,false,false};
    public bool[] YellowLevels = {false,false,false,false,false,false,false,false,false,false};
    public bool[] PurpleLevels = {false,false,false,false,false,false,false,false,false,false};
    public bool[] OrangeLevels = {false,false,false,false,false,false,false,false,false,false};
}
