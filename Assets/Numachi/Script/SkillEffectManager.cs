using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillEffectManager : MonoBehaviour
{
    [SerializeField] HandDetection handDetection;

    [SerializeField] GameInformation gameInformation;

    [SerializeField] SkillManager skillManager;

    [SerializeField] ParticleSystem rocketParticle;

    //左右両方のMeshRenderer
    [SerializeField] MeshRenderer meshRendererR,meshRendererL;

    //n秒強化状態時のマテリアル
    [SerializeField] Material strengthenColor,normalColor;

    //n秒強化時の秒数
    [SerializeField] TextMeshProUGUI timeText,rocketText;

    //残り秒数
    private float reminingSeconds = 0;

    //レベル別制限時間
    private float limitSeconds;

    //レベル別ロケット残数
    private int rocketNum;


    private void Start()
    {
        //初期状態はテキストを非表示
        timeText.gameObject.SetActive(false);
        rocketText.gameObject.SetActive(false);

        //レベル別制限時間を取得
        limitSeconds = skillManager.PowerTimeLimit(gameInformation.powerUpTimeLevel);
        Debug.Log("制限時間" + limitSeconds);

        //ロケットの残数を計算
        rocketNum = RocketNumCaluclation(gameInformation.rocketNumLevel);
        Debug.Log("個数" + rocketNum);
    }
    private void Update()
    {
        if (handDetection.strengthenMode)
        {
            if(gameInformation.powerUpTimeLevel < 2)
            {
                return;
            }

            //時間計測開始
            reminingSeconds += Time.deltaTime;

            //強化状態開始
            StartStrengthenMode();

            //テキストを表示
            DisplayTimeText(handDetection.strengthenMode);

            if (limitSeconds - reminingSeconds <= 0)
            {
                //0秒になったら強化状態終了
                handDetection.strengthenMode = false;
                FinishStregnthenMode();

                //テキストを非表示
                DisplayTimeText(handDetection.strengthenMode);
            }
        }
    }

    //テキストの表示/非表示
    private void DisplayTimeText(bool strMode)
    {
        timeText.gameObject.SetActive(strMode);
        timeText.text = (limitSeconds - reminingSeconds).ToString("n2");
    }

    //強化状態の処理
    private void StartStrengthenMode()
    {
        //両手を赤に変更
        meshRendererL.material = strengthenColor;
        meshRendererR.material = strengthenColor;
    }

    //強化状態終了の処理
    private void FinishStregnthenMode()
    {
        //両手を白に変更
        meshRendererL.material = normalColor;
        meshRendererR.material = normalColor;
    }

    //ロケット発動
    public void RocketLaunch()
    {
        //残数が0だったら発動しない
        if (rocketNum <= 0) return;

        //発動中だったら停止させる
        if(rocketParticle.isPlaying) rocketParticle.Stop();

        //ロケット発動処理
        rocketParticle.Play();

        //残数を減らす
        rocketNum--;
        Debug.Log("残り" + rocketNum);
    }

    //テスト用
    IEnumerator RocketTest()
    {
        yield return new WaitForSeconds(3f);
        rocketText.gameObject.SetActive(false);
    }

    //ロケット残数を計算
    private int RocketNumCaluclation(int level)
    {
        //最大残数
        int max = 3;

        //レベル別に残数を計算
        for(int i = 1;i < max + 1; i++)
        {
            if(level == i)
            {
                rocketNum = i - 1;
            }
        }
        return rocketNum;
    }
}
