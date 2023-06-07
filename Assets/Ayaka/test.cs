using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public float timerCount;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            ButtonDisplay();
        }
    }
    public void ButtonDisplay()
    {
        button.SetActive(true);
    }
}
