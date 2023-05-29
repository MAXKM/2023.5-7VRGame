using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorDetection : MonoBehaviour
{
    public bool Detection;
    private bool Detectionable;
    // Start is called before the first frame update
    void Start()
    {
        Detection = false;
        Debug.Log(Detection);
        Detectionable = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if (other.gameObject.tag=="Hand" && Detectionable == true)
        {
            Detection = true;
            Debug.Log(Detection);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Detectionable = false;
        if (other.gameObject.tag == "Hand" && Detectionable == false)
        {
            Detection = false;
            Debug.Log(Detection);
        }
    }
    
}
