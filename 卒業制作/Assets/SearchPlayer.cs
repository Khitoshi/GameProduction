using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    //���L����
    [SerializeField] private Transform self;

    //�^�[�Q�b�g
    [SerializeField] private Transform target;

    //����p
    [SerializeField] private float sightAngle;

    //���싗��
    [SerializeField] private float maxDistance = float.PositiveInfinity;

    #region Logic
    /// <summary>
    /// �^�[�Q�b�g�������Ă��邩�ǂ���
    /// </summary>
    public bool IsVisible()
    {
        // ���g�̈ʒu
        Vector2 selfPos = self.position;
        // �^�[�Q�b�g�̈ʒu
        Vector2 targetPos = target.position;

        // ���g�̌����i���K�����ꂽ�x�N�g���j
        // ���̗�ł͉E�����𐳖ʂƂ���
        Vector2 selfDir = self.right;

        // �^�[�Q�b�g�܂ł̌����Ƌ����v�Z
        var targetDir = targetPos - selfPos;
        var targetDistance = targetDir.magnitude;

        // cos(��/2)���v�Z
        var cosHalf = Mathf.Cos(sightAngle / 2 * Mathf.Deg2Rad);

        // ���g�ƃ^�[�Q�b�g�ւ̌����̓��όv�Z
        // �^�[�Q�b�g�ւ̌����x�N�g���𐳋K������K�v�����邱�Ƃɒ���
        var innerProduct = Vector2.Dot(selfDir, targetDir.normalized);

        // ���E����
        return innerProduct > cosHalf && targetDistance < maxDistance;
    }

    #endregion

    #region Debug

    // ���E����̌��ʂ�GUI�o��
    private void OnGUI()
    {
        // ���E����
        var isVisible = IsVisible();

        // ���ʕ\��
        GUI.Box(new Rect(20, 20, 150, 23), $"isVisible = {isVisible}");
    }
    #endregion
};
