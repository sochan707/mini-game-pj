using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] public float jumpForce = 6f;
    Rigidbody rb;
    Vector3 move;
    bool jumpPressed;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Debug.Log("PlayerMove is awake!");
    }

    void Update()
    {
        var k = Keyboard.current;
        // Making the player stay if not pressed anything
        if (k == null)
        {
            move = Vector3.zero;
            return;
        }
        // Getting if the player jumpPressed
        if (k.spaceKey.wasPressedThisFrame)
        {
            jumpPressed = true;
        }
        // WASD movement
        move = new Vector3(
            (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0),
            0f,
            (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0)
        ).normalized;
    }

    void FixedUpdate()
    {
        Vector3 v = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);
        if (jumpPressed && Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            v.y = jumpForce;
        }
        jumpPressed = false;
        rb.linearVelocity = v;
    }
}