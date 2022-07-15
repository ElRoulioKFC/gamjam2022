using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    private int vie;
    public int vieMax;
    public List<Dice> pot;
    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        pot = new List<Dice>();
        vie = vieMax;
        string[] type = { Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT, Dice.DEGAT };
        string[] value = { "1", "2", "3", "4", "5", "6" };
        for (int i = 0; i < 10; i++) pot.Add(new Dice("ju", 6, type, value));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Dammage(int degat) {
        vie -= degat;
        healthBar.GetComponentsInChildren<Image>()[1].fillAmount = (float)vie / vieMax;
        healthBar.GetComponentInChildren<TextMeshProUGUI>().text = vie.ToString();
        if (vie <= 0) return false;
        return true;
    }

    public List<Dice> Draw(){
        List<Dice> list = new List<Dice>();
        list.Add(pot[Random.Range(0, 10)]);
        list.Add(pot[Random.Range(0, 10)]);
        list.Add(pot[Random.Range(0, 10)]);
        return list;
    }
}
