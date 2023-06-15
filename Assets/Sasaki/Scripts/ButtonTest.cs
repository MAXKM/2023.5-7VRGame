using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

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
    }
}
