using System.Collections;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private float timer;
    private float interval = 15f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomAudio());
    }

    private IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

            // Pick a random audio clip
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];

            // Play the selected audio clip
            audioSource.clip = randomClip;
            audioSource.Play();

            // Reset the timer
            timer = 0f;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to play a new audio clip
        if (timer >= interval)
        {
            // Trigger the coroutine to play a random audio clip
            StartCoroutine(PlayRandomAudio());
        }
    }
}
