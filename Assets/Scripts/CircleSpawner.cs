using UnityEngine;
using System.Collections.Generic;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circle;
    public BMImporter BM;
    public GameObject HitCircle;
    void Awake()
    {
        BM = GetComponent<BMImporter>();
    }
    void Start()
    {
        
    }
}
