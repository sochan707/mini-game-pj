using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float despawnX = 20f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 nextPosition = rb.position + Vector3.right * speed * Time.fixedDeltaTime;

        rb.MovePosition(nextPosition);

        if (nextPosition.x >= despawnX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            EndGameController.PlayerWon = false;
            SceneManager.LoadScene("EndGame");
            return;
        }
    }
}
