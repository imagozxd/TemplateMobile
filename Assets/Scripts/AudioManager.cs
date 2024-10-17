using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Lista de clips para asignar desde el editor
    [SerializeField] private AudioClip[] clips;

    // Eventos para reproducir sonidos
    public event Action<int, AudioSource, float> OnPlaySound;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Persistencia entre escenas
    }

    // Método para reproducir un sonido basado en el índice del clip
    public void PlaySound(int clipIndex, AudioSource audioSource, float volume = 1f)
    {
        if (clipIndex >= 0 && clipIndex < clips.Length)
        {
            OnPlaySound?.Invoke(clipIndex, audioSource, volume);  // Disparar evento si está suscrito
        }
        else
        {
            Debug.LogWarning($"El índice {clipIndex} está fuera de rango.");
        }
    }

    // Este método estará suscrito al evento para realizar la reproducción
    private void HandlePlaySound(int clipIndex, AudioSource audioSource, float volume)
    {
        audioSource.clip = clips[clipIndex];
        audioSource.volume = volume;
        audioSource.Play();
    }

    void OnEnable()
    {
        // Suscribir el método a los eventos
        OnPlaySound += HandlePlaySound;
    }

    void OnDisable()
    {
        // Desuscribir el método cuando este objeto se desactive
        OnPlaySound -= HandlePlaySound;
    }
}
