using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip soundEffect;
    public bool playOnceWhenClick = true;
    public bool playOnceWhenSceneAwake = false;

    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = gameObject.AddComponent<AudioSource>();
        if (playOnceWhenSceneAwake) {
            PlaySoundOnce();
        }
    }

    public void PlaySoundOnce() {
        audioSrc.PlayOneShot(soundEffect);
    }

    public void PlaySoundOnce(AudioClip soundEffect)
    {
        audioSrc.PlayOneShot(soundEffect);
    }

    public void PlaySoundLoop() {
        if (audioSrc.isPlaying) return;
        audioSrc.loop = true;
        audioSrc.clip = soundEffect;
        audioSrc.Play();
    }

    public void PlaySoundLoop(AudioClip soundEffect) {
        audioSrc.loop = true;
        audioSrc.clip = soundEffect;
        audioSrc.Play();
    }

    public void StopSound() {
        audioSrc.loop = false;
        audioSrc.Stop();
    }

    private void OnMouseDown()
    {
        if (playOnceWhenClick)
        {
            PlaySoundOnce();
        }
    }
}
