using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    public LayerMask enemyMask;

    public float explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Explode();
    }

    void Explode() {

        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyMask);

        foreach (Collider2D nearbyBody in objectsInRange)
        {
            var enemyInfluence = nearbyBody.GetComponent<Influence>();
            enemyInfluence.Damage(35);
        }
        Destroy(gameObject);
    }
}
