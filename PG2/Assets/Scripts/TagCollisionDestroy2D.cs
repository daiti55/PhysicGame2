using UnityEngine;

/// <summary>
/// 特定のタグを持つオブジェクトと当たったら、両方を削除するスクリプト
/// </summary>
public class TagCollisionDestroy2D : MonoBehaviour
{
    [Header("反応する相手のタグ")]
    [SerializeField] private string targetTag = "Ball"; // このタグを持つオブジェクトと当たったら反応する

    [Header("当たった時のスコア")]
    [SerializeField] private int scoreValue = 100; // 当たった時に加算するスコア

    ScoreText scoreText; // スコアテキストを管理するUIスクリプト

    private void Start()
    {
        // ScoreTextスクリプトを取得
        scoreText = FindAnyObjectByType<ScoreText>();
    }

    /// <summary>
    /// 他のコライダーとぶつかったときに呼ばれる
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 相手が指定タグでなければ何もしない
        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }

        // 相手を削除
        Destroy(collision.gameObject);

        // 自分も削除
        Destroy(gameObject);

        //どちらか一方だけが処理するようにする
        if (GetInstanceID() > collision.gameObject.GetInstanceID())
        {
            return;
        }

        scoreText.AddScore(scoreValue); //スコアを加算

    }
}
