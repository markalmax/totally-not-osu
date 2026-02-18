using System.Collections.Generic;
using System.IO;
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
        string header = ""; float cntr = 1;
        for(int i = 2; i < OSULines.Length; i++)
        {
            string line = OSULines[i].Trim();
            if(line == "") continue;
            if(line.Contains("[") && line.Contains("]"))
            {
                header = line.Trim('[', ']');
                Debug.Log(header);
                metadata.Add(header, new Dictionary<string, string>());
                cntr = 1;
            }
            else if (line.Contains(":")&& header != "HitObjects")
            {
                string[] split = line.Split(':'); 
                metadata[header].Add(split[0].Trim(), split[1].Trim());
                Debug.Log("[" + header + "]\n" + split[0].Trim() + " : " + split[1].Trim());
                //if(split[0].Trim()=="SliderTickRate")break;
            }
            else
            {
                string[] split = line.Split(',');
                if(header == "TimingPoints")
                {
                    string[] TimingPointStructure={"time","beatLength","meter","sampleSet","sampleIndex","volume","uninherited","effects"};
                    for(int j = 0; j < split.Length; j++){
                        Debug.Log("[" + header + "]\n" + TimingPointStructure[j].Trim()+cntr + " : " + split[j].Trim());
                        metadata[header].Add(TimingPointStructure[j].Trim()+cntr, split[j].Trim());
                    }
                    cntr++;
                }
                if(header == "HitObjects")
                {
                    string[] HitObjectsStructure={"x","y","time","type","hitSound"};
                    for(int j = 0; j < HitObjectsStructure.Length; j++){
                        Debug.Log("[" + header + "]\n" + HitObjectsStructure[j].Trim() +cntr + " : " + split[j].Trim());
                        metadata[header].Add(HitObjectsStructure[j].Trim()+cntr, split[j].Trim());
                    }
                    cntr++;
                }
            }
        }
        //PrintData();
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
