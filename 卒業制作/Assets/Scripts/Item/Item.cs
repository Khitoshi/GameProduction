using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Item
{

    //Item‚ÌŠî’êƒNƒ‰ƒX
    public class Item :MonoBehaviour
    {
        protected ItemFlagManager item_flag_manager_;

        private void Start()
        {
            item_flag_manager_ = ScriptableObject.CreateInstance<ItemFlagManager>();
            item_flag_manager_.Init();

            Init();
        }

        public virtual void Init() {}
       

        private void Update()
        {
        }

        protected void Gimic(Tilemap tileMap,Vector3Int position, TileBase afterTilebase)
        {
            Tilemap tile = tileMap;
            Debug.Log("set tilemap");
            tile.SetTile(position, afterTilebase);
        }

    }

}
