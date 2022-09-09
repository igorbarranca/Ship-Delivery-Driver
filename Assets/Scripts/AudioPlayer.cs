using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Ship Sounds")]
    [SerializeField] AudioClip[] turningSounds;
    [SerializeField] [Range(0f, 1f)] float turningVolume = .5f;

    [SerializeField] AudioClip crashSound;
    [SerializeField] [Range(0f, 1f)] float crashVolume = .5f;

    [Header("Package Interactions")]
    [SerializeField] AudioClip packagePickedSound;
    [SerializeField] [Range(0f, 1f)] float packagePickedVolume = .5f;

    [SerializeField] AudioClip packageDeliveredSound;
    [SerializeField] [Range(0f, 1f)] float packageDeliveredVolume = .5f;

    [Header("Main Menu")]
    [SerializeField] AudioClip startGameSound;
    [SerializeField] [Range(0f, 1f)] float startGameVolume = .5f;

    [SerializeField] AudioClip creditsSound;
    [SerializeField] [Range(0f, 1f)] float creditsVolume = .5f;

    public static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }

    public void PlayTurningClip()
    {
        int randomIndex = Random.Range(0, turningSounds.Length);
        AudioClip turningClip = turningSounds[randomIndex];

        PlayClip(turningClip, turningVolume);
    }

    public void PlayCrashClip()
    {
        PlayClip(crashSound, crashVolume);
    }

    public void PlayPackagePickedClip()
    {
        PlayClip(packagePickedSound, packagePickedVolume);
    }
    public void PlayPackageDeliveredClip()
    {
        PlayClip(packageDeliveredSound, packageDeliveredVolume);
    }

    public void PlayStartGameClip()
    {
        PlayClip(startGameSound, startGameVolume);
    }
    public void PlayCreditsSound()
    {
        PlayClip(creditsSound, creditsVolume);
    }
    
    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector2 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
