using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundSO")]
public class SoundSO : ScriptableObject
{
    public List<Sound> SoundList;
    public List<Music> MusicList;
    public GameObject SourcePrefab;


    public List<Sound> GetSoundList()
    {
        return SoundList;
    }
    public List<Music> GetMusicList()
    {
        return MusicList;
    }
    public GameObject GetSourcePrefab()
    {
        return SourcePrefab;
    }
}
