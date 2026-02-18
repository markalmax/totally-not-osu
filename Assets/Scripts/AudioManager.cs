using UnityEngine;

public class AudioManager : MonoBehaviour
{
public AudioSource Music;
void Start() {
    Music = GetComponent<AudioSource>();
    Music.Play();
    }
    void Update()
    {
        
    }
}
