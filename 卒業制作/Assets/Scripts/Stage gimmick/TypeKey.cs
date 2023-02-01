using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeKey : MonoBehaviour
{
    private static readonly KeyCode[] Command =
        {
            KeyCode.W,
            KeyCode.A,
            KeyCode.S,
            KeyCode.D,
         
        };

    private int number;
    private int count = 0;
    private int miss = 0;
    private int max_count = 5;
    private int miss_count = 2;
    
    private int key_num_ = 0;
    public int key_num { get { return key_num_; } set { key_num_ = value; } }
    //�v���C���[�����邩���肷��
    public bool is_player_ = false;

    private bool is_succes = false;
    private bool is_miss = false;

    public bool text_finish = false;

    void Start()
    {
        number = Random.Range(0, Command.Length);
    }

    void Update()
    {
        if (is_player_)
        {
            if (max_judge())
            {
                KeyDetection();

                if (Input.GetKeyDown(Command[number]))
                {


                    if (Correctkey())
                    {
                        RandomKey();
                    }
                }



            }
        }

      
        if (is_succes)
        {
            is_succes = false;
            Finish();
        }

        if(is_miss)
        {
            is_miss = false;
            MissFinish();
        }
        

    }

    // �J�E���g���ő傩�Ŕ��f
    public bool max_judge()
    {
        if(count == max_count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
   
    // ������������Ă��邩�����m /////
    private bool Correctkey()
    {
        // �����������ꂽ�� count + 1 
        if(Input.anyKeyDown)
        {
            key_num_ = 0;
            count += 1;
            Debug.Log(count);
        }

        //miss += 1;
        //Debug.Log(miss);

        //����
        if (count >= max_count)
        {
            // 
            is_succes = true;
        }

        //�~�X
        if(miss == miss_count)
        {
            is_miss = true;
        }

        return true;
    }

    // ����key�������Ŕ��f����
    public bool KeyDetection()
    {

        if(Command[number] == KeyCode.W)
        {
            key_num_ = 1;
        }
        if (Command[number] == KeyCode.A)
        {
            key_num_ = 2;
        }
        if (Command[number] == KeyCode.S)
        {
            key_num_ = 3;
        }
        if (Command[number] == KeyCode.D)
        {
            key_num_ = 4;
        }

        return true;
    }

    //�@�����_���ɃL�[�����������
    private void RandomKey()
    {
        number = Random.Range(0, Command.Length);
    }

    // �����������̏���
    private void Finish()
    {
        Debug.Log("�����I��");
        count = 0;
        text_finish = true;
       
    }

    // ���s�������̏���
    private void MissFinish()
    {
        Debug.Log("���s�ŏI���");
    }
  
}
