using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableGlobalScript : MonoBehaviour
{
    public List<Dice> potj1;
    public List<Dice> potj2;
    public int healthJ2;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        potj1 = new List<Dice>();
        string[] type = { Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT };
        string[] value = { "1", "2", "3", "4", "5", "6" };
        for (int i = 0; i < 10; i++) potj1.Add(new Dice("ju", 6, type, value));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
