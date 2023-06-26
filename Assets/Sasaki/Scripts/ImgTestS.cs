using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImgTestS : MonoBehaviour
{
    //public Image image;
    //private Sprite sprite;
    // Start is called before the first frame update

    private Image mImage;
    public Sprite[] msprite;
    int c = 0;
    void Start()
    {
        mImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    sprite = Resources.Load<Sprite>("cvb");
        //    image = this.GetComponent<Image>();
        //    image.sprite = sprite;
        //}
    }

    public void OnClick()
    {
        if (c == 0)
        {
            // スプライトオブジェクトの変更
            //（配列 m_Sprite[0] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
            mImage.sprite = msprite[0];
            c = 1;
        }
        // スプライトオブジェクトの変更フラグが false の場合
        else if(c==1)
        {
            // スプライトオブジェクトの変更
            //（配列 m_Sprite[1] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
            mImage.sprite = msprite[1];
            c = 2;
        }

        else if (c == 2)
        {
            mImage.sprite = msprite[2];
            c = 0;
        }
    }
}


