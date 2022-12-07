using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Item
{
    //Itemの基底クラス
    public class Item : MonoBehaviour
    {
        [SerializeField] protected ItemFlagDateBase item_flag_manager_;
        
        public void Start()
        {   
        }

        private void Update()
        {
        }


        //タイルを変化させる
        protected void ChangeTile(Tilemap tileMap, Vector3Int position, TileBase afterTilebase)
        {
            Tilemap tile = tileMap;
            Debug.Log("set tilemap");
            tile.SetTile(position, afterTilebase);
        }
    }
}
