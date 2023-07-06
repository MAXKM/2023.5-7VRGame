using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    NewWeakPoint newweakpoint;
    public bool HandOver;
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
            StartCoroutine(CF(0.1f));
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

    IEnumerator CF(float wait)
    {
        yield return new WaitForSeconds(wait);
        newweakpoint.weak = false;
    }
}
