using UnityEngine;
using RPG.Movement;
namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float WeaponRange = 2f;

        Transform target;
        private Mover mover;


        private void Start() 
        {
            mover = GetComponent<Mover>();
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
        }

        public void Cancel()
        {
            target = null;
        }

    }
}

