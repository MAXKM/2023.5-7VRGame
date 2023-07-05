using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeakPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameInformation gameInformation;
    public int WeakPoint;
    //public bool weak;
    public GameObject prefabWeak;
    public bool weak;
    public GameObject[] weakpoint;
    void Awake()
    {
        weak = false;
        switch (gameInformation.weakPointNumLevel)
        {
            case 1:
                WeakPoint = 1;
                break;
            case 2:
                WeakPoint = 2;
                break;
            case 3:
                WeakPoint = 3;
                break;
        }
        //weak = false;
        for (int i = 0; i < WeakPoint; i++)
        {
            float y = Random.Range(0.19f, 0.9f);
            float z = Random.Range(-0.71f, 0.68f);
            Vector3 pos = new Vector3(0.1f, y, z);
            weakpoint[i] = Instantiate(prefabWeak, pos, Quaternion.Euler(0, 0, -90));
            weakpoint[i].transform.parent = this.transform;
            weakpoint[i].GetComponent<Renderer>().enabled = false;
        }
    }

    public void WA()
    {
        for (int i = 0; i < WeakPoint; i++)
        {
            weakpoint[i].GetComponent<Renderer>().enabled = true;
        }
    }
}
