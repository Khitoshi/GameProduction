using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Item
{
    public class Slate : Item
    {
        //�t���O�Ǘ��p�r�b�g
        [SerializeField]private int slate_flag_bit_;
        // Start is called before the first frame update
        new void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //player�ȊO�͏��O
            if (collision.gameObject.tag != "Player") return;

            //�t���O�𗧂Ă�
            slate_flag_manager_.SetFlagBit(slate_flag_bit_);

            Destroy(gameObject);
        }
    }
}
