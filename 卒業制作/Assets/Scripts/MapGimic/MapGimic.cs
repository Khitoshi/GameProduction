using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapGimics
{
    public class MapGimic : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //タイルを変化させる
        protected void ChangeTile(Tilemap tileMap, Vector3Int position, TileBase afterTilebase)
        {
            Tilemap tile = tileMap;
            Debug.Log("set tilemap");
            //tileMap.SwapTile()
            //tile.DeleteCells(position, position);
            tile.RefreshAllTiles();
            //Destroy(gameObject);
        }

        //タイルを消す
        protected void DestroyTile()
        {
            Destroy(gameObject);
        }


    }
}