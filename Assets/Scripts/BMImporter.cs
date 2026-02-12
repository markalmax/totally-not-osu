using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BMImporter : MonoBehaviour
{
    public TextAsset OSUFile;
    public string[] OSULines = new string[0];
    public Dictionary<string, Dictionary<string, string>> metadata = new Dictionary<string, Dictionary<string, string>>();
    void Awake()
    {
        OSULines = OSUFile.text.Split('\n');
        string header = "";
        for(int i = 2; i < OSULines.Length; i++)
        {
            string line = OSULines[i].Trim();
            if(line.Contains("[") && line.Contains("]"))
            {
                header = line.Trim('[', ']');
                //Debug.Log(header);
                metadata.Add(header, new Dictionary<string, string>());
            }
            else if (line.Contains(":"))
            {
                string[] split = line.Split(':'); 
                metadata[header].Add(split[0].Trim(), split[1].Trim());
                //Debug.Log("[" + header + "]\n" + split[0].Trim() + " : " + split[1].Trim());
                if(split[0].Trim()=="SliderTickRate")break;
            }
        }
    }
    void Update()
    {
        
    }
    void PrintData()
    {
        foreach(var section in metadata)
        {
            Debug.Log(section.Key);
            foreach(var kvp in section.Value)
            {
                Debug.Log("[" + section.Key + "] " + kvp.Key + " :: " + kvp.Value);
            }
        }
    }
}
