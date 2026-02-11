using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BMImporter : MonoBehaviour
{
    public TextAsset OSUFile;
    public string[] OSULines = new string[0];
    public Dictionary<string, string> metadata = new Dictionary<string, string>();
    void Awake()
    {
        OSULines = OSUFile.text.Split('\n');
        for(int i = 0; i < OSULines.Length; i++)
        {
            if (OSULines[i].Contains(":"))
            {
                string[] split = OSULines[i].Split(':');
                metadata.Add(split[0].Trim(), split[1].Trim());
                if(split[0].Trim()=="SliderTickRate")break;
            }
        }
        //Debug.Log(metadata["Title"] + " " + metadata["Artist"] + " " + metadata["Creator"] + " " + metadata["Version"]);
        //Debug.Log(metadata["CircleSize"] + " " + metadata["OverallDifficulty"] + " " + metadata["ApproachRate"]);
    }
    void Update()
    {
        
    }
}
