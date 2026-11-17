using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private Transform visual;
    [SerializeField] private float bobHeight = 0.15f;
    [SerializeField] private float bobSpeed = 2f;
    [SerializeField] private float spinSpeed = 90f;

    private Vector3 startingLocalPosition;

    void Awake()
    {
        startingLocalPosition = visual.localPosition;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        visual.localPosition = startingLocalPosition + Vector3.up * offset;
        visual.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
