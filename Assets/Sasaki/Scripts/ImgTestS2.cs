using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgTestS2 : MonoBehaviour
{
    private Image mImage;
    public Sprite[] msprite;
    bool c;
    // Start is called before the first frame update
    void Start()
    {
        c = false;
        mImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スプライトオブジェクトの変更フラグが true の場合
            if (c)
            {
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[0] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                mImage.sprite = msprite[0];
                c = false;
            }
            // スプライトオブジェクトの変更フラグが false の場合
            else
            {
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[1] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                mImage.sprite = msprite[1];
                c = true;
            }
        }
    }
}
