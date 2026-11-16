using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private bool collected;
    private CoinSpawner coinSpawner;

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
        coinSpawner.OnCoinCollected(this);
        Debug.Log("Coin collected!");
        Destroy(gameObject);
    }

    public void SetSpawner(CoinSpawner spawner)
    {
        coinSpawner = spawner;
    }
}
