using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	public AudioSource audioSource;
	
	public AudioClip[] audioClips;
	
	public float fadeDuration = 1f;
	public float maxVolume = 1;
	
    public void playTrack(int index){
		StartCoroutine(StartFade(audioSource, fadeDuration, maxVolume));
	}
	
	public void fadeOut(){
		StartCoroutine(StartFade(audioSource, fadeDuration, 0f));
	}
	
	public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume) {
		float currentTime = 0;
		float start = audioSource.volume;

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
			yield return null;
		}
		yield break;
	}
}