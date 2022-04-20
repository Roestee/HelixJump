using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ringsType;

    [SerializeField]
    private GameObject cylinder;

    private GameManager gameManager;

    private int[] levels;
    private int currentRingCount;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        Levels();

        for (int i = 0; i < currentRingCount + 1; i++)
        {
            if(i == currentRingCount)
            {
                var currentRing = Instantiate(ringsType[6], Vector3.up * (-3 * i + 12), Quaternion.identity);
                currentRing.transform.SetParent(cylinder.transform);
            }
            else
            {
                GameObject ring = ringsType[Random.Range(0, ringsType.Length - 1)];
                GameObject currentRing = Instantiate(ring, Vector3.up * (-3 * i), Quaternion.Euler(0, Random.Range(0, 360), 0));
                currentRing.transform.SetParent(cylinder.transform);
            }
        }
    }

    private void Levels() 
    {
        currentRingCount = gameManager.RingCount;
    }

}
