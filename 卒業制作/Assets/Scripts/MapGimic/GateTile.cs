using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapGimics;
using UnityEngine.Tilemaps;
using Item;

//����̏���������܂ŕǂƂȂ�^�C��
public class GateTile : MapGimic
{

    private int slate_index_;

    //�^�C�����ω�����������p
    private bool is_change_ = false;

    //�ω���̃^�C���摜
    [SerializeField] private TileBase tilebase_after_;

    //�X�e�[�W�̐Δo�^�p
    [SerializeField]
    private List<Slate> slate_lisit_;

    //�X�e�[�W��̐Δ̃r�b�g���v�l�p
    private int slate_bits_;

    // Start is called before the first frame update
    void Start()
    {
        slate_index_ = GameManager.date_base_manager_.flag_date_base.IndexOf(new SlateFlagDatabase());
        is_change_ = false;

        //�e�Δ̃r�b�g���v�l�Z�o
        foreach(Slate slate in slate_lisit_)
        {
            slate_bits_ += slate.slate_flag_bit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SlateFlagDatabase slate_data_base = (SlateFlagDatabase)GameManager.date_base_manager_.flag_date_base[1];

        if (slate_data_base != null)
        {
            if(slate_data_base.SlateFlagBit_ == slate_bits_ && !is_change_)
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                int z = (int)transform.position.z;
                Vector3Int vec_int = new Vector3Int(x, y, z);
                ChangeTile(GetComponent<Tilemap>(), vec_int, tilebase_after_);
                is_change_ = true;

                //�����蔻�������
                GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
    }
}
