using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Player player;
    private AudioSource _audio;
    public AudioClip _music;
    public AudioClip _deathSound;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.loop = true;
        _audio.clip = _music;
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsDead())
        {
            if (_audio.clip == _music)
            {
                _audio.Stop();
                _audio.loop = false;
                _audio.clip = _deathSound;
                _audio.Play();
            }
        }
    }
}
