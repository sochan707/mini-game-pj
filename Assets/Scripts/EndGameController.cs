using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public static bool PlayerWon;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winSound;

    void Awake()
    {
        GameMusic.StopMusic();
        winPanel.SetActive(PlayerWon);
        losePanel.SetActive(!PlayerWon);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerWon)
            audioSource.PlayOneShot(winSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
