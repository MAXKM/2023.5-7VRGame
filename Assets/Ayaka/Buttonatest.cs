using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public UnityEngine.UI.Button button;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out button))
        {
            button.onClick.AddListener(OnClickItemButton);
        }
        else
        {
            Debug.Log("Buttn 未取得");

            DebugUIBuilder.instance.AddLabel("Button 未取得", DebugUIBuilder.DEBUG_PANE_CENTER);
            DebugUIBuilder.instance.Show();
        }
    }
    //ボタン押されたときの処理
    public void OnClickButton()
    {
        Debug.Log("ボタン押した");

        DebugUIBuilder.instance.AddLabel("ボタン押した", DebugUIBuilder.DEBUG_PANE_CENTER);
        DebugUIBuilder.instance.Show();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
