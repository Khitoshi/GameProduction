using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ゲーム演出コントロールクラス
public class GameStagingController : MonoBehaviour
{

    //演出の数
    public enum GAME_STAGING_LABEL
    {
        none = -1,
        game_over = 0,
        game_clear,
    }

    //演出用リスト
    public StateMachine state_machine_;

    //演出中かどうか
    public bool is_staging_ { set; get; } = false;

    public GAME_STAGING_LABEL staging_state_ = GAME_STAGING_LABEL.none;

    // Start is called before the first frame update
    void Start()
    {

        //ゲームオーバー演出ステート登録↓
        state_machine_ = GetComponent<StateMachine>();

        //ゲームオーバー演出ステート登録↑
    }

    // Update is called once per frame
    void Update()
    {
        //演出がセットされた時は処理を行う
        if (staging_state_ != GAME_STAGING_LABEL.none)
        {
            state_machine_.execute();
        }
    }

    public void setStaging(GAME_STAGING_LABEL staging_label)
    {
        staging_state_ = staging_label;
        if (staging_label != GAME_STAGING_LABEL.none)
        {
            is_staging_ = true;
            state_machine_.setState((int)staging_label);
            state_machine_.setSubState((int)staging_label);

        }
        else
            is_staging_ = false;
    }

    public void setStagingNone()
    {
        staging_state_ = GAME_STAGING_LABEL.none;
        is_staging_ = false;
    }
}
