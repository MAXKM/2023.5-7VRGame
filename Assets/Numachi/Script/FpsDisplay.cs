using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsDisplay : MonoBehaviour
{
    int frameCount;
    float prevTime;
    float fps;

    Text fpsText;

    void Reset()
    {
        this.gameObject.name = "FPS";
    }

    void Start()
    {
        //キャンバス生成＆設定
        GameObject canvas_G = new GameObject("FaceCanvas");
        Canvas faceCanvas = canvas_G.AddComponent<Canvas>();
        canvas_G.AddComponent<CanvasRenderer>();


        //レンダリングをfaceCameraに
        faceCanvas.renderMode = RenderMode.WorldSpace;

        //このゲームオブジェクトの親、ポジションを設定
        this.gameObject.transform.parent = Camera.main.transform;
        this.gameObject.transform.localPosition = Vector3.zero;
        this.gameObject.transform.localRotation = Quaternion.identity;

        //キャンバスの親、ポジションを設定
        canvas_G.transform.parent = this.gameObject.transform;
        canvas_G.transform.localPosition = new Vector3(0, 0, 0.3f);
        canvas_G.transform.localScale = new Vector3(0.01f, 0.01f, 0);
        canvas_G.transform.localRotation = Quaternion.identity;

        //テキスト生成＆設定
        GameObject text_G = new GameObject("FpsText");
        fpsText = text_G.AddComponent<Text>();
        fpsText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        fpsText.fontSize = 34;
        fpsText.alignment = TextAnchor.MiddleCenter;

        text_G.transform.parent = canvas_G.transform;

        //テキストのポジションを調整
        RectTransform textRect = text_G.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(1000, 1000);
        textRect.anchoredPosition = new Vector3(0, 0, 0);
        textRect.localScale = new Vector3(0.1f, 0.1f, 1);
        textRect.localRotation = Quaternion.identity;
    }

    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            fpsText.text = ((int)fps).ToString() + "FPS";

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }

}
