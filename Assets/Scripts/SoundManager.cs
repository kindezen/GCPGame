using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<SoundManager>();

            return instance;
        }
    }

    public AudioSource audioSource;
    public AudioClip[] sounds;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    AudioClip ReturnClipByName(string _name)
    {
        foreach(var item in sounds)
        {
            if (item.name == _name)
                return item;
        }

        return sounds[0];
    }

    public void PlaySFX(string _name, float _delay = 0.0f, float _volume = 1.0f)
    {
        StartCoroutine(DelaySound(_name, _delay, _volume));
    }

    IEnumerator DelaySound(string _name, float _delay, float _volume)
    {
        yield return new WaitForSeconds(_delay);

        audioSource.PlayOneShot(ReturnClipByName(_name), _volume);
    }
}
