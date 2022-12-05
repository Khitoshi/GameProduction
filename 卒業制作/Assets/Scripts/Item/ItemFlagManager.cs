using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    //Item用フラグ管理用クラス
    [CreateAssetMenu(fileName ="ItemFlagManager",menuName = "ItemFlagManager")]
    public class ItemFlagManager : ScriptableObject
    {
        private int Key;

        public void Init()
        {
            Key = 0;
        }

        public void SetKeyBit(int bit = 0)
        {
            Key = 1 << bit;
        }

        public void PrintFlag()
        {
            Debug.Log("Key:" + Key);
        }

    }
}
