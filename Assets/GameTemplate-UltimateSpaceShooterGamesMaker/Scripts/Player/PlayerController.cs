using System.Collections;
using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class PlayerController : MonoBehaviour
	{
		public Player player;

		public GameObject superSplash;
		public GameObject glowShield;
		public GameObject ExplosionAnimation;

		public AudioClip powerUpSound;
		public AudioClip bulletSound;
		public AudioClip playerHitSound;
		public AudioClip playerExplosionSound;

		private float xBoundary = 2.40f;
		private float yBoundaryUp = 4.78f;
		private float yBoundaryDown = -4.60f;
		private float mouseSensitivity = 5f;

		public HealthBar PlayerHealthBar;

		public Shooting shooting;
		private AudioSource playerAudio;

		[SerializeField] private BulletProperties bulletProperties;
		public BulletProperties SinglebulletProperties;
		public BulletProperties DoublebulletProperties;

		private void Start()
		{
			shooting = GetComponent<Shooting>();
			playerAudio = GetComponent<AudioSource>();
			bulletProperties = new BulletProperties();
			PlayerHealthBar.gameObject.SetActive(false);
		}

		public void StartGame()
		{
			SetSlider();
			StartCoroutine(SetBulletProperties(SinglebulletProperties));
		}

		private void SetSlider()
		{
			PlayerHealthBar.gameObject.SetActive(true);
			PlayerHealthBar.Initialize(player.health);
			PlayerHealthBar.OnMaximumValue.AddListener(OnDestroyPlayer);
		}

		private void OnDestroyPlayer()
		{
			GameObject explosion = Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(playerExplosionSound, Camera.main.transform.position, 1.0f);
			Destroy(explosion, 0.5f);
			Destroy(gameObject);
			GameManager.instance.isGameActive = false;
			GameManager.instance.GameOver();
		}

		public void UpdateSlider(float damageAmount) => PlayerHealthBar.UpdateSlider(damageAmount);
		public void ActivateShield() => glowShield.SetActive(true);

		public IEnumerator SetBulletProperties(BulletProperties bulletProp)
		{
			yield return new WaitForSeconds(0.5f);
			bulletProperties = bulletProp;
			shooting.Initialize(bulletProperties);
			shooting.CanShoot = true;
			StartCoroutine(shooting.Fire(bulletProperties));
		}

		public void SetDoubleBullet()
		{
			StartCoroutine(SetBulletProperties(DoublebulletProperties));
		}

		private void Update()
		{
			if (!GameManager.instance.isGameActive) return;
			StayInBound();
			
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			// Mouse movement
			Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;

			// Touch movement
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				mouseDelta = touch.deltaPosition;
				transform.Translate(mouseDelta  / player.speed * Time.deltaTime);
			}
			else
			{
				// Calculate the movement direction
				Vector2 movement = new Vector2(moveHorizontal, moveVertical) + mouseDelta;

				// Apply movement using Transform.Translate
				transform.Translate(movement * player.speed * Time.deltaTime);
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				SuperSplashActivated();
			}
		}

		public void SuperSplashActivated()
		{
			if (player.superSplashCounter > 0)
			{
				player.superSplashCounter--;
				GameManager.instance.UiManager.laserText.SetText("Laser: " + player.superSplashCounter);
				Instantiate(superSplash, superSplash.transform.position, superSplash.transform.rotation);
			}
		}

		private void StayInBound()
		{
			if (transform.position.x <= -xBoundary)
			{
				transform.position = new Vector2(-xBoundary, transform.position.y);
			}

			if (transform.position.x >= xBoundary)
			{
				transform.position = new Vector2(xBoundary, transform.position.y);
			}

			if (transform.position.y <= yBoundaryDown)
			{
				transform.position = new Vector2(transform.position.x, yBoundaryDown);
			}

			if (transform.position.y >= yBoundaryUp)
			{
				transform.position = new Vector2(transform.position.x, yBoundaryUp);
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("MiniBossBullet"))
			{
				UpdateSlider(1.0f);
				other.gameObject.SetActive(false);
				AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, 1.0f);
			}
			else if (other.gameObject.CompareTag("EnemyLaser"))
			{
				UpdateSlider(10.0f);
			}
		}
	}
}