using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameMusic : MonoBehaviour
{
    private static GameMusic instance;

    [SerializeField] private AudioClip musicClip;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        AudioSource source = GetComponent<AudioSource>();
        source.clip = musicClip;
        source.playOnAwake = false;
        source.loop = true;
        source.spatialBlend = 0f;

        if (musicClip == null)
        {
            Debug.LogError("GameMusic has no music clip assigned.", this);
            return;
        }

        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
