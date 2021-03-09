using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        Animator animator;
        bool isDead = false;


        public bool IsDead()
        {
            return isDead;
        }
        private void Start() 
        {
            animator = GetComponent<Animator>();
        }
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);   
            if (health == 0 && !isDead)
            {
                Die();
            }
        }

        private void Die()
        {
            isDead = true;
            animator.SetTrigger("death");
        }
    }
}

