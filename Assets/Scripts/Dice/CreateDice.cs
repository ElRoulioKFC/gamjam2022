using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] type = { Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT };
        string[] value = {"1","2","3","4","5","6" };
        Dice de = new Dice("ju", 6, type, value);
        Debug.Log(de);
        Debug.Log(Dice.GetDiceFromByte(de.ToByteArray()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
