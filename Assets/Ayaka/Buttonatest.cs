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
            Debug.Log("Buttn ���擾");

            DebugUIBuilder.instance.AddLabel("Button ���擾", DebugUIBuilder.DEBUG_PANE_CENTER);
            DebugUIBuilder.instance.Show();
        }
    }
    //�{�^�������ꂽ�Ƃ��̏���
    public void OnClickButton()
    {
        Debug.Log("�{�^��������");

        DebugUIBuilder.instance.AddLabel("�{�^��������", DebugUIBuilder.DEBUG_PANE_CENTER);
        DebugUIBuilder.instance.Show();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
