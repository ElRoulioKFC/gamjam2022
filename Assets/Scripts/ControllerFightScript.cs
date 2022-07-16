using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerFightScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject buttons;
    public GameObject des;

    private bool newTurn = true;
    private bool fight = false;
    private bool sleep = false;
    private float timer = 0.5f;
    private GameObject playerTurn;
    private List<string> diceList;
    private List<int> choix;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = player1;
    }

    public void Button1()
    {
        if (!choix.Contains(0) && choix.Count < 2) choix.Add(0);
        else choix.Remove(0);
        if (choix.Count == 2)
        {
            buttons.SetActive(false);
            fight = true;
        }
    }
    public void Button2()
    {
        if (!choix.Contains(1) && choix.Count < 2) choix.Add(1);
        else choix.Remove(1);
        if (choix.Count == 2)
        {
            buttons.SetActive(false);
            fight = true;
        }
    }
    public void Button3()
    {
        if (!choix.Contains(2) && choix.Count < 2) choix.Add(2);
        else choix.Remove(2);
        if (choix.Count == 2)
        {
            buttons.SetActive(false);
            fight = true;
        }
    }

    void Use(string[] arg)
    {
        if (arg[0].Equals(Dice.DEGAT))
        {
            GameObject target;
            if (playerTurn == player1)
            {
                target = player2;
            }
            else
            {
                target = player1;
            }
            target.GetComponentInChildren<PlayerScript>().Dammage(int.Parse(arg[1]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (newTurn)
        {
            diceList = playerTurn.GetComponentInChildren<PlayerScript>().Draw();
            for (int i = 0; i < 3; i++)
            {
                des.GetComponentsInChildren<TextMeshProUGUI>()[i].text = diceList[i];
            }
            //healthBar.GetComponentInChildren<TextMeshProUGUI>().text = vie.ToString();
            choix = new List<int>();
            newTurn = false;
            buttons.SetActive(true);
        }
        else if (fight)
        {
            Use(diceList[choix[0]].Split(':'));
            Use(diceList[choix[1]].Split(':'));
            fight = false;
            sleep = true;
        }
        else if (timer <= 0f)
        {
            sleep = false;
            if (playerTurn == player1)
            {
                playerTurn = player2;
            }
            else
            {
                playerTurn = player1;
            }
            newTurn = true;
            timer = 0.5f;
        }
        else if (sleep)
        {
            timer -= Time.deltaTime;
        }
    }
}