using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Item
{
    //Itemの基底クラス
    public class Item : MonoBehaviour
    {
        [SerializeField] protected KeyFlagDateBase item_flag_manager_;
        [SerializeField] protected SlateFlagDatabase slate_flag_manager_;
        
        public void Start()
        {   
        }

        private void Update()
        {
        }
    }
}
