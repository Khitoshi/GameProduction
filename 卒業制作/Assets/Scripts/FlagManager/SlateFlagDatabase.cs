using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlateFlag", menuName = "SlateFlagDateBase")]
public class SlateFlagDatabase : FlagDateBase
{

    //Î”Âƒtƒ‰ƒO
    public int SlateFlagBit_;

    //‰Šú‰»
    public override void Init()
    {
        SlateFlagBit_ = 0;
    }

    public void SetFlagBit(int bit)
    {
        SlateFlagBit_ = 1 << bit;
    }

}
