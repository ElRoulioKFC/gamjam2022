using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private float timer = 5f;

    private bool round = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= .0)
        {
            if(!round) player1.GetComponent<PlayerScript>().Dammage(2);
            else player2.GetComponent<PlayerScript>().Dammage(2);
            round = !round;
            timer = 5f;
        }
    }
}
