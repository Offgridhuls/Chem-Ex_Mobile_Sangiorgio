using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskFire : MonoBehaviour
{
    public GameObject flask;
    public float force;

    public Vector2 direction;

    public Vector2 shotDirectionVector;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Update()
    {
        if (PlayerController.instance.playerDirection.x > 0)
            direction.x = 1;
        else
            direction.x = -1;
    }
    public void FireFlask()
    {
        var newFlask = Instantiate(flask, PlayerController.instance.playerTransform.position, Quaternion.identity);
        var flaskBody = newFlask.GetComponent<Rigidbody2D>();
        if (direction.x > 0)
        {
            shotDirectionVector = Quaternion.AngleAxis(70, Vector3.forward) * direction;
        }
        else
        {
            shotDirectionVector = Quaternion.AngleAxis(-70, Vector3.forward) * direction;
        }

        flaskBody.AddTorque(-2, ForceMode2D.Impulse);
        flaskBody.AddForce(shotDirectionVector * force, ForceMode2D.Impulse);
    }
}
