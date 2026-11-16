using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private CoinPickup coinPrefab;
    [SerializeField] private float heightAboveTile = 1f;
    [SerializeField] private TMPro.TMP_Text coinCountText;

    private CoinPickup currentCoin;
    private int collectedCount;
    private GameObject currentTile;

    private IEnumerator Start()
    {
        coinCountText.text = $"{collectedCount}/5";
        yield return null;
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        if (currentCoin != null)
            return;

        List<GameObject> tiles = platformManager.GetActivePlatforms();
        if (tiles.Count == 0)
            return;

        if (tiles.Count > 1)
            tiles.Remove(currentTile);
            
        GameObject tile = tiles[Random.Range(0, tiles.Count)];
        currentTile = tile;
        Vector3 position = tile.transform.position + Vector3.up * heightAboveTile;
        currentCoin = Instantiate(coinPrefab, position, Quaternion.identity);
        currentCoin.SetSpawner(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCoinCollected(CoinPickup coin)
    {
        if (coin != currentCoin)
            return;

        collectedCount++;
        coinCountText.text = $"{collectedCount}/5";
        currentCoin = null;

        if (collectedCount < 5)
            SpawnCoin();
    }
}
