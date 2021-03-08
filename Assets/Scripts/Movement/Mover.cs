using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;
namespace RPG.Movement
{
    public class Mover : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Fighter fighter;
    ActionScheduler action;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        fighter = GetComponent<Fighter>();
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
        fighter.Cancel();
        agent.SetDestination(dest);
        agent.isStopped = false;   
    }

        public void StopNav() => agent.isStopped = true;
    }
}

