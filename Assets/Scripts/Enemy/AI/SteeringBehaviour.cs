using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
    [RequireComponent(typeof(EnemyAgent))]
    public class SteeringBehaviour : MonoBehaviour
    {
        // Public:
        public float weighting = 7.5f;
        [HideInInspector]
        public EnemyAgent owner;

        protected virtual void Awake()
        {
            owner = GetComponent<EnemyAgent>();
        }

        public virtual Vector3 GetForce()
        {
            return Vector3.zero;
        }
    }
}