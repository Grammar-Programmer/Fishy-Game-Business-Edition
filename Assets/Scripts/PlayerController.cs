using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, DataPeristence
{

    // Adjust position of Player, because it fixing the pivots in sprite wasn't working
    private static float ADJUST_VALUE = 0.6784f;
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Vector2 velocity;

    public Animator anim;
    private bool isFacedLeft;

    // Update is called once per frame
    void Update()
    {
        // Player Movement
        theRB.velocity = new Vector2(velocity.x * moveSpeed, velocity.y * moveSpeed);

        // Setting Params to animate Player
        anim.SetFloat("yVelocity", theRB.velocity.y);
        anim.SetBool("isStopped", theRB.velocity.x == 0 && theRB.velocity.y == 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>();

        // Flipping the Player only when the x Axis changes
        float adjust = 0;
        if (velocity.x < 0 && !isFacedLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            adjust = -ADJUST_VALUE;
            isFacedLeft = !isFacedLeft;
        }
        else if (velocity.x > 0 && isFacedLeft)
        {
            transform.localScale = Vector3.one;
            adjust = ADJUST_VALUE;
            isFacedLeft = !isFacedLeft;
        }

        // Make adjustment to fix animations
        transform.localPosition = new Vector3(transform.localPosition.x + adjust, transform.localPosition.y, 0);
    }

    public void loadData(GameData data)
    {
        transform.position=data.playerPosition;
    }

    public void saveData(ref GameData data)
    {
        data.playerPosition=transform.position;
    }
}
