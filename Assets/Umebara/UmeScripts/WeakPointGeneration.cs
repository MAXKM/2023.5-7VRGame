using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointGeneration : MonoBehaviour
{
    static public WeakPointGeneration instance;
    // 生成するプレハブ格納用
    public GameObject prefabWeak;
    //GIを取得
    public GameInformation gameInformation;
    //weakpointの数を定義
    private int weakQuantity;
    private bool produce;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //GIにあるweakPointNumLevelをweakQuantityに置き換え
        weakQuantity = gameInformation.weakPointNumLevel;
        weakQuantity = 2;
        // プレハブを生成
        for (int i = 0; i < weakQuantity; i++)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            Vector3 pos = new Vector3(x, y, 1.3f);
            Instantiate(prefabWeak, pos, Quaternion.identity);
        }

    }
    /*private void Update()
    {
        produce = WeakPointScript.instance.weak;
        if (produce == true)
        {
            Debug.Log("B");
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            Vector3 pos = new Vector3(x, y, 1.3f);
            Instantiate(prefabWeak, pos, Quaternion.identity);
        }
    }
    */
    public void Changed()
    {
        Transform myTransform = this.transform;
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(x, y, 1.3f);
        myTransform.position = pos;
    }
}
