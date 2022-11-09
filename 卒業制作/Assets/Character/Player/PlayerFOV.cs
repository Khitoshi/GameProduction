using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerFOV : MonoBehaviour
{
    [SerializeField] private float angle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Stay: " + $"{Stay}");
        //State = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {   
        //name = "0";
        if (other.gameObject.tag == "Enemy") //���E�͈͓̔��̓����蔻��
        {
            //name = "1";
            //���E�̊p�x���Ɏ��܂��Ă��邩
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.up, posDelta);

            if (target_angle < angle) //target_angle��angle�Ɏ��܂��Ă��邩�ǂ���
            {
                Debug.DrawRay(transform.position, posDelta);
                if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Ray���g�p����target�ɓ������Ă��邩����
                {
                    if (hit.collider == other)
                    {
                        Debug.Log(hit.collider.name);
                        //name = hit.collider.name;
                    }
                }
            }
        }
    }



    

    #region Debug
    private void OnGUI()
    {
        //Vector3 forward = transform.TransformDirection(transform.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.red,0.01f);
        //GUI.Box(new Rect(20, 20, 150, 23), "Name: "+$"{}");
        // ���ʕ\��
    }
    #endregion
}
