using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SoundFXController : MonoBehaviour
{
    public AudioSource Ambience1;
    public AudioSource Ambience2;
    public AudioSource Ambience3;
    public AudioSource Ambience4;
    public AudioSource Ambience5;
    public AudioSource Ambience6;
    public AudioSource Ambience7;
    private AudioSource[] Audio = new AudioSource[6];
    private AudioSource nextSong;

    
    float incrementMusicOff;
    float incrementMusicOn;
    int r;

    public float musicOnLength;
    public float musicOffLength;

    bool musicactive = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get ready for some really inefficient coding//
        //I need to find a better way of assigning the array//
        Audio[0] = Ambience1;
        Audio[1] = Ambience2;
        Audio[2] = Ambience3;
        //Audio[3] = Ambience4;
        Audio[3] = Ambience5;
        Audio[4] = Ambience6;
        Audio[5] = Ambience7;

        
    }

    // Update is called once per frame
    void Update()
    {
        //The music will be turned on and off in intervals of x amount//


        if(musicactive == false){
            incrementMusicOff += 1 * Time.deltaTime;
            //Debug.Log(increment);
        }   
        else{
            incrementMusicOn += 1 * Time.deltaTime;
        }
 

        if (incrementMusicOff > musicOffLength && musicactive == false){
            int prev = r;
            r = UnityEngine.Random.Range(0, 6);
            while(prev == r){
                r = UnityEngine.Random.Range(0, 6);
            }

            Debug.Log(r);
            nextSong = Audio[r];
            StartCoroutine(FadeIn(nextSong, 25));
            musicactive = true;
            incrementMusicOff = 0;    
        }

        if (incrementMusicOn > musicOnLength && musicactive == true){
            StartCoroutine(FadeOut(nextSong, 10));
            Debug.Log("FadeOut");
            musicactive = false;
            incrementMusicOn = 0;

        }

        
    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;
		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.Stop();
	}

	public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime) {
			audioSource.Play();
			audioSource.volume = 0f;
			while (audioSource.volume < 0.3f) {
				audioSource.volume += Time.deltaTime / FadeTime;
				yield return null;
		}
	}
}
