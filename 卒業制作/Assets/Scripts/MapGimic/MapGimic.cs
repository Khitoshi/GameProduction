using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapGimic
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

        //�^�C����ω�������
        protected void ChangeTile(Tilemap tileMap, Vector3Int position, TileBase afterTilebase)
        {
            Tilemap tile = tileMap;
            Debug.Log("set tilemap");
            //tile.DeleteCells(position, position);
            Destroy(gameObject);
        }

        //�^�C��������
        protected void DestroyTile()
        {
            Destroy(gameObject);
        }


    }
}