using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillEffectManager : MonoBehaviour
{
    [SerializeField] HandDetection handDetection;

    //左右両方のMeshRenderer
    [SerializeField] MeshRenderer meshRendererR,meshRendererL;

    //n秒強化状態時のマテリアル
    [SerializeField] Material strengthenColor,normalColor;

    //n秒強化時の秒数
    [SerializeField] TextMeshProUGUI timeText;

    //残り秒数
    float reminingSeconds = 0;

    //レベル別制限時間
    float limitSeconds = 1.5f;

    private void Start()
    {
        timeText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (handDetection.strengthenMode)
        {
            //時間計測開始
            reminingSeconds += Time.deltaTime;

            //強化状態開始
            StartStrengthenMode();

            //テキストを表示
            DisplayTimeText(handDetection.strengthenMode);
        }

        if(limitSeconds - reminingSeconds <= 0)
        {
            //0秒になったら強化状態終了
            handDetection.strengthenMode = false;
            FinishStregnthenMode();

            //テキストを非表示
            DisplayTimeText(handDetection.strengthenMode);
        }
    }

    void DisplayTimeText(bool strMode)
    {
        timeText.gameObject.SetActive(strMode);
        timeText.text = reminingSeconds.ToString("n2");
    }

    //強化状態の処理
    void StartStrengthenMode()
    {
        //両手を赤に変更
        meshRendererL.material = strengthenColor;
        meshRendererR.material = strengthenColor;
    }

    //強化状態終了の処理
    void FinishStregnthenMode()
    {
        //両手を白に変更
        meshRendererL.material = normalColor;
        meshRendererR.material = normalColor;
    }
}
