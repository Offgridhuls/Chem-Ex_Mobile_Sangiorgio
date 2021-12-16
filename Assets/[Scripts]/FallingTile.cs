using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Animator animator;

    public EdgeCollider2D collider;

    public Rigidbody2D rigidbody;

    public Vector2 savedPosition;

    public Quaternion savedrotation;

    // Start is called before the first frame update
    void Start()
    {
        savedrotation = gameObject.transform.rotation;
        savedPosition = gameObject.transform.position;
        gameObject.transform.position = savedPosition;
    }

    // Update is called once per fram
    IEnumerator ShakeAndFall()
    {
        animator.SetTrigger("PlayerStepped");
        yield return new WaitForSeconds(1.0f);
        collider.enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.position = savedPosition;
        collider.enabled = true;
        gameObject.transform.rotation = savedrotation;
        rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ShakeAndFall());
    }
}
