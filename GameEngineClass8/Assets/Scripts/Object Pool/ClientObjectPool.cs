using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ClientObjectPool : MonoBehaviour
{
    private EnemyObjectPool _pool;
    private float _timer = 0f;
    void Start() // Creates the Drone Pool
    {
      

        _pool = gameObject.AddComponent<EnemyObjectPool>();

        

    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 3)
        {
            _timer = 0f;
            _pool.Spawn();
        }
    }
   
}
