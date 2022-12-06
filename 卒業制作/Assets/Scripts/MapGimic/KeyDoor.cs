using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


namespace MapGimic
{
    //���ŊJ���h�A
    public class KeyDoor : MapGimic
    {
        //�^�C���}�b�v�ł̃|�W�V����
        [SerializeField] private Vector3Int this_tilemap_position_;
        //���g�̃^�C���}�b�v
        [SerializeField] private Tilemap    this_tilemap_;
        //�J����̔��̃^�C��
        [SerializeField] private TileBase   tilebase_after_;
        //�A�C�e���̃t���O���i�[����Ă���f�[�^�x�[�X
        [SerializeField] private ItemFlagDateBase item_flag_datebase_;

        // Start is called before the first frame update
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag != "Player") return;
            
            //�����E���Ă��邩�̔���
            if(item_flag_datebase_.Key == 1)
            {
                //���g�̃^�C����ύX
                ChangeTile(this_tilemap_, this_tilemap_position_, tilebase_after_);
            }
        }
    }
}
