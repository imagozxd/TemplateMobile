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

    // M�todo para reproducir un sonido basado en el �ndice del clip
    public void PlaySound(int clipIndex, AudioSource audioSource, float volume = 1f)
    {
        if (clipIndex >= 0 && clipIndex < clips.Length)
        {
            OnPlaySound?.Invoke(clipIndex, audioSource, volume);  // Disparar evento si est� suscrito
        }
        else
        {
            Debug.LogWarning($"El �ndice {clipIndex} est� fuera de rango.");
        }
    }

    // Este m�todo estar� suscrito al evento para realizar la reproducci�n
    private void HandlePlaySound(int clipIndex, AudioSource audioSource, float volume)
    {
        audioSource.clip = clips[clipIndex];
        audioSource.volume = volume;
        audioSource.Play();
    }

    void OnEnable()
    {
        // Suscribir el m�todo a los eventos
        OnPlaySound += HandlePlaySound;
    }

    void OnDisable()
    {
        // Desuscribir el m�todo cuando este objeto se desactive
        OnPlaySound -= HandlePlaySound;
    }
}
