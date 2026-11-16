using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private bool collected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected || other.GetComponent<PlayerMovement>() == null)
            return;

        collected = true;
        Debug.Log("Coin collected!");
        Destroy(gameObject);
    }
}
