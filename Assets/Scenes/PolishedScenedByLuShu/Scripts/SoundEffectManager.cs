using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip soundEffect;
    public bool playOnceWhenClick = true;
    public bool playOnceWhenSceneAwake = false;
    public bool playLoopWhenSceneAwake = false;

    private AudioSource audioSrc;

    private void Awake()
    {

        audioSrc = gameObject.AddComponent<AudioSource>();
        audioSrc.playOnAwake = false;
        if (playOnceWhenSceneAwake) {
            PlaySoundOnce();
        }
        if (playLoopWhenSceneAwake) {
            PlaySoundLoop();
        }
    }

    public void PlaySoundOnce() {
        audioSrc.loop = false;
        audioSrc.volume = 1f;
        audioSrc.clip = soundEffect;
        if (audioSrc.isPlaying) return;
        audioSrc.PlayOneShot(soundEffect);
    }


    public void PlaySoundLoop() {
        if (audioSrc.isPlaying) return;
        audioSrc.volume = 1f;
        audioSrc.loop = true;
        audioSrc.clip = soundEffect;
        audioSrc.Play();
    }

    public void StopSound() {
        if (!audioSrc.isPlaying) return;
        StartCoroutine(FadeToZeroVolume());
    }

    private void OnMouseDown()
    {
        if (playOnceWhenClick)
        {
            PlaySoundOnce();
        }
    }

    IEnumerator FadeToZeroVolume() {
        audioSrc.loop = false;
        while (audioSrc.volume > 0) {
            audioSrc.volume -= 0.005f;
            yield return null;
        }
        audioSrc.Stop();
        //audioSrc.volume = 1f;
    }

}
