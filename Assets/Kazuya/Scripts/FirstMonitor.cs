using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMonitor : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField]NormalMonitorManager normalMonitorManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        gameManager.gameStart = true;
        normalMonitorManager.monitorCount++;
        normalMonitorManager.ReturnObjectToPool(this.gameObject);
    }
}
