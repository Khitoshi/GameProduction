using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapGimic
{
    public class DoorWithSlateTableGimic : MapGimic
    {
        //gimic object: slate table
        [SerializeField] List<SlateTable> slate_tables_;

        //�ύX����TIleBase��position
        [SerializeField] Vector3Int position_;

        //�A�j���[�V�����̍Đ��𔻒f����flag false = �Đ����Ă��Ȃ�
        private bool is_animation_;

        private bool is_gimic_;

        TileAnimation animation_;

        // Start is called before the first frame update
        void Start()
        {
            //�A�j���[�V�����Đ��t���O
            is_animation_ = false;

            //�M�~�b�N�����t���O
            is_gimic_ = false;

            //tile_animation = GetComponent<TileAnimation>();
            animation_ = GetComponent<TileAnimation>();
        }
    
        // Update is called once per frame
        void Update()
        {
            //�M�~�b�N�̃t���O���m�F���ăh�A���J����
            Open();

            //tile. 
            PlayAnimation();
        }

        /// <summary>
        /// �M�~�b�N�̃t���O���m�F���āA�t���O�������Ă���ꍇ�h�A���J����
        /// </summary>
        private void Open()
        {
            //�M�~�b�N���������Ă���ꍇ����Ȃ�
            if (is_gimic_) return;

            //flag check loop
            foreach (SlateTable slatetable in slate_tables_)
            {
                //�M�~�b�N�̃t���O�`�F�b�N false = �M�~�b�N�����O
                if (!slatetable.GetGimicFlag()) return;
            }

            //�K�v�ȃM�~�b�N���S���A�����Ă���̂�
            //TileBase��ύX����

            //�����蔻�������
            GetComponent<TilemapCollider2D>().enabled = false;

            //�M�~�b�N�����������̂ŃA�j���[�V�����𗬂��t���O�𗧂Ă�
            is_animation_ = true;
            is_gimic_ = true;
        }

        /// <summary>
        /// �A�j���[�V�����t���O���m�F���āA�����Ă���ꍇ�A�j���[�V�����𗬂�
        /// </summary>
        private void PlayAnimation()
        {
            //�A�j���[�V�����t���O�������Ă��Ȃ��ꍇ�A���O����
            if (!is_animation_) return;
            //�A�j���[�V�����Đ�
            animation_.PlayAnimation(GetComponent<Tilemap>(), position_);

            //�A�j���[�V�����Đ����������̂�animation�t���O��false�ɂ���
            is_animation_ = false;
        }
    }
}
