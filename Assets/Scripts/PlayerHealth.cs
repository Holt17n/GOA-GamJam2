using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
	public int health = 100;
	public int currentHealth;

	public HealthBar healthBar;

	private void Awake()
    {
		singleton = this;
    }

	void Start()
	{
		currentHealth = health;
		healthBar.SetMaxHealth(health);
	}

	public void DamagePlayer(int damage)
    {
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		//Debug.Log("Current Health")

		if (currentHealth <= 0)
			Die();
    }

	void Die()
    {
		Destroy(this);
		PlayerManager.instance.changePlayerStatus(false);
    }
}
