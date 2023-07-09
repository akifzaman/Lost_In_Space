using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class UIManager : MonoBehaviour
	{
		public GameObject MainMenuPanel;
		public GameObject HudPanel;
		public GameObject GameOverPanel;

		public TextMeshProUGUI laserText;
		public TextMeshProUGUI scoreText;

		public void InitialGame()
		{
			MainMenuPanel.SetActive(true);
			HudPanel.SetActive(false);
			GameOverPanel.SetActive(false);

		}

		public void StartGame()
		{
			MainMenuPanel.SetActive(false);
			HudPanel.SetActive(true);
			GameOverPanel.SetActive(false);

			GameManager.instance.StartGame();
		}

		public void ExitGame()
		{
			GameManager.instance.ExitGame();
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
}
