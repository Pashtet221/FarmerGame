using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float areaOfEffect;
    [SerializeField] private int damage;
    [SerializeField] private GameObject effect;
    [SerializeField] private LayerMask WhatIsDistructible;

    
    void Update()
    {
        if (timer <= 0)
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, WhatIsDistructible);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<Enemy>().ApplyDamage(damage);
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject); 
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}
