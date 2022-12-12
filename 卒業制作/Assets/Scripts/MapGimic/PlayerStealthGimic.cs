using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MapGimic
{
    public class PlayerStealthGimic : MapGimic
    {
        
        //TODO:PlayerのSightが常に反応するのでtagを編集する
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //もし EnterとExitが常に反応する場合は project settings -> physics2d -> Layer Collision Matrix の Steath と Steath に チェックを付ける
            //player以外を除外
            if (collision.tag != "Player") return;
            Debug.Log("Enter");
            //Debug.Log(collision.name);
            //collision.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            //collision.gameObject.layer = LayerMask.NameToLayer("Stealth");
            //レイヤーをStealthModeに変更(stealthはレイヤー衝突マトリックスでEnemy等と衝突しない設定にしている)

            PlayerInterFace player = collision.gameObject.GetComponent<PlayerInterFace>();
            player.transitionStealthState();
        }
        
        
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            
            if (collision.tag != "Player") return;
            Debug.Log("Exit");
            //Debug.Log(collision.name);
            //TODO:他のstateに移動する際の関数orクラスを作りその中にこの処理を書く
            collision.gameObject.layer = LayerMask.NameToLayer("Player");
            //レイヤーをStealthModeに変更(stealthはレイヤー衝突マトリックスでEnemy等と衝突しない設定にしている)
            //PlayerInterFace player = collision.gameObject.GetComponent<PlayerInterFace>();
            //player.transitionPitfallState();
        }
        
    }
}
