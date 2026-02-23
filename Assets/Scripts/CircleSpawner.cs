using UnityEngine;
using System.Collections.Generic;

public class CircleSpawner : MonoBehaviour
{
    public BMImporter BM;
    public GameObject HitCircle;
    void Awake()
    {
        BM = GetComponent<BMImporter>();
    }
    void Start()
    {
        foreach(KeyValuePair<string, string> hitObject in BM.metadata["HitObjects"])
        {
            
        }
    }
}
