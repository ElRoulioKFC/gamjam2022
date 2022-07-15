using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject buttons;

    private bool newTurn = true;
    private bool fight = false;
    private bool sleep = false;
    private float timer = 0.5f;
    private GameObject playerTurn;
    private List<Dice> diceList;
    private List<int> choix;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = player1;
    }

    public void Button1() {
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

    // Update is called once per frame
    void Update()
    {
        if (newTurn)
        {
            diceList = playerTurn.GetComponentInChildren<PlayerScript>().Draw();
            choix = new List<int>();
            newTurn = false;
            buttons.SetActive(true);
        }
        else if (fight)
        {
            GameObject target;
            if (playerTurn == player1)
            {
                target = player2;
                playerTurn = player2;
            }
            else
            {
                target = player1;
                playerTurn = player1;
            }
            Debug.Log(choix[0]);
            target.GetComponentInChildren<PlayerScript>().Dammage(int.Parse(diceList[choix[0]].FaceValue[0]));
            target.GetComponentInChildren<PlayerScript>().Dammage(int.Parse(diceList[choix[1]].FaceValue[0]));
            fight = false;
            sleep = true;
        }
        else if(timer <= 0f)
        {
            sleep = false;
            newTurn = true;
            timer = 0.5f;
        }
        else if(sleep)
        {
            timer -= Time.deltaTime;
        }
    }
}
