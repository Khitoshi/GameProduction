using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyWanderState : StateBase
{
    public CircleCollider2D circle_collider;

    //�ړ���̈ʒu
    private Vector3 target_position_;

    private EnemyInterFace enemy_inter_face;

    private float time_ = 0.0f;

    public float max_staging_time_ = 3.0f; //�ҋ@�̏I������

    public override void enter()
    {
        float radius = circle_collider.radius;

        enemy_inter_face = GetComponent<EnemyInterFace>();

        time_ = 0.0f;
        //light = GetComponent<Light2D>();

        // CircleCollider���̃����_���Ȉʒu���v�Z

        //�V�[�h�l������
        Random.InitState(System.DateTime.Now.Millisecond);

        //���a����X���W�AY���W�����_���l
        var random_x = Random.Range(-radius, radius);
        var random_y = Random.Range(-radius, radius);

        //���g�̍��W�Ƀ����_���l�𑫂��ă����_���l����
        target_position_ = new Vector2(transform.position.x + random_x, transform.position.y + random_y);
        //Debug.Log("Wander start");
    }

    public override void execute()
    {
        if (transform.position == target_position_ || time_ > max_staging_time_)
        {        
            enemy_inter_face.enemy_state_machine.changeSubState((int)EnemyStateMachine.ENEMY_STATE_LABEL.idle);
        }
        else
        {
            //��]
            //enemy_inter_face.enemy_move_.rotationOnlyMove(target_position_);
            //Vector3 dir = (target_position_ - light.transform.position);
            //light.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            //�ړ�
            transform.position = enemy_inter_face.enemy_move_.moveToTarget(transform, target_position_);
        }
        time_ += Time.deltaTime;
    }

    public override void exit()
    {
        //Debug.Log("Wander end");
    }
}
