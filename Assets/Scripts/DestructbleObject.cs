using UnityEngine;

namespace DefaultNamespace
{
    public class DestructbleObject : MonoBehaviour

    {
    [SerializeField] private float hpCurrent = 10;


    public void ReceiveDamage(float damage)
    {
        hpCurrent -= damage;
        if (hpCurrent < 0f)
        {
            Destroy(gameObject);
        }
    }
    }
}