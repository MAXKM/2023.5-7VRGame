using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SScale(int GloveLevel)
    {
        switch (GloveLevel)
        {
            case 1:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case 2:
                transform.localScale = new Vector3(2, 1, 1);
                break;
            case 3:
                transform.localScale = new Vector3(2, 1, 1);
                break;
            case 4:
                transform.localScale = new Vector3(2, 1, 1);
                break;
            case 5:
                break;

        }
    }
}
