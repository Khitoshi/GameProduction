using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//演出時のオブジェクト
public struct StagingObject
{
    public List<GameObject> objects_;  //演出時に必要となるオブジェクトを追加していく(Prefabのオブジェクトのみ追加)
    public bool can_operation_;  //演出中、プレイヤーが操作可能かどうか

    public bool can_object_update_; //全てのオブジェクトが演出中に更新可能かどうか

    public float max_staging_time;  //演出時間

};

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
    private List<StagingObject> staging_objects_;

    private StagingObject[] game_staging_;
    public GameObject game_over_text_;

    public StateMachine state_machine_;
    public StagingState staging_;
    public GameOverStaging game_over_staging_;

    //演出中かどうか
    private bool is_staging_ { set; get; } = false;

    private GAME_STAGING_LABEL staging_state_ = GAME_STAGING_LABEL.none;

    // Start is called before the first frame update
    void Start()
    {
        staging_objects_ = new List<StagingObject>();

        //ゲームオーバー時の設定↓
        game_staging_ = new StagingObject[1];
        if (game_over_text_ != null)
        {
            game_staging_[0].objects_ = new List<GameObject>();
            game_staging_[0].objects_.Add(game_over_text_);
        }
        game_staging_[0].can_operation_ = false;
        game_staging_[0].can_object_update_ = false;
        game_staging_[0].max_staging_time = 3.0f;
        //ゲームオーバー時の設定↑

        for (int i = 0; i < game_staging_.Length; i++)
        {
            staging_objects_.Add(game_staging_[i]);
        }

        //ゲームオーバー演出ステート登録↓
        state_machine_ = GetComponent<StateMachine>();

        staging_ = GetComponent<StagingState>();
        state_machine_.registerState(staging_);
        //game_over_staging_ = new GameOverStaging(game_staging_[0]);
        game_over_staging_ = GetComponent<GameOverStaging>();
        state_machine_.registerSubState((int)GAME_STAGING_LABEL.game_over, game_over_staging_);
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
            state_machine_.setState((int)GAME_STAGING_LABEL.game_over);

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
