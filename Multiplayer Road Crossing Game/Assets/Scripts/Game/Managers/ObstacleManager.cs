using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private static ObstacleManager _instance;
    public static ObstacleManager Instance { get { return _instance; } }
    [SerializeField]
    private GameObject Bus;
    private List<GameObject> busPool;

    [SerializeField] private Transform[] posArray;
    [SerializeField] private Transform parentObject;
    private int poolCount;
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(_instance);
        else
            _instance = this;
    }

    private void Start()
    {
        busPool = new List<GameObject>();
        poolCount = 20;
        CreateSetofObstacles();
        StartCoroutine(SetBusActive());
    }

    public IEnumerator SetBusActive()
    {
        yield return new WaitForSeconds(1f);
        GameObject spawnedBus = GetBusFromPool();

        if(spawnedBus == null)
        {
            spawnedBus = GetBusFromPool();
        }
        else
        {
            spawnedBus.SetActive(true); 
        }
        StartCoroutine(SetBusActive());
    }

   
 
    private GameObject GetBusFromPool() 
    {
        for (int i = 0; i < busPool.Count; i++)
        {
            if (!busPool[i].activeSelf)
            {
                return busPool[i];
            }
        }
        CreateSetofObstacles();
        return null;
    }

    private void CreateSetofObstacles()
    {
        for (int i = 0; i < poolCount; i++)
        {
            GameObject BusTmp = Instantiate(Bus, posArray[Random.Range(0, posArray.Length)].position, Quaternion.identity);
            BusTmp.transform.parent = parentObject;
            busPool.Add(BusTmp);
            BusTmp.SetActive(false);
            
        }
    }
}
