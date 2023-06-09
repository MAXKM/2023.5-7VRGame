using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    //スキルのレベル変数
    public int coinUpLevel; //コイン獲得量スキルのレベル
    public int goldEnemyProbabilityLevel; //ゴールド敵確率アップスキルのレベル
    public int bossBattleTimeLevel; //ボス戦時間増量スキルのレベル
    public int razerMagnificationLevel; //レーザーダメ倍率のレベル
    public int powerUpLevel; //パワー上昇のレベル
    public int powerUpTimeLevel; //n秒強化のレベル
    public int laserNumLevel;//レーザーの回数
    public int weakPointNumLevel; //弱点個数
    public int weakPointMagnificationLevel;//弱点倍率のレベル

    public int numberOfPlays; //総周回数

    public int havingTotalCoin; //持ってるコインの合計
}
