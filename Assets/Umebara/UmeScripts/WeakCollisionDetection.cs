using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    NewWeakPoint newweakpoint;
    [SerializeField] MonitorAppearance monitorappearance;
    void Start()
    {
        newweakpoint = GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand") && newweakpoint.weak == false)
        {
            newweakpoint.weak = true;
            Changed();
            newweakpoint.weak = false;
        }
    }
    public void Changed()
    {
        Transform myTransform = this.transform;
        float y = Random.Range(0.19f, 0.9f);
        float z = Random.Range(-0.71f, 0.68f);
        Vector3 pos = new Vector3(0.1f, y, z);
        myTransform.position = pos;
    }


}
