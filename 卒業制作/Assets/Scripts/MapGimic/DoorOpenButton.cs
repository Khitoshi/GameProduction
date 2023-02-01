using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace MapGimics
{
    //�{�^���ŊJ���h�A
    public class DoorOpenButton : MapGimic
    {
        //�ω����������^�C���}�b�v
        [SerializeField] private Tilemap tile_;
        //�ω����������^�C���̃|�W�V����
        [SerializeField] private Vector3Int gimic_posiiton_;
        //�ω���̃^�C���摜
        [SerializeField] private TileBase tilebase_after_;

        public void Start()
        {
        }

        private void Update()
        {
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag != "Player") return;

            //�^�C����ω�������
            ChangeTile(tile_, gimic_posiiton_, tilebase_after_);

            /*
            CameraEvent cameraevent;
            cameraevent = GetComponent<CameraEvent>();
            cameraevent.flag = true;
            */
            CameraEvent cameraevent = GameObject.Find("�J�����C�x���g�p").GetComponent<CameraEvent>();
            Vector3 position = new Vector3(gimic_posiiton_.x, gimic_posiiton_.y, -5);
            cameraevent.SetEvent(position, true);

            //���g���폜
            Destroy(gameObject);
        }
    }
}
