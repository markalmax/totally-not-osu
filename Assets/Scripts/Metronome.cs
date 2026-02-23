using UnityEngine;

public class Metronome : MonoBehaviour
{
    public BMImporter BM;
    public AudioSource musicPlayer;
    public AudioSource sfx;
    public float beatDurationMS;
    public float nextBeatTimeMS;
    public float musicPositionMS;
    void Start()
    {
        BM = FindAnyObjectByType<BMImporter>();
        //musicPlayer = GetComponentInParent<AudioSource>();
        sfx = GetComponent<AudioSource>();
        beatDurationMS = float.Parse(BM.metadata["TimingPoints"]["beatLength1"]);
        nextBeatTimeMS = beatDurationMS;
    }
    
    void Update()
    {
        //if (!musicPlayer.isPlaying) return;
        musicPositionMS = musicPlayer.time * 1000f;
        if (musicPositionMS >= nextBeatTimeMS)
        {
            Debug.Log("Beat at " + musicPositionMS + "ms");
            sfx.Play();
            nextBeatTimeMS += beatDurationMS;
        }
    }
}