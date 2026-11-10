using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    Rigidbody rb;
    Vector3 move;
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
        if (k == null)
        {
            move = Vector3.zero;
            return;
        }
        move = new Vector3(
            (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0),
            0f,
            (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0)
        ).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);
    }
}