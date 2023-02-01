using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pitfall : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if(collsion.gameObject.tag == "Player")
        {
           
            PlayerInterFace player = collsion.gameObject.GetComponent<PlayerInterFace>();
            player.transitionPitfallState();

            //自身にアタッチされているTypeKeyをプレイヤーへ送る
            player.player_trap_move.type_key = GetComponent<TypeKey>();

            //初期化処理及びプレイヤー判定処理
            GetComponent<TextUi>().is_player_ = true;
            var type_key = GetComponent<TypeKey>();
            type_key.is_player_ = true;
            type_key.text_finish = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {

            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("otosiana_2");
            collsion.gameObject.GetComponent<PlayerInterFace>().player_trap_move.type_key = null;

            GetComponent<TextUi>().is_player_ = false;
            GetComponent<TypeKey>().is_player_ = false;
        }
    }


}

