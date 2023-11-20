using UnityEngine;

public class CarreteraAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reproducir audio solo si no está sonando
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("Audio Reproducido");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Detener audio
            audioSource.Stop();
            Debug.Log("Audio Detenido");
        }
    }

}
