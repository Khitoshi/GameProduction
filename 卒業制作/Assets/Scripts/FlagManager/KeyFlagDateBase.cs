using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Itemフラグ管理用クラス
[CreateAssetMenu(fileName ="KeyFlag",menuName = "KeyFlagDateBase")]
public class KeyFlagDateBase : FlagDateBase
{
    public int Key;// { get; set; }
    public override void Init()
    {
        Key = 0;
    }

    public void SetKeyBit(int bit)
    {
        Key = 1 << bit;
    }

    public void PrintFlag()
    {
        Debug.Log("Key:" + Key);
    }
}

