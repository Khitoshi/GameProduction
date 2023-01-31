using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの波動スキルと敵の接触判定用
public class PlayerWaveCollision : MonoBehaviour
{
    //delegate を付けた関数はメソッド(生成時に〇〇する等)を代入出来る。コールバックの仕組みを作れる
    public delegate void onHitWaveEnemyCollision(Collider2D other);    //waveオブジェクトが敵と接触した場合
    public delegate void onHitWaveOtherCollision(Collider2D other);    //waveオブジェクトが敵以外と接触した場合

    //関数登録用変数を宣言
    public onHitWaveEnemyCollision on_hit_wave_enemy_function_;
    public onHitWaveOtherCollision on_hit_wave_other_function_;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Enemy")
        {

            //プレイヤー以外のオブジェクトと接触したら自身を破棄する
            if (collision.transform.tag != "Player" && collision.transform.tag != "EnemySight")
            {
                if (on_hit_wave_other_function_ != null)
                {
                    on_hit_wave_other_function_(collision);
                }

            }
            return;
        }

        if (on_hit_wave_enemy_function_ != null)
        {
            var enemy = collision.GetComponent<EnemyInterFace>();
            if (!enemy.is_hit)
            {
                enemy.subtractHp(1);
                enemy.is_hit = true;
                on_hit_wave_enemy_function_(collision);
            }
        }

    }
}
