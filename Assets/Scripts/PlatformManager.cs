using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    public int size = 5;
    public float spacing = 3f;
    public Color[] colors = { Color.red, Color.blue, Color.yellow, Color.green};
    [SerializeField] Material[] platformMaterials;
    GameObject[] platforms;
    Color[] platformColors;
    

    // Game UI
    public TMPro.TMP_Text label;
    public float roundTime = 5f;
    Color safe;
    float endTime;

    void Start()
    {
        NewRound();
    }

    void NewRound()
    {
        if (platforms != null)
        {
            foreach (var p in platforms) Destroy(p);
        }

        platforms = new GameObject[size * size];
        platformColors = new Color[size * size];
        for (int i = 0; i < platforms.Length; i++)
        {
            var p = GameObject.CreatePrimitive(PrimitiveType.Cube);
            p.transform.localScale = new Vector3(2.5f, 0.5f, 2.5f);
            p.transform.position = new Vector3(i % size * spacing, 0f, i / size * spacing);
            int colorIndex = Random.Range(0, colors.Length);
            platformColors[i] = colors[colorIndex];
            p.GetComponent<Renderer>().sharedMaterial = platformMaterials[colorIndex];
            platforms[i] = p;
        }

        safe = platformColors[Random.Range(0, platformColors.Length)];
        label.color = safe;
        endTime = Time.time + roundTime;
        Invoke(nameof(EndRound), roundTime);
    }

    public List<GameObject> GetActivePlatforms()
    {
        List<GameObject> active = new List<GameObject>();

        if (platforms == null)
            return active;

        foreach (GameObject platform in platforms)
        {
            if (platform != null && platform.activeInHierarchy)
                active.Add(platform);
        }

        return active;
    }

    void EndRound()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platformColors[i] != safe) platforms[i].SetActive(false);
        }
        label.text = "Platform Removed";
        Invoke(nameof(NewRound), 2f);
    }

    void Update()
    {
        if (Time.time < endTime)
        {
            label.text = "Stand on this color: " + Mathf.Ceil(endTime - Time.time);
        }
    }
}
