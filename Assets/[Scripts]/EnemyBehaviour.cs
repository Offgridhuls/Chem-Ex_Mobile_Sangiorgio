using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAgro;
    public LayerMask playerMask;
    public GameObject player;
    public float DistanceToStop = 20, speed;
    public Text agroText;
    public float Distance;

    public bool canDamage;
    void Start()
    {
        canDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isAgro);
        Distance = Vector2.Distance(player.transform.position, transform.position);
        var currentInfluence = this.GetComponent<Influence>().currentHealth;
        if (Distance < 5f &&  currentInfluence > 20)
        {
            isAgro = true;
        }
        else if(currentInfluence < 20)
        {
            canDamage = false;
            isAgro = false;
            canDamage = false;
        }
        Vector2 direction = player.transform.position - transform.position;

        if(isAgro)
        {
            agroText.enabled = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
        if(!isAgro)
        {
            agroText.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, GetRandomPoint(transform.position, 4f), speed * Time.deltaTime);
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && canDamage)
        {
            var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Damage(5);
        }
    }
    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        Vector2 randomPos = Random.insideUnitSphere * maxDistance + center;
        randomPos = new Vector2(randomPos.x, 0);
        return randomPos;
    }
}
