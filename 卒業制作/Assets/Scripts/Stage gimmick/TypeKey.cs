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
    
    public int key_num = 0;
    public PlayerTrapMove trap_move;

    private bool is_succes = false;
    private bool is_miss = false;

    public bool text_finish = false;

    void Start()
    {
        number = Random.Range(0, Command.Length);
    }

    void Update()
    {
        if (trap_move.is_fall)
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

    // カウントが最大かで判断
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
   
    // 正しく押されているかを検知 /////
    private bool Correctkey()
    {
        // 正しく押されたら count + 1 
        if(Input.anyKeyDown)
        {
            key_num = 0;
            count += 1;
            Debug.Log(count);
        }

        //miss += 1;
        //Debug.Log(miss);

        if (count == max_count)
        {
            // 
            is_succes = true;
        }

        if(miss == miss_count)
        {
            is_miss = true;
        }

        return true;
    }

    // 中のkeyが何かで判断する
    public bool KeyDetection()
    {

        if(Command[number] == KeyCode.W)
        {
            key_num = 1;
        }
        if (Command[number] == KeyCode.A)
        {
            key_num = 2;
        }
        if (Command[number] == KeyCode.S)
        {
            key_num = 3;
        }
        if (Command[number] == KeyCode.D)
        {
            key_num = 4;
        }

        return true;
    }

    //　ランダムにキーが生成される
    private void RandomKey()
    {
        number = Random.Range(0, Command.Length);
    }

    // 成功した時の処理
    private void Finish()
    {
        Debug.Log("処理終了");
        count = 0;
        text_finish = true;
       
    }

    // 失敗した時の処理
    private void MissFinish()
    {
        Debug.Log("失敗で終わり");
    }
  
}
