using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance
    {
        private set; get;
    }
    public AudioSource MusicSource;
    public AudioSource UISource;
    public AudioSource SFXSource;
    [SerializeField]
    public List<Audio> DicAudio = new List<Audio>();
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio("MusicBg");
        ObserverManager.AddListener<string>("PlayAudio", PlayAudio);


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayAudio(string audioTag)
    {
        Audio _tempAudio = DicAudio.Find(x => x.Tag == audioTag);
        if (_tempAudio.Type == AudioType.Music)
        {
            MusicSource.clip = _tempAudio.Sound;
            MusicSource.loop = true;
            MusicSource.Play();


        }
        else if (_tempAudio.Type == AudioType.UI)
        {
            UISource.clip = _tempAudio.Sound;
            UISource.loop = false;

            UISource.PlayOneShot(UISource.clip);
            UISource.clip = null;

        }
        else if (_tempAudio.Type == AudioType.SFX)
        {
            SFXSource.clip = _tempAudio.Sound;
            SFXSource.loop = false;

            SFXSource.PlayOneShot(SFXSource.clip);
            UISource.clip = null;

        }




    }

}
[Serializable]
public class Audio
{
    public string Tag;
    public AudioType Type;
    public AudioClip Sound;

};
[Serializable]

public enum AudioType
{
    Music,
    SFX,
    UI
}
