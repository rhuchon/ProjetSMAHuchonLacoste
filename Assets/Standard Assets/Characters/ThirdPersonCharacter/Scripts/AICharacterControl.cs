using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target1; // target to aim for
        public Transform target2; // target to aim for


        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            if (target1 != null)
            {
                agent.SetDestination(target1.position);

				
				
                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);
            }

        }


        public void SetTarget1(Transform target1)
        {
            this.target1 = target1;
        }
        public void SetTarget2(Transform target2)
        { 
            this.target2 = target2;
        }
    }
}
