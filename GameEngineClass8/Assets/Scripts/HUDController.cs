using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Observer
{
    private bool _isTurboOn;
    private float _currentFuel;
    private BikeController _bikeController;

    private void OnGUI() // Sets up GUI
    {
        GUILayout.BeginArea(new Rect(50, 200, 100, 200));

        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Health: " + _currentFuel);
        GUILayout.EndHorizontal();

        if (_isTurboOn)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Turbo Activated!");
            GUILayout.EndHorizontal();
        }

        if (_currentFuel <= 50.0f)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("WARNING: Low Health");
            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }

    public override void Notify(Subject subject) // Overides the Notify function
    {
        if (!_bikeController) // Gets the Bike if it isn't set up
        {
            _bikeController = subject.GetComponent<BikeController>();
        }

        if (_bikeController) // When the Bike is set up, grabs the Turbo State and Health from the Bike Controller
        {
            _currentFuel = _bikeController.CurrentFuel;
        }
    }
}
