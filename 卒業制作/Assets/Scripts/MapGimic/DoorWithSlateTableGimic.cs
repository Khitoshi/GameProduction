using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapGimic
{
    public class DoorWithSlateTableGimic : MapGimic
    {
        //gimic object: slate table
        [SerializeField] List<SlateTable> slate_table_;

        //�M�~�b�N������ɕύX����TileBase
        [SerializeField] TileBase tilebase_after_change_;

        //�ύX����TIleBase��position
        [SerializeField] Vector3Int position_;

        //�A�j���[�V�����̍Đ��𔻒f����flag false = �Đ����Ă��Ȃ�
        private bool is_animation_;

        // Start is called before the first frame update
        void Start()
        {
            is_animation_ = false;
        }
    
        // Update is called once per frame
        void Update()
        {
            //�M�~�b�N�̃t���O���m�F���ăh�A���J����
            Open();



        }

        /// <summary>
        /// �M�~�b�N�̃t���O���m�F���āA�t���O�������Ă���ꍇ�h�A���J����
        /// </summary>
        private void Open()
        {
            //�M�~�b�N������ɃA�j���[�V�����𗬂��̂ōĐ����̏ꍇ�͈ȉ����������Ȃ�
            if (is_animation_) return;

            //flag check loop
            foreach (SlateTable slatetable in slate_table_)
            {
                //�M�~�b�N�̃t���O�`�F�b�N false = �M�~�b�N�����O
                if (!slatetable.GetGimicFlag()) return;
            }

            //�K�v�ȃM�~�b�N���S���A�����Ă���̂�
            //TileBase��ύX����
            Tilemap tile_map_ = GetComponent<Tilemap>();
            tile_map_.SetTile(position_, tilebase_after_change_);

            //�����蔻�������
            //tile_map_.SetColliderType(position_, Tile.ColliderType.None);
            GetComponent<TilemapCollider2D>().enabled = false;
            GetComponent<TilemapCollider2D>().enabled = true;

            //�M�~�b�N�����������̂ŃA�j���[�V�����𗬂��t���O�𗧂Ă�
            is_animation_ = true;
        }

        /// <summary>
        /// �A�j���[�V�����t���O���m�F���āA�����Ă���ꍇ�A�j���[�V�����𗬂�
        /// </summary>
        private void PlayAnimation()
        {
            //�A�j���[�V�����t���O�������Ă��Ȃ��ꍇ�A���O����
            if (!is_animation_) return;




        }


    }
}
