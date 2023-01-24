using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlateFlag", menuName = "SlateFlagDateBase")]
public class SlateFlagDatabase : FlagDateBase
{

    //石板フラグ
    public int SlateFlagBit_;

    //初期化
    public override void Init()
    {
        SlateFlagBit_ = 0;
    }

    public void SetFlagBit(int bit)
    {
        SlateFlagBit_ = 1 << bit;
    }

}
