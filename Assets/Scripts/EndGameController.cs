using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public static bool PlayerWon;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    void Awake()
    {
        winPanel.SetActive(PlayerWon);
        losePanel.SetActive(!PlayerWon);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
