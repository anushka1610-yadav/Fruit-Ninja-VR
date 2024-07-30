using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;


    void Awake()
    {
        foreach (Sounds s in sound)
        {
            GameObject obj = new GameObject("Sound_" + s.name);
            obj.transform.SetParent(transform);
            s.SetSource(obj.AddComponent<AudioSource>());
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.Play();
    }
}
