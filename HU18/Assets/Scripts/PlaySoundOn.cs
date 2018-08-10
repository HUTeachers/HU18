using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public enum SoundEnum
{
    OnCollision,
    OnTrigger,
    OnActivate,
    OnInput
}

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOn : MonoBehaviour
{

    public SoundEnum soundEnum;

    public List<KeyCode> inputKeys = new List<KeyCode>();

    AudioSource aSource;

    public bool RequireTag;
    public string RequiredTag;

    void Update()
    {
        if (soundEnum == SoundEnum.OnInput)
        {
            //inputKeys.Find(x => Input.GetKeyDown(x));
            foreach (KeyCode item in inputKeys)
            {
                if (Input.GetKeyDown(item))
                {
                    Randomize(aSource);
                    aSource.Play();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (soundEnum == SoundEnum.OnCollision)
        {
            if (RequireTag == false || RequireTag == true && RequiredTag == collision.transform.tag)
            {
                Play();
            }


        }
    }

    private void Play()
    {

        aSource = GetComponent<AudioSource>();
        GameObject g = new GameObject()
        {
            name = "Audio object"
        };
        g.AddComponent<AudioSource>();
        AudioSource bSource = g.GetComponent<AudioSource>();

        CopyAudio(aSource, bSource);

        Randomize(bSource);
        bSource.Play();
        Destroy(g, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (soundEnum == SoundEnum.OnTrigger)
        {
            if (RequireTag == false || RequireTag == true && RequiredTag == collision.transform.tag)
            {
                Play();
            }
        }
    }

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();

        if (soundEnum == SoundEnum.OnActivate)
        {
            Randomize(aSource);
            aSource.Play();
        }
    }

    private void Randomize(AudioSource aSource)
    {
        aSource.pitch = Random.Range(0.95f * aSource.pitch, 1.05f * aSource.pitch);
        aSource.volume = Random.Range(0.95f * aSource.volume, 1.05f * aSource.volume);
    }

    private void CopyAudio(AudioSource source, AudioSource dest)
    {
        AudioClip ac = source.clip;
        float pitch = source.pitch;
        float volu = source.volume;
        bool playOnAwake = source.playOnAwake;

        dest.clip = ac;
        dest.pitch = source.pitch;
        dest.volume = volu;
        dest.playOnAwake = playOnAwake;

    }
}
