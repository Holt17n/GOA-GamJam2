using UnityEngine;

public class Target : MonoBehaviour
{
	//giving the enemy health
	public int health = 100;
	public int currentHealth;
	public HealthBar healthBar;

	public Pooler_Handler poolReference;

	void Start()
    {
		currentHealth = health;
		healthBar.SetMaxHealth(health);
    }


	public void TakeDamage(int amount)
	{ 
		currentHealth -= amount;

		healthBar.SetHealth(currentHealth);

		//if health is too low it will "die"
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
    {
		//death = despawn
		//Destroy(gameObject);

		//Random position
		Vector3 pos = new Vector3(Random.Range(-25, 12), 0.5f, Random.Range(-10, 4));
		gameObject.transform.position = pos;
		Start();

		//Random rotation (eventually)
		//Quaternion rot = new Quaternion();
		//rot.Set(0, Random.Range(0, 89), 0, 1);

		//poolReference.SpawnFromPool(pos);

	}
}