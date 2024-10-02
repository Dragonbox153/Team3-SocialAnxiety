using System.Collections;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    PlayerMovements player;

    public AudioSource audioSource1; 
    public AudioSource audioSource2; 

    public float fadeDuration = 1.0f; // Duration of the fade effect
    
    // Initial and pressure up volume for audio source 1
    public float audio1StartVolume = 1.0f;
    public float audio1PressureUpVolume = 0.0f;

    // Initial and pressure up volume for audio source 2
    public float audio2StartVolume = 6f;
    public float audio2PressureUpVolume = 15f;

    private bool isFading = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
        PlayBothSounds();
    }

    void Update()
    {

        if (player.stressLevel >= 50 && !isFading)
        {
            StartCoroutine(FadeSounds());
        }
    }

    // Play both sounds and set the initial volume
    void PlayBothSounds()
    {
        audioSource1.Play();
        audioSource2.Play();

        // Set the initial volume levels
        audioSource1.volume = audio1StartVolume;
        audioSource2.volume = audio2StartVolume;
    }

    // Coroutine to fade the volume of both sounds
    IEnumerator FadeSounds()
    {
        isFading = true;
        float elapsedTime = 0.0f;

        // Get the current volume levels
        float startVolume1 = audioSource1.volume;
        float startVolume2 = audioSource2.volume;

        while (elapsedTime < fadeDuration)
        {
            // Lerp the volume levels over time
            audioSource1.volume = Mathf.Lerp(startVolume1, audio1PressureUpVolume, elapsedTime / fadeDuration);
            audioSource2.volume = Mathf.Lerp(startVolume2, audio2PressureUpVolume, elapsedTime / fadeDuration);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final volume is set to the target levels
        audioSource1.volume = audio1PressureUpVolume;
        audioSource2.volume = audio2PressureUpVolume;
        isFading = false;
    }
}
