using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableGlobalScript : MonoBehaviour
{
    public int test = 1;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
