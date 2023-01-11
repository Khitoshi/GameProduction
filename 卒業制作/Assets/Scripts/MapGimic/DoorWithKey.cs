using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


namespace MapGimic
{
    //���ŊJ���h�A
    public class DoorWithKey : MapGimic
    {
        //�^�C���}�b�v�ł̃|�W�V����
        [SerializeField] private List<Vector3Int> tilemap_positions_;
        //���g�̃^�C���}�b�v
        [SerializeField] private Tilemap    this_tilemap_;
        //�J����̔��̃^�C��
        [SerializeField] private TileBase   tilebase_after_;
        //�A�C�e���̃t���O���i�[����Ă���f�[�^�x�[�X
        [SerializeField] private ItemFlagDateBase item_flag_datebase_;

        [SerializeField] private int door_opne_flag_;
        void Start()
        {
            //key_ = GetComponent<Item.Key>();
            //Debug.Log(key_.flag_bit_);

            

        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player") return;

            //player��postion��vector3Int�ɕϊ�
            Vector3Int PlayerPos = new Vector3Int((int)collision.transform.position.x, (int)collision.transform.position.y, (int)collision.transform.position.z);

            //�㉺���E��position��o�^
            List<Vector3Int> positions = new List<Vector3Int>();

            //�����E���Ă��邩�̔���
            if (item_flag_datebase_.Key != door_opne_flag_) return;
            
            

            foreach(Vector3Int pos in tilemap_positions_)
            {
                //���g�̃^�C����ύX
                ChangeTile(this_tilemap_, pos, tilebase_after_);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player") return;
            //collision.gameObject.GetComponent<PlayerInterFace>().transitionGameClearState();
        }
    }
}
