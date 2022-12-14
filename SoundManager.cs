using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private List<Sound> SoundList;
    private List<Music> MusicList;

    public SoundSO soundSO;

    private AudioSource Source;
    private AudioSource MusicSource;

    private int SoundStatus;
    private int MusicStatus;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound",1);
        }
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
        }

        SoundStatus = PlayerPrefs.GetInt("Sound");
        MusicStatus= PlayerPrefs.GetInt("Music");

        SoundList = soundSO.GetSoundList();
        MusicList = soundSO.GetMusicList();


    }

    private void Start()
    {
        if (MusicSource == null)
            MusicSource = Instantiate(soundSO.GetSourcePrefab(), Vector3.zero, Quaternion.identity).GetComponent<AudioSource>();

        if (Source == null)
            Source = Instantiate(soundSO.GetSourcePrefab(), Vector3.zero, Quaternion.identity).GetComponent<AudioSource>();

    }
    public void PlaySound(SoundName _sound)
    {
        if (SoundStatus==1)
        {
            foreach (Sound sound in SoundList)
            {

                if (sound.soundName == _sound)
                {
                    sound.PlaySound(Source);
                }
            }
        }


    }

    public void PlayMusic(MusicName _music)
    {
        if (MusicStatus==1)
        {
            foreach (Music music in MusicList)
            {
                if (music.musicName == _music)
                {
                    music.PlayMusic(MusicSource);
                }
            }
        }
    }

    public bool GetMusicStatus()
    {
        if (MusicStatus == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool GetSoundStatus()
    {
        if (SoundStatus == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ChangeSoundStatus()
    {
        if (SoundStatus==0)
        {
            SoundStatus = 1;
            PlayerPrefs.SetInt("Sound",SoundStatus);
            return true;
        }
        else if (SoundStatus==1)
        {
            SoundStatus = 0;
            PlayerPrefs.SetInt("Sound", SoundStatus);
            return false;
        }
        else
        {
            return false;
        }
   }
    public bool ChangeMusicStatus()
    {
        if (MusicStatus == 0)
        {
            MusicStatus = 1;
            PlayerPrefs.SetInt("Music", SoundStatus);
            return true;
        }
        else if (MusicStatus == 1)
        {
            MusicStatus = 0;
            PlayerPrefs.SetInt("Music", MusicStatus);
            return false;
        }
        else
        {
            return false;
        }
    }

}



[System.Serializable]

public class Sound
{
    public SoundName soundName;
    public AudioClip Audio;

    public void PlaySound(AudioSource source)
    {
        source.PlayOneShot(Audio);
    }
}

[System.Serializable]
public class Music
{
    public MusicName musicName;
    public AudioClip Audio;

    public void PlayMusic(AudioSource source)
    {
        source.clip = Audio;
        source.loop = true;
        source.Play();
    }
}

public enum SoundName
{
    Button,
    Panel
}
public enum MusicName
{
    MainMenu,
    Game
}
