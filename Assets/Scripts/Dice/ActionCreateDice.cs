using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionCreateDice : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;

    private bool on = false;
    private int val = 0;
    public int Val { get { return val; }set { val = value; } }

    public void Enter()
    {
        on = true;
    }

    public void Exit()
    {
        on = false;
    }

    private void Start()
    {
        tmp.text = "" + val;
    }

    void  Update()
    {
        if (on)
        {
            if (Input.GetMouseButtonDown(0))
            {
                val++;
               
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (val > 0) val--;
            }
            tmp.text = "" + val;
        }
    }
}