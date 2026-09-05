using UnityEngine;

/// <summary>
/// 画面クリックで、決めた範囲内だけゲームオブジェクトを生成するスクリプト
/// </summary>
public class ClickSpawner : MonoBehaviour
{
    [Header("生成するプレハブ")]
    [SerializeField] private GameObject spawnPrefab; // 生成したいオブジェクトのプレハブ

    [Header("カメラ")]
    [SerializeField] private Camera mainCamera;

    [Header("生成できる範囲")]
    [SerializeField] private float minX = -5f; // 左端
    [SerializeField] private float maxX = 5f;  // 右端
    [SerializeField] private float minY = 4f;  // 下端
    [SerializeField] private float maxY = 5f;  // 上端

    private void Update()
    {
        // プレハブやカメラが無いときは何もしない
        if (spawnPrefab == null || mainCamera == null)
        {
            Debug.LogError("プレハブやカメラが設定されていません。");
            return;
        }

        // 左クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            // マウス位置（画面座標）を取得
            Vector3 screenPos = Input.mousePosition;

            // カメラとの距離を設定（これがないと座標変換がずれる）
            screenPos.z = Mathf.Abs(mainCamera.transform.position.z);

            // 画面座標 → ワールド座標に変換
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenPos);
            worldPos.z = spawnPrefab.transform.position.z;

            // 範囲外なら生成しない
            if (worldPos.x < minX || worldPos.x > maxX)
            {
                return;
            }

            if (worldPos.y < minY || worldPos.y > maxY)
            {
                return;
            }

            // 範囲内なら生成
            Instantiate(spawnPrefab, worldPos, Quaternion.identity);
        }
    }
}

