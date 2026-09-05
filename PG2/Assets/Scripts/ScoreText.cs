using UnityEngine;
using TMPro;

/// <summary>
/// スコアを表示するテキストを管理するクラス
/// </summary>
public class ScoreText : MonoBehaviour
{
    [Header("スコアを表示するテキスト")]
    TextMeshProUGUI scoreText;

    // 現在のスコア
    public int currentScore = 0;

    // スコアテキストの文字列
    string scoreTextString = "0";

    void Start()
    {
        // スコアテキストを取得
        scoreText = GetComponent<TextMeshProUGUI>();

        // defaultのスコアテキストを設定
        scoreTextString = "Score:00000";
        scoreText.text = scoreTextString;
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        // スコアを増やす
        currentScore += score;

        // スコアテキストを更新する
        scoreTextString = "Score:" + currentScore.ToString("00000");
        scoreText.text = scoreTextString;
    }
}
