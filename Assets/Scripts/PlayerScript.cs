using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    private int vie;
    private int vieMax;
    public int VieMax { set { vieMax = value; vie = value; Dammage(0); } get { return vieMax; } }
    public List<Dice> pot;
    public GameObject healthBar;

    public bool Dammage(int degat) {
        vie -= degat;
        healthBar.GetComponentsInChildren<Image>()[1].fillAmount = (float)vie / vieMax;
        healthBar.GetComponentInChildren<TextMeshProUGUI>().text = vie.ToString();
        if (vie <= 0) return false;
        return true;
    }

    public List<string> Draw(){
        List<string> list = new List<string>();
        list.Add(pot[Random.Range(0, 10)].GetResult());
        list.Add(pot[Random.Range(0, 10)].GetResult());
        list.Add(pot[Random.Range(0, 10)].GetResult());
        return list;
    }
}
