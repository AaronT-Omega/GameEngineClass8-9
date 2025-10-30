using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Observer
{

    private Vector3 _initialPosition;

    private BikeController _bikeController;

    void OnEnable()
    {
        _initialPosition = gameObject.transform.localPosition;
    }

  

    public override void Notify(Subject subject) // Overides the Notify function
    {
        if (!_bikeController) // Gets the Bike if it isn't set up
        {
            _bikeController = subject.GetComponent<BikeController>();
        }

        
    }
}
