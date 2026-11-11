using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] public float jumpForce = 6f;
    [SerializeField] public float jumpCooldown = 2.0f;
    [SerializeField] public float dashSpeed = 12f;
    [SerializeField] public float dashTime = 0.15f;
    [SerializeField] public float dashCooldown = 5f;
    Rigidbody rb;
    Vector3 move;
    bool jumpPressed;
    float dashEnd, nextDash;
    Vector3 dashDirection;
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
        // Game Voer (Switching scene)
        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene("MainMenu");
        }
        // Making the player stay if not pressed anything
        if (k == null)
        {
            move = Vector3.zero;
            return;
        }
        // Getting Dash
        if (k.leftShiftKey.wasPressedThisFrame && Time.time >= nextDash)
        {
            dashDirection = move != Vector3.zero ? move : transform.forward;
            dashEnd = Time.time + dashTime;
            nextDash = Time.time + dashCooldown;
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
        if (Time.time < dashEnd)
        {
            v = new Vector3(dashDirection.x * dashSpeed, 0f, dashDirection.z * dashSpeed);
        }
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
        if (jumpPressed && Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            v.y = jumpForce;
        }
        jumpPressed = false;
        rb.linearVelocity = v;
    }
}