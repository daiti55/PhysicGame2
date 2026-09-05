using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルト表示するスクリプト
/// </summary>
public class Result : MonoBehaviour
{
    [Header("スコアテキスト")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("ランクテキスト")]
    [SerializeField] private TextMeshProUGUI rankText;

    [Header("リトライボタン")]
    [SerializeField] private Button retryButton;

    [Header("スコアスクリプト")]
    [SerializeField] private ScoreText scoreTextScript;

    /// <summary>
    /// ゲームが始まる前に実行
    /// </summary>
    private void Awake()
    {
        // リザルト画面を非表示にする
        gameObject.SetActive(false);
    }

    void Start()
    {
        // スコアを表示する
        scoreText.text = "すこあ : " + scoreTextScript.currentScore.ToString("00000");

        if (scoreTextScript.currentScore >= 100)
        {
            rankText.text = "すばらしい";
        }
        else if (scoreTextScript.currentScore >= 80)
        {
            rankText.text = "ふつう";
        }
        else
        {
            rankText.text = "へた";
        }

        // リトライボタンがクリックされた時の処理
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(() =>
        {
            // シーンをリロードする
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        });
    }
}

