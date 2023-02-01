using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


namespace MapGimics
{
    //���ŊJ���h�A
    public class DoorWithKey : MapGimic
    {
        //�^�C���}�b�v�ł̃|�W�V����
        //[SerializeField] private List<Vector3Int> tilemap_positions_;

        //���g�̃^�C���}�b�v
        [SerializeField] private Tilemap this_tilemap_;
        //�J���O�̃^�C��
        [SerializeField] private TileBase tilebase_befor_;
        //�J����̔��̃^�C��
        [SerializeField] private TileBase   tilebase_after_;
        //�A�C�e���̃t���O���i�[����Ă���f�[�^�x�[�X
        [SerializeField] private KeyFlagDateBase item_flag_datebase_;

        [SerializeField] private int door_opne_flag_;
        void Start()
        {
            this_tilemap_ = GetComponent<Tilemap>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary>
        /// �h�A�ɐG�ꂽ�ۂ̏���
        /// </summary>
        /// <param name="collision">player or enemy</param>
        private void OnCollisionStay2D(Collision2D collision)
        {
            //tag �`�F�b�N
            if (collision.gameObject.tag != "Player") return;

            //�����E���Ă��邩�̔���
            if (item_flag_datebase_.Key != door_opne_flag_) return;

            //���g�̈ʒu��tilemap�Ŏg�p�ł���int�ɕϊ�
            Vector3Int player_position_convert_vector3int = new Vector3Int(0,0,0);
            //�����_�ȉ��؂�̂Ă��ĕϊ�
            player_position_convert_vector3int.x = (int)Mathf.Floor(collision.transform.position.x);
            player_position_convert_vector3int.y = (int)Mathf.Floor(collision.transform.position.y);
            player_position_convert_vector3int.z = (int)Mathf.Floor(collision.transform.position.z);
            Debug.Log(player_position_convert_vector3int);

            //���g�̏㉺���E�̈ʒu��ݒ�
            Vector3Int up,down,left,right;
            //**DirectX�ł͏オ-����unity�ł͏��+**
            up = down = left = right = player_position_convert_vector3int;
            up.y += 1;
            down.y -= 1;
            left.x += 1;
            right.x -= 1;
            
            //��L�̈ʒu��z��ɓZ�߂�
            Vector3Int[] positions = new Vector3Int[] { up, down, left, right };

            //�㉺���E�ɊJ������h�A���Ȃ����𒲂ׂ�loop
            foreach(Vector3Int pos in positions)
            {
                //�^�C���̑��� �`�F�b�N
                if (!this_tilemap_.HasTile(pos)) continue;

                //�h�A �`�F�b�N
                if(this_tilemap_.GetTile(pos).name == tilebase_befor_.name)
                {
                    Debug.Log("change");
                    //�h�A���������ꍇ�^�C����ύX����
                    this_tilemap_.SetTile(pos, tilebase_after_);
                    
                    //�����蔻�������
                    this_tilemap_.SetColliderType(pos, Tile.ColliderType.None);
                }
            }
        }

    }
}
