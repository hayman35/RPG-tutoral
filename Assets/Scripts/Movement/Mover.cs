using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
{
        NavMeshAgent agent;
        Animator animator;
        ActionScheduler action;
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            action = GetComponent<ActionScheduler>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();        
        }

        private void UpdateAnimator()
        {
            var velocity = agent.velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            animator.SetFloat("forwardSpeed",speed);
        }

        public void MoveTo(Vector3 dest)
        {
            agent.SetDestination(dest);
            agent.isStopped = false;
        
        }
        public void StartMoveAction(Vector3 dest)
        {
            action.StartAction(this);
            agent.SetDestination(dest);
            agent.isStopped = false;   
        }

        public void StopNav() => agent.isStopped = true;

        public void Cancel()
        {
            //animator.SetTrigger("stopAttack");
            agent.isStopped = true;
        }
    }
}

