using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTime : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bomb;
    GameObject bomb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBomb()
    {
        bomb = Instantiate(Bomb, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
    }
}
