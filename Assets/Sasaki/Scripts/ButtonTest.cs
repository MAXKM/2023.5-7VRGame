using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private float a = 2.4444444f;
    private float b = 2.55555f;
    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

    public void OnClick()
    {
        _text.text = "Pushed";
        a = a * 100;
        a = Mathf.Round(a)/100;
        Debug.Log("a:" +a);
    }
}
