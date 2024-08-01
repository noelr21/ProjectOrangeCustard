using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField][Range(3f, 30f)] float movementSpeed = 5.0f;
    [SerializeField][Range(0f, 0.75f)] float drag = 0.5f;
    [SerializeField][Range(0f, 1f)] float strongDrag = 0.75f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Take input
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Normalize Direction
        movementDirection = movementDirection.normalized;
    }

    private void FixedUpdate()
    {
        float xInput = movementDirection.x;
        float yInput = movementDirection.y;
        bool isMoveInput = false;
        if (Mathf.Abs(xInput) > 0 || Mathf.Abs(yInput) > 0)
        {
            isMoveInput = true;
        }
        rb.velocity = new Vector2(xInput * movementSpeed, yInput * movementSpeed);
        //Depending on whether an movement key is being pressed modify the drag of the player. This is to slow the player faster when the stop moving
        if (isMoveInput) {
            rb.velocity -= (drag * rb.velocity);
        } else {
            rb.velocity -= (strongDrag * rb.velocity);
        }
    }
}
