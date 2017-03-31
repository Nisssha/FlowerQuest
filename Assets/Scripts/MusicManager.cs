using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
    int i;


    void Awake ()
    {
		DontDestroyOnLoad(gameObject);
	}
	void Start ()
    {
        i = 0;
		audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelMusicChangeArray[i];
		audioSource.Play();
	}
	
	public void ChangeVolume (float newVolume)
    {
		audioSource.volume = newVolume;
	}

    private void Update()
    {
        if (!audioSource.isPlaying)    
        {
            i++;
            if(levelMusicChangeArray.Length > i)
            {
                audioSource.clip = levelMusicChangeArray[i];
                audioSource.Play();
            }
            else
            {
                i = 0;
                audioSource.clip = levelMusicChangeArray[i];
                audioSource.Play();
            }
        }
       
    }

    /*
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		//Debug.Log ("Playing: " +thisLevelMusic);
		if (thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	
	}
    */
}
