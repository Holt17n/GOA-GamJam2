using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler_Handler : MonoBehaviour
{
    //Class for the variables of the pool
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //Object pool list
    public List<Pool> pool;

    //Overall Queue of objects
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        //For each pool in the list, assign a non-active gameObject with its prefeb
        //and add it to the Queue
        foreach(Pool p in pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < p.size; i++)
            {
                GameObject obj = Instantiate(p.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(p.tag, objectPool);
        }
    }

    //Function to spawn a new enemy
    public void SpawnFromPool(Vector3 position)
    {
        GameObject objToSpawn = poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        //objToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objToSpawn);
    }
}
