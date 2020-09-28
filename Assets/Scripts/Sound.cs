using UnityEngine;

[System.Serializable]

// used in all of the sounds of the game
// variables of the class are used throughout methods
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
