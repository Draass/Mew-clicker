using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelector : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private float timeBetweenSongs = 0f;

    [Header("Arrays")] 
    [SerializeField] private AudioClip[] audioStartArray;
    [SerializeField] private List<AudioClip> audioToPlay = new List<AudioClip>();
    [SerializeField] private List<AudioClip> audioPlayed = new List<AudioClip>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //add songs from array to the list
        audioToPlay.AddRange(audioStartArray);
        //initiate choosing song
        StartCoroutine(SongSwitching());
    }

    private void ChooseRandomSong ()
    {
        if (audioToPlay.Count > 0)
        {
            AudioClip clipToPlay;
            int index = Random.Range(0, audioToPlay.Count - 1);
            clipToPlay = audioToPlay[index];
            audioSource.clip = clipToPlay;
            //add clip to other List
            audioPlayed.Add(clipToPlay);
            audioToPlay.RemoveAt(index);

            Debug.Log("Current song index is " + clipToPlay);
        }
        else
        {
            //reset audioToPlay
            audioToPlay.AddRange(audioPlayed);
            //clear List
            audioPlayed.Clear();
        }
    }

    IEnumerator SongSwitching()
    {
        while (this.enabled)
        {
                ChooseRandomSong();
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length + timeBetweenSongs);
        }
    }
}
