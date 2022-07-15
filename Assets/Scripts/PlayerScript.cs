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
        vie = vieMax;
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
}
