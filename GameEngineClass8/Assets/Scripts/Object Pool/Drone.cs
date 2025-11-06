using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Drone : MonoBehaviour
{
    public IObjectPool<Drone> Pool { get; set; }
    public float _currentHealth;
    [SerializeField]
    private float maxHealth = 100.0f;

    [SerializeField]
    private float timeToSelfDestruct = 3.0f;
    void Start() // Sets health to maxhealth on start
    {
        _currentHealth = maxHealth;
    }
    void OnEnable() // When the drone activates, calls the Attack Player and Self Destruct functions
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }
    private void OnDisable() // When it dies/disables itself, calls the Reset Drone function
    {
        ResetDrone();
    }
    IEnumerator SelfDestruct() // After watiting a set amount of time, the drone takes max health
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        TakeDamage(maxHealth);
    }
    private void ReturnToPool() // Returns itself back to the pool
    {
        Pool.Release(this);
    }
    private void ResetDrone() // Resets health back to max health
    {
        _currentHealth = maxHealth;
    }
    public void AttackPlayer() // Attacks the player through Debug Log, could be replaced with enemy behavoir
    {
        Debug.Log("Attack player!");
    }
    public void TakeDamage(float amount) // Takes a set amount of damage. When it has 0 or less health, returns to pool
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0.0f)
            ReturnToPool();
    }
}

