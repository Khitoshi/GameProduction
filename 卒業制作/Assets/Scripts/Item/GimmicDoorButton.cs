using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace Item
{
    //Item‚ÌŒ®ƒNƒ‰ƒX
    public class GimmicDoorButton : Item
    {
        //[SerializeField] private int flag_bit_;
        [SerializeField] private Tilemap tile_;
        [SerializeField] private Vector3Int gimic_posiiton_;
        [SerializeField] private TileBase tilebase_after_;

        //private ItemGimic item_gimic;

        public override void Init()
        {
            //item_gimic = GetComponent<ItemGimic>();
        }

        private void Update()
        {
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                Gimic(tile_, gimic_posiiton_, tilebase_after_);
                Destroy(gameObject);
            }
        }

        

    }
}
