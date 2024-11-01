using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vroom : MonoBehaviour
{
    public bool isRight = true; //Is the car moving from left -> right
    private SpriteRenderer sprite;
    private Rigidbody2D rb2d;
    public float moveSpeed = 7.0f;

    private void Awake() {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (isRight) {
            sprite.flipY = true;
            sprite.flipX = true;
        }
    }

    private void Update() {
        if (isRight) {
            rb2d.velocity = new Vector2(100 * moveSpeed, 0) * Time.deltaTime;
            if (this.transform.position.x >= 14) {
                Destroy(gameObject);
            }
        } else {
            rb2d.velocity = new Vector2(-100 * moveSpeed, 0) * Time.deltaTime;
            if (this.transform.position.x <= -14) {
                Destroy(gameObject);
            }
        }
    }
}
