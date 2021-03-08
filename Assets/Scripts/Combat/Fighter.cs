using UnityEngine;
using RPG.Movement;
using RPG.Core;
namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float WeaponRange = 2f;

        ActionScheduler action;
        Transform target;
        private Mover mover;


        private void Start() 
        {
            mover = GetComponent<Mover>();
            action = GetComponent<ActionScheduler>();
        }
        private void Update()
        {
            if (target == null) return;
            
            if (target != null && !GetDistance())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.StopNav();
            }
        }

        private bool GetDistance()
        {
            return Vector3.Distance(transform.position, target.position) < WeaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            action.StartAction(this);
        }

        public void Cancel()
        {
            target = null;
        }

    }
}

