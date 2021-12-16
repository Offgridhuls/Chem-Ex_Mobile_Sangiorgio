using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{ 

    public Transform target1,
        target2;

    private Vector3 targetPosition1,
        targetPosition2;

    private Vector3 targetPosition;

    public float speed = 2.0f;


     void Start()
     {
        targetPosition1 = target1.position;
        targetPosition2 = target2.position;
        targetPosition = targetPosition1;
     }
    void Update()
    {
        if (transform.position == targetPosition1)
        {
            targetPosition = targetPosition2;
        }
        else if(transform.position == targetPosition2)
        {
            targetPosition = targetPosition1;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform, true);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null; 
    }
}
