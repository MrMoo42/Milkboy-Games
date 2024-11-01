using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed = 4.0f;

    private void Start() {
       rb2d = gameObject.GetComponent<Rigidbody2D>();

        if (rb2d == null) {
            Debug.LogError("No 2D Rigidbody found on player.");
        }
    }

    private void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); //This makes it so that using more keys won't make movement faster.
    }

    private void FixedUpdate() {
        rb2d.velocity = moveInput * moveSpeed; //The actual movement of the player.
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;

        if (obj.tag == "Car" ) {
            SceneManager.LoadScene("Main");
        }
    }
}
