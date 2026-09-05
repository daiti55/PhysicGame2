using UnityEngine;

/// <summary>
/// ターゲットを一定の速度で移動させるスクリプト
/// </summary>
public class MoveTarget : MonoBehaviour
{
    [Header("移動ベクトル")]
    [SerializeField] private Vector2 velocity = new Vector2(2f, 0f); // オブジェクトの向きを基準にした移動方向と速さ

    /// <summary>
    /// 毎フレーム実行
    /// </summary>
    private void Update()
    {
        // 速度 × 前フレームからの経過秒数 で、フレームレートに依存しない一定の移動にする
        Vector3 moveAmount = (Vector3)(velocity * Time.deltaTime);

        // オブジェクトの右方向に合わせて移動する
        transform.localPosition += transform.localRotation * moveAmount;
    }
}


