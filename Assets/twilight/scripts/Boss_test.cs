using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_test : MonoBehaviour
{
    public GameObject Boss;
    public bool Ins = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Ins == true)
        {
            Instantiate( Boss );
            Ins = false;
        }
    }
}
