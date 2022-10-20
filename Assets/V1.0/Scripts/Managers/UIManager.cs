using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenuPanel; 
    public GameObject HudPanel; 
    public GameObject GameOverPanel;

    public Slider PlayerHealthBarSlider;
    public Slider EnemyBossHealthBarSlider;

    public void InitialGame()
    {
        MainMenuPanel.SetActive(true);
        HudPanel.SetActive(false);
        GameOverPanel.SetActive(false);

        PlayerHealthBarSlider.gameObject.SetActive(false);
        EnemyBossHealthBarSlider.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        HudPanel.SetActive(true);
        GameOverPanel.SetActive(false);

        PlayerHealthBarSlider.gameObject.SetActive(true);
        EnemyBossHealthBarSlider.gameObject.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        MainMenuPanel.SetActive(false);
        HudPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

}
