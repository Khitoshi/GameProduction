using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemGimic : MonoBehaviour
{
    public void ChangeTile(Vector3Int position, TileBase tilebase_after)
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.SetEditorPreviewTile(position, tilebase_after);
    }

    //�I�u�W�F�N�g�̃A�N�e�B�u�ύX
    //public void SetActive(GameObject obj, bool isActive)
    public void SetActive(Vector3Int position, bool isActive)
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.GetTile(position);
        
        //  obj.SetActive(false);
    }
}
