using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMonitor : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField]NormalMonitorManager normalMonitorManager;
    [SerializeField] ParticleSystem Destroy;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        gameManager.gameStart = true;
        normalMonitorManager.monitorCount++;
        if (meshRenderer == null)
        {
            meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        }
        meshRenderer.enabled = false;
        Destroy.Play();
        StartCoroutine(HideCoroutine());

    }
    WaitForSeconds hideWait = new WaitForSeconds(0.7f);

    IEnumerator HideCoroutine()
    {
        yield return hideWait;
        normalMonitorManager.ReturnObjectToPool(this.gameObject);
    }
}
