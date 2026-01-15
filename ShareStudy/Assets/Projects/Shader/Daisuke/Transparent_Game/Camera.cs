using UnityEngine;

public class MyCamera : MonoBehaviour
{
    [Header("追いかける対象")]
    public Transform target;
    
    [Header("プレイヤーとの距離（オフセット）")]
    public Vector3 offset = new Vector3(0, 5, -10);
    
    [Header("追従のなめらかさ(0〜1)")]
    public float smoothSpeed = 0.125f;

    void LateUpdate() // カメラ追従は LateUpdate が基本です
    {
        if (target == null) return;

        // 目標地点を計算
        Vector3 desiredPosition = target.position + offset;
        
        // なめらかに移動（Lerp）
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // カメラの位置を更新
        transform.position = smoothedPosition;

        // 常にプレイヤーの方向を向く
        transform.LookAt(target);
    }
}