using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    public int damage;
    // public GameObject target;
    public Vector3 target;
    public bool targetSet;
    public string targetType;
    public float velocity = 5;
    public bool stopProjectile;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // if (target == null)
            // {
            //    Destroy(gameObject);
            //}

            transform.position = Vector3.MoveTowards(transform.position, target, velocity * Time.deltaTime);
            
            if (!stopProjectile)
            {
                if(CheckForEnemy() == true)
                {
                    stopProjectile = true;
                    Destroy(gameObject);
                }
                if(Vector3.Distance(transform.position, target) < 0.5f)

                {

                      stopProjectile = true;
                      Destroy(gameObject);
                    
                }
            }
        }
    }


    private bool CheckForEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyStats>())
            {
                c.GetComponent<CharacterStats>().TakeDamage(30);
                return true;
            }
        }
        return false;
    }
}
