using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitDetect : MonoBehaviour
{
    public IObjectPool<HitDetect> Pool { get; set; }
    [SerializeField] private BikeController _bikeController;
    [SerializeField] private float speed = 20f;
    void OnEnable() // When the drone activates, calls the Attack Player and Self Destruct functions
    {
        
        StartCoroutine(SelfDestruct());
    }
    void Start()
    {
        _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
    }

    void Update()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_bikeController)
        {
            if (collision.gameObject.tag == "Player")
            {
                _bikeController.TakeDamage(15.0f);
               
                ReturnToPool();
            }
        }
    }
    private void ReturnToPool() // Returns itself back to the pool
    {
        Pool.Release(this);
    }
    IEnumerator SelfDestruct() // After watiting a set amount of time, the drone takes max health
    {
        yield return new WaitForSeconds(5);
        
        ReturnToPool();
    }



}
