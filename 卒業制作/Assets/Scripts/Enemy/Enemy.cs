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
        public EnemyFOV enemy_fov_{get;private set;}
        public EnemyRandomMove enemy_random_move_ { get; private set; }
        public EnemyTranslation enemy_translation_ { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            enemy_fov_ = GetComponent<EnemyFOV>();
            enemy_random_move_ = GetComponent<EnemyRandomMove>();
            enemy_translation_ = GetComponent<EnemyTranslation>();
        }
    
        // Update is called once per frame
        void Update()
        {
        }
    }
}
