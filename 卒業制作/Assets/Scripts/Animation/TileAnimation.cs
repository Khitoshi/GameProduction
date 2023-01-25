using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAnimation : MonoBehaviour
{

    //�A�j���[�V�����f��
    [SerializeField] private List<TileBase> anim_tile_bases_;


    //�A�j���[�V�����̃��[�v�������s����? false = �A�j���[�V������1��̂�
    //[SerializeField] private bool is_loop_ = false;
    private bool is_loop_ = false;

    //�A�j���[�V�������ڃ^�C�� 1.0f = 1�b
    [SerializeField] private float wait_timer_ = 0.0f;

    //�A�j���[�V�������Đ������邩? true = �Đ�������
    private bool is_play_animation_ = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    /// <summary>
    /// �A�j���[�V�����Đ�
    /// </summary>
    /// <param name="tilemap">�ύX�������^�C���̂���^�C���}�b�v</param>
    /// <param name="pos">�^�C���̃|�W�V����</param>
    public void PlayAnimation(Tilemap tilemap, Vector3Int pos)
    {
        if (!is_play_animation_) return;

        StartCoroutine(ChangeTile(tilemap, pos));

        is_play_animation_ = is_loop_;
    }

    /// <summary>
    /// �^�C����ω�������
    /// </summary>
    /// <param name="tilemap">�ω����������^�C���̂���^�C���}�b�v</param>
    /// <param name="pos">�^�C���̃|�W�V����</param>
    /// <returns></returns>
    public IEnumerator ChangeTile(Tilemap tilemap,Vector3Int pos)
    {
        foreach(TileBase tilea in anim_tile_bases_ )
        {
            tilemap.SetTile(pos, tilea);
            //WaitForSeconds(0.3f);
            yield return new WaitForSeconds(wait_timer_);
        }
    }
}
