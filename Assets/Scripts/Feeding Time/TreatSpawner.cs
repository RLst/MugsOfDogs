using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatSpawner : MonoBehaviour
{
    public GameObject treat_Prefab;

    public void SpawnTreat()
    {
        GameObject treat_Obj = Instantiate(treat_Prefab);
        treat_Obj.transform.position = transform.position;
    }
}