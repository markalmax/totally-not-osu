using UnityEngine;

public class HitCircle : MonoBehaviour
{
    public float CS,OD,AR;
    public BMImporter BM;
    void Start()
    {
        BM=GetComponentInParent<BMImporter>();
        Debug.Log(BM.metadata["CircleSize"] + " " + BM.metadata["OverallDifficulty"] + " " + BM.metadata["ApproachRate"]);
        CS = float.Parse(BM.metadata["CircleSize"]);
        OD = float.Parse(BM.metadata["OverallDifficulty"]);
        AR = float.Parse(BM.metadata["ApproachRate"]);
        transform.localScale = Vector3.one * (54.4f - 4.48f * CS) * 1.00041f;
        Debug.Log(CS + " " + OD + " " + AR);
    }
}
