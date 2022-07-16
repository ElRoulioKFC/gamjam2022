using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMapScript : MonoBehaviour
{
    public string Level;
    private int[] healths;
    private List<Dice>[] pots;
    // Start is called before the first frame update
    void Start()
    {
        healths = new int[2];
        pots = new List<Dice>[2];
        for (int j = 0; j < 2; j++)
        {
            healths[j] = Random.Range(30, 46);
            pots[j] = new List<Dice>();
            string[] type = { Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT };
            string[] value = { "1", "2", "3", "4", "5", "6" };
            for (int i = 0; i < 10; i++) pots[j].Add(new Dice("ju", 6, type, value));
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartFight(int arg)
    {
        VariableGlobalScript v = GameObject.Find("VariableGlobal").GetComponent<VariableGlobalScript>();
        v.potj2 = pots[arg];
        v.healthJ2 = healths[arg];
        SceneManager.LoadScene(Level);
    }
}
