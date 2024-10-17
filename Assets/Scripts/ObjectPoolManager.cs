using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public PoolObject prefab;
        public int size;
    }

    public Pool[] pools;  // Arreglo para los diferentes tipos de pools
    private Queue<PoolObject>[] poolQueues;  // Arreglo de colas para almacenar objetos de cada pool

    void Start()
    {
        poolQueues = new Queue<PoolObject>[pools.Length];  // Inicializamos el arreglo de colas

        for (int i = 0; i < pools.Length; i++)
        {
            poolQueues[i] = new Queue<PoolObject>();

            // Crear los objetos para cada pool y añadirlos a la cola
            for (int j = 0; j < pools[i].size; j++)
            {
                PoolObject newObject = Instantiate(pools[i].prefab);
                newObject.gameObject.SetActive(false);
                poolQueues[i].Enqueue(newObject);  // Añadimos al pool
            }
        }
    }

    // Método para obtener un objeto del pool
    public PoolObject GetFromPool(string tag)
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].tag == tag)
            {
                PoolObject objectToSpawn = poolQueues[i].Dequeue();
                objectToSpawn.OnActivate();  // Cambiamos a OnActivate()
                poolQueues[i].Enqueue(objectToSpawn);  // Devolverlo al final de la cola

                return objectToSpawn;
            }
        }

        Debug.LogWarning($"No pool found with tag {tag}");
        return null;
    }
}


//implementacion de un pool de manzanas heredando de PoolObject
//public class Apple : PoolObject
//{
//    // Puedes agregar propiedades específicas de la manzana aquí

//    // Puedes sobrescribir OnActivate si necesitas lógica especial al activar
//    public override void OnActivate()
//    {
//        base.OnActivate();
//        // Lógica adicional cuando se activa la manzana
//        Debug.Log("Manzana activada!");
//    }

//    // Puedes sobrescribir ResetObject si es necesario
//    public override void ResetObject()
//    {
//        base.ResetObject();
//        // Lógica para resetear la manzana
//        Debug.Log("Manzana reseteada!");
//    }
//}



//Obtener manzanas desde el pool, para un spawner(?

//using UnityEngine;

//public class AppleSpawner : MonoBehaviour
//{
//    public ObjectPoolManager poolManager;  // Referencia al ObjectPoolManager

//    void Start()
//    {
//        // Obtener una referencia al ObjectPoolManager si no está configurado manualmente
//        if (poolManager == null)
//        {
//            poolManager = FindObjectOfType<ObjectPoolManager>();
//        }

//        // Spawn de una manzana
//        SpawnApple();
//    }

//    void SpawnApple()
//    {
//        // Obtener una manzana del pool usando el tag "Apple"
//        PoolObject apple = poolManager.GetFromPool("Apple");

//        if (apple != null)
//        {
//            // Establecer la posición de la manzana en el mundo
//            apple.transform.position = new Vector3(0, 1, 0);
//        }
//        else
//        {
//            Debug.LogWarning("No se pudo obtener una manzana del pool");
//        }
//    }
//}
