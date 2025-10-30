using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : Subject
{
    public float turnDistance = 3.0f;

    public Direction CurrentTurnDirection{ get; private set; }
    private IBikeState _startState, _stopState, _turnState;

    private bool _isEngineOn;
    private BikeStateContext _bikeStateContext;
    private HUDController _hudController;
    private CameraController _cameraController;
    [SerializeField] private float fuel = 100.0f;



    public float CurrentFuel
    {
        get { return fuel; }
    }

    private void Awake()
    {
        _hudController = gameObject.AddComponent<HUDController>();
        _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));
    }
    private void Start()
    {
        StartEngine();
        _bikeStateContext = new BikeStateContext(this);

        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();

        _bikeStateContext.Transition(_stopState);
    }


    void OnEnable() // Attaches observers when enabled
    {
        if (_hudController)
            Attach(_hudController);
        if (_cameraController)
            Attach(_cameraController);
    }
    void OnDisable() // Detaches observers when disabled
    {
        if (_hudController)
            Detach(_hudController);
        if (_cameraController)
            Detach(_cameraController);
    }
    public void StartBike()
    {
        _bikeStateContext.Transition(_startState);
    }

    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);
    }
    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _bikeStateContext.Transition(_turnState);
    }


    private void StartEngine() // Notifies all observers about the state change
    {
        _isEngineOn = true;
        NotifyObservers();
    }

    public void TakeDamage(float amount) // Decreases health by amount, turns off Turbo, notifies observers, and destroys game object if health is 0
    {
        fuel -= amount;
        NotifyObservers();
        if (fuel < 0)
            Destroy(gameObject);
    }
}
