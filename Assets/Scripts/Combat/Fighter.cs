using UnityEngine;
using RPG.Movement;
using RPG.Core;
namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float WeaponRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1f;
        [SerializeField] private float weaponDamage = 10f;

        ActionScheduler action;
        private Health target;
        private Mover mover;
        Animator animator;
        float timeSinceLastAttack = 0;


        private void Start() 
        {
            mover = GetComponent<Mover>();
            action = GetComponent<ActionScheduler>();
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return; // if there is no target then exit 

            if (target.IsDead()) return; // if the target is dead then exit 
            
            if (target != null && !GetDistance())
            {
                mover.MoveTo(target.transform.position);
                
            }
            else
            {
                mover.StopNav();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform.position);
            if(timeSinceLastAttack >= timeBetweenAttacks)
            {
                // trigger Hit() event 
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        // Animation Event 
        void Hit()
        {
            target.TakeDamage(weaponDamage);
        }

        private bool GetDistance()
        {
            return Vector3.Distance(transform.position, target.transform.position) < WeaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.GetComponent<Health>();
            action.StartAction(this);
        }


        public void Cancel()
        {
            animator.SetTrigger("stopAttack");
            target = null;
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if(combatTarget == null) return false;
            Health testTarget = combatTarget.GetComponent<Health>();
            return testTarget != null && !testTarget.IsDead();
        }

    }
}

