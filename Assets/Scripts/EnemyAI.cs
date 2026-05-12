using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region Referencias
    public Transform target;
    public NavMeshAgent agent;
    public int attackDamage = 25;
    #endregion

    #region Metodos
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
    #endregion

    #region Daño
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController playerController = other.GetComponent<ThirdPersonController>();

            if (playerController != null)
            {
                playerController.TakeDamage(attackDamage);
                Destroy(gameObject);
            }
        }
    }
    #endregion
}