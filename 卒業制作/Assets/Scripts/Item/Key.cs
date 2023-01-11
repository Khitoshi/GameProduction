using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{ 
    public class Key : Item
    {
        private Item item_;
        [SerializeField] public int flag_bit_ ;

        private new void Start()
        {
            item_ = GetComponent<Item>();
            item_.Start();
        }

        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag != "Player") return;

            item_flag_manager_.SetKeyBit(flag_bit_);
            item_flag_manager_.PrintFlag();
            Destroy(gameObject);
        }
    }
}
