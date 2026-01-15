using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour


{

    public AudioMixer patata;

    public void SetMusicVolume(float volume)
    {
        patata.SetFloat("MusicVolume", volume);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
