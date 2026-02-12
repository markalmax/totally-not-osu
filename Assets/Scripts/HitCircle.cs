using UnityEngine;

public class HitCircle : MonoBehaviour
{
    public float CS,OD,AR;
    public BMImporter BM;
    void Start()
    {
        BM=GetComponentInParent<BMImporter>();
        if(BM.metadata.ContainsKey("Difficulty"))
        {
            CS = float.Parse(BM.metadata["Difficulty"]["CircleSize"]);
            OD = float.Parse(BM.metadata["Difficulty"]["OverallDifficulty"]);
            AR = float.Parse(BM.metadata["Difficulty"]["ApproachRate"]);
            transform.localScale = Vector3.one * (54.4f - 4.48f * CS) * 1.00041f;
            Debug.Log(CS + " " + OD + " " + AR);
        }
        else
        {
            Debug.LogError("Difficulty section not found in OSU file metadata!");
        }
    }
}
