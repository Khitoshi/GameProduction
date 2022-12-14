using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField]
    private PlayerManager player_manager_;

    [SerializeField]
    private EnemyManager enemy_manager_;


    // Update is called once per frame
    void Update()
    {
        switch(GameManager.game_staging_controller_.staging_state_)
        {
            case GameStagingController.GAME_STAGING_LABEL.none:
                player_manager_.update();
                break;
        }

    }

    private void FixedUpdate()
    {
        switch (GameManager.game_staging_controller_.staging_state_)
        {
            case GameStagingController.GAME_STAGING_LABEL.none:
                player_manager_.fixedUpdate();
                enemy_manager_.fixedUpdate();
                break;

            case GameStagingController.GAME_STAGING_LABEL.game_over:
                enemy_manager_.fixedUpdate();
                break;
        }
    }



}
