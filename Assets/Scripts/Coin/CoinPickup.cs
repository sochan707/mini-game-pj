using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

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
        PlayCollectSound();
        coinSpawner.OnCoinCollected(this);
        Debug.Log("Coin collected!");
        Destroy(gameObject);
    }

    private void PlayCollectSound()
    {
        if (collectSound == null)
            return;

        GameObject soundObject = new GameObject("Coin Collect Sound");
        soundObject.transform.position = transform.position;

        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = collectSound;
        audioSource.spatialBlend = 0f;

        DontDestroyOnLoad(soundObject);
        audioSource.Play();
        Destroy(soundObject, collectSound.length);
    }

    public void SetSpawner(CoinSpawner spawner)
    {
        coinSpawner = spawner;
    }
}
