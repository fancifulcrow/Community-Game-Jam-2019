using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

	public class PlayerHealth : MonoBehaviour
	{
		public int startingPlayerHealth = 100;                            // The amount of health the player starts the game with.
		public int currentPlayerHealth;                                   // The current health the player has.
		public Slider healthSlider;                                 // Reference to the UI's health bar.
		public Image fillImage;
		public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
		public Color m_ZeroHealthColor = Color.red;        // The color the health bar will be when on no health.
		public GameObject gameOverMenu;

		void Start ()
		{
			// Set the initial health of the player.
			currentPlayerHealth = startingPlayerHealth;

			// Set the health bar's value to the current health.
			healthSlider.value = currentPlayerHealth;

			// Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
			fillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, currentPlayerHealth / startingPlayerHealth);
		}

		public void TakeDamage (int amount)
		{
			// Reduce the current health by the damage amount.
			currentPlayerHealth -= amount;

			// Set the health bar's value to the current health.
			healthSlider.value = currentPlayerHealth;
			
			// Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
			fillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, currentPlayerHealth / startingPlayerHealth);
			
			// If the player has lost all it's health and the death flag hasn't been set yet...
			if(currentPlayerHealth <= 0)
			{
				// ... it should die.
				Death ();
			}
		}


		void Death ()
		{
			gameObject.SetActive(false);
			gameOverMenu.SetActive (true);
		}
	}