using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;

    
    public GameObject hitObject;
 
    public IObjectPool<HitDetect> Pool // Creates the object pool for enemyCars. If null then it makes the pool
    {
        get
        {
            if (_pool == null)
            {
                
                _pool =
                new ObjectPool<HitDetect>(CreatedPooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, stackDefaultCapacity, maxPoolSize);
            }
            return _pool;
        }
    }
    private IObjectPool<HitDetect> _pool;
    private HitDetect CreatedPooledItem() // Creates the enemyCars and add them to the list
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        go.AddComponent<Rigidbody>();

        HitDetect enemyCar;
        enemyCar = go.AddComponent<HitDetect>();
        go.name = "Bad Car";
        enemyCar.Pool = Pool;
        return enemyCar;
        
    }
    private void OnReturnedToPool(HitDetect enemyCar) // Disables them when returned to the pool
    {
        enemyCar.gameObject.SetActive(false);
    }
    private void OnTakeFromPool(HitDetect enemyCar) // Activates them when returned to the pool
    {
        enemyCar.gameObject.SetActive(true);
    }
    private void OnDestroyPoolObject(HitDetect enemyCar) //Destroys them when no more space in the pool
    {
        Destroy(enemyCar.gameObject);
    }
    public void Spawn() // Spawn function for the enemyCars randomly
    {
        
        float[] numbers = { 0f, 3f, -3f };
        int index = Random.Range(0, numbers.Length);
        float picked = numbers[index];

        var enemyCar = Pool.Get();
        enemyCar.transform.position = new Vector3(picked, 0, 20);
        
    }
}

