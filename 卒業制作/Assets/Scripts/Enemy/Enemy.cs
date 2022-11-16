using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyFOV))]
    [RequireComponent(typeof(EnemyRandomMove))]
    [RequireComponent(typeof(EnemyTranslation))]
    public class Enemy : MonoBehaviour
    {
        public EnemyFOV enemyFOV{get;private set;}
        public EnemyRandomMove enemyRandomMove { get; private set; }
        public EnemyTranslation enemyTranslation { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            enemyFOV = GetComponent<EnemyFOV>();
            enemyRandomMove = GetComponent<EnemyRandomMove>();
            enemyTranslation = GetComponent<EnemyTranslation>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
