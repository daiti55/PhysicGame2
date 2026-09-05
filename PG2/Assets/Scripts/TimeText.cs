using UnityEngine;
using TMPro;

/// <summary>
/// 残り時間を表示するクラス
/// </summary>
public class TimeText : MonoBehaviour
{
    [Header("残り時間設定")]
    public float time;

    TextMeshProUGUI timeText;
    float currentTime = 0;

    [Header("オブジェクト生成スクリプト")]
    [SerializeField] private ClickSpawner spawner;

    [Header("リザルト表示")]
    [SerializeField] private GameObject result;

    void Start()
    {
        // 残り時間を初期化
        currentTime = time;

        // TextMeshProUGUIコンポーネントを取得
        timeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // 残り時間を減らす
        currentTime = currentTime - Time.deltaTime;

        // 残り時間を表示する
        timeText.text = "Time:" + currentTime.ToString("00");

        // 残り時間が0になったら、カウントを止める
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
