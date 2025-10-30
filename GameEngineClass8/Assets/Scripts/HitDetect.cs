using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : Observer
{

    private BikeController _bikeController;
    [SerializeField] private float speed;
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
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _bikeController.TakeDamage(15.0f);
            }
           
        }
    }


    public override void Notify(Subject subject) 
    {
        if (!_bikeController) 
        {
            _bikeController = subject.GetComponent<BikeController>();
        }
    }
}
