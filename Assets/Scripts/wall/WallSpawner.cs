using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxActiveWalls = 3;
    [SerializeField] private float spawnX = -2f;
    [SerializeField] private float spawnY = 1f;
    [SerializeField] private float[] laneZ = { 0f, 3f, 6f, 9f, 12f };

    private float elapsed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wallPrefab == null || laneZ.Length == 0 || spawnInterval <= 0f)
        {
            return;
        }

        elapsed += Time.deltaTime;

        if (elapsed >= spawnInterval)
        {
            elapsed -= spawnInterval;
            if (FindObjectsByType<MovingWall>(FindObjectsSortMode.None).Length >= maxActiveWalls) 
                return;

            int laneIndex = Mathf.Clamp(Mathf.RoundToInt(player.position.z / 3f), 0, laneZ.Length - 1);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, laneZ[laneIndex]);

            Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
