using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTurnState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;
    private Vector3 _turnDirection;

    public void Handle(BikeController bikeController)
    {
        if (!_bikeController)
        {
            _bikeController = bikeController;
        }

        _turnDirection.x = (float)_bikeController.CurrentTurnDirection;

        if (_bikeController)
        {
            transform.Translate(_turnDirection * _bikeController.turnDistance);
        }

    }
}
