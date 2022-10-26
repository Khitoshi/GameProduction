using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCheckerExample2D : MonoBehaviour
{
    // 自分自身
    [SerializeField] private Transform _self;

    // ターゲット
    [SerializeField] private Transform _target;

    // 視野角（度数法）
    [SerializeField] private float _sightAngle;

    // 視界の最大距離
    [SerializeField] private float _maxDistance = float.PositiveInfinity;

    private float time = 10.0f;//レイを表示する時間

    /// ターゲットが見えているかどうか

    public bool IsVisible()
    {
        // 自身の位置
        Vector2 selfPos = _self.position;
        // ターゲットの位置
        Vector2 targetPos = _target.position;

        // 自身の向き（正規化されたベクトル）
        // この例では右向きを正面とする
        Vector2 selfDir = _self.right;

        // ターゲットまでの向きと距離計算
        var targetDir = targetPos - selfPos;
        var targetDistance = targetDir.magnitude;

        // cos(θ/2)を計算
        var cosHalf = Mathf.Cos(_sightAngle / 2 * Mathf.Deg2Rad);

        // 自身とターゲットへの向きの内積計算
        // ターゲットへの向きベクトルを正規化する必要があることに注意
        var innerProduct = Vector2.Dot(selfDir, targetDir.normalized);

        //デバッグ
        if (innerProduct > cosHalf)
        {
            Ray ray = new Ray(selfPos, targetDir);
            Debug.DrawRay(ray.origin, ray.direction * _maxDistance, Color.red, time);
        }





        // 視界判定
        return innerProduct > cosHalf && targetDistance < _maxDistance;
    }



    // 視界判定の結果をGUI出力
    private void OnGUI()
    {
        // 視界判定
        var isVisible = IsVisible();

        // 結果表示
        GUI.Box(new Rect(20, 20, 150, 23), $"isVisible = {isVisible}");

    }

}
