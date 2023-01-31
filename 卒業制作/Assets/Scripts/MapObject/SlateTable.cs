using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SlateTable : MonoBehaviour
{

    //�t���O���i�[���Ă���f�[�^�x�[�X
    [SerializeField]private SlateFlagDatabase slate_flag_db_;

    //�ǂ̐Δ��L������\���r�b�g
    [SerializeField] private byte slate_bit_;
    
    //�M�~�b�N�������TileBase������Ă���^�C���}�b�v
    [SerializeField] private Tilemap tilemap;

    //�M�~�b�N�������TileBase
    [SerializeField] private TileBase tilebase_after_change_;

    //TileBase�̈ʒu
    [SerializeField] private Vector3Int position;


    //�M�~�b�N�̏�ԃt���O false = �M�~�b�N�����O
    private bool gimic_flag_;

    // Start is called before the first frame update
    void Start()
    {
        gimic_flag_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //�v���C���[�ȊO���O
        if (collision.gameObject.tag != "Player") return;
        
        //����ɍ������t���O�������Ă��邩���`�F�b�N
        if ((slate_bit_ & slate_flag_db_.SlateFlagBit_) == 0) return;

        //�M�~�b�N�����A�C�e�����������Ă���̂�tilebase������
        //Tilemap tile_map = GetComponent<Tilemap>();
        //tilemap.SetTile(position, tilebase_after_change_);

        tilemap.gameObject.SetActive(false);

        this.transform.GetChild(0).gameObject.SetActive(true);

        //�M�~�b�N�����������̂Ńt���O�𗧂Ă�
        gimic_flag_ = true;
    }

    public bool GetGimicFlag()
    {
        return gimic_flag_;
    }

}
