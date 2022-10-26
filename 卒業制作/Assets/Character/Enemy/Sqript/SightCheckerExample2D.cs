using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCheckerExample2D : MonoBehaviour
{
    // �������g
    [SerializeField] private Transform _self;

    // �^�[�Q�b�g
    [SerializeField] private Transform _target;

    // ����p�i�x���@�j
    [SerializeField] private float _sightAngle;

    // ���E�̍ő勗��
    [SerializeField] private float _maxDistance = float.PositiveInfinity;

    private float time = 10.0f;//���C��\�����鎞��

    /// �^�[�Q�b�g�������Ă��邩�ǂ���

    public bool IsVisible()
    {
        // ���g�̈ʒu
        Vector2 selfPos = _self.position;
        // �^�[�Q�b�g�̈ʒu
        Vector2 targetPos = _target.position;

        // ���g�̌����i���K�����ꂽ�x�N�g���j
        // ���̗�ł͉E�����𐳖ʂƂ���
        Vector2 selfDir = _self.right;

        // �^�[�Q�b�g�܂ł̌����Ƌ����v�Z
        var targetDir = targetPos - selfPos;
        var targetDistance = targetDir.magnitude;

        // cos(��/2)���v�Z
        var cosHalf = Mathf.Cos(_sightAngle / 2 * Mathf.Deg2Rad);

        // ���g�ƃ^�[�Q�b�g�ւ̌����̓��όv�Z
        // �^�[�Q�b�g�ւ̌����x�N�g���𐳋K������K�v�����邱�Ƃɒ���
        var innerProduct = Vector2.Dot(selfDir, targetDir.normalized);

        //�f�o�b�O
        if (innerProduct > cosHalf)
        {
            Ray ray = new Ray(selfPos, targetDir);
            Debug.DrawRay(ray.origin, ray.direction * _maxDistance, Color.red, time);
        }





        // ���E����
        return innerProduct > cosHalf && targetDistance < _maxDistance;
    }



    // ���E����̌��ʂ�GUI�o��
    private void OnGUI()
    {
        // ���E����
        var isVisible = IsVisible();

        // ���ʕ\��
        GUI.Box(new Rect(20, 20, 150, 23), $"isVisible = {isVisible}");

    }

}
