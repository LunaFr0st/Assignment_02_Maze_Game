using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

namespace EnemyAI
{
    public class Wander : SteeringBehaviour
    {
        public float offset = 1.0f;
        public float radius = 1.0f;
        public float jitter = 0.2f;

        private Vector3 targetDir;
        private Vector3 randomDir;

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;

         
            float randX = Random.Range(0, 0xfff);
            float randZ = Random.Range(0, 0xfff);

            #region Calculate Random Direction
            // Create the random direction vector
            randomDir = new Vector3(randX, 0, randZ);
            // Normalize the random direction
            randomDir = randomDir.normalized;
            // Multiply randomDir by jitter
            randomDir *= jitter;
            #endregion

            #region Calculate Target Direction
            // Append target direction with random directon
            targetDir += randomDir;
            // Normalize the target direction
            targetDir = targetDir.normalized;
            // Multiply target direction by the radius
            targetDir *= radius;
            #endregion
            // Calculate seek position using targetDir
            Vector3 seekPos = transform.position + targetDir;
            seekPos += transform.forward.normalized * offset;

            #region GizmosGL
            Vector3 forwardPos = transform.position + transform.forward.normalized * offset;
            GizmosGL.color = Color.red;
            GizmosGL.AddCircle(forwardPos, radius, Quaternion.LookRotation(Vector3.down));
            GizmosGL.color = Color.blue;
            GizmosGL.AddCircle(seekPos + Vector3.up * 0.1f, radius * 0.6f, Quaternion.LookRotation(Vector3.down));

            #endregion

            #region Wander
            // Calculate direction
            Vector3 direction = seekPos - transform.position;
            // Is direction valid? (not zero)
            if (direction.magnitude > 0)
            {
                // Calculate force
                Vector3 desiredForce = direction.normalized * weighting;
                force = desiredForce - owner.velocity;
            }
            #endregion

            // Return the force ... luke
            return force;
        }
    }
}