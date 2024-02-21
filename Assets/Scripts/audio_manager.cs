using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio_source;

    [SerializeField]
    private AudioClip pick_up_sound;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void PlayPickUpSound()
    {
        audio_source.PlayOneShot(pick_up_sound);
    }
}
