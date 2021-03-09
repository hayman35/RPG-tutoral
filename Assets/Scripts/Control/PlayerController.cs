using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
{
    Mover move;
    Fighter fighter;
    private void Start() 
    {
        move = GetComponent<Mover>();
        fighter = GetComponent<Fighter>();
    }
    private void Update()
    {
        if (InteractWithCombat()) return;
        if (InteractWithMovement()) return;
    }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
                foreach (RaycastHit hit in hits)
                {
                    CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
                    if (!fighter.CanAttack(target)) continue;
                
                    if (Input.GetMouseButtonDown(0))
                    {
                        fighter.Attack(target);
                    } 
                    return true;
                }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    move.StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

