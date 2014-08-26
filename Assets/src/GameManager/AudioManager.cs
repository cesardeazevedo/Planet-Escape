using UnityEngine;

public class AudioManager : MonoBehaviour 
{

    [HideInInspector]
    public AudioSource source;
    
    public AudioClip[] Clips;

    private static AudioManager _instance;

    public static AudioManager Instance{
        get{      
            if(_instance == null){

                GameObject soundfx= GameObject.Find("AudioEffect");

                if(soundfx != null)
                    _instance = soundfx.GetComponent<AudioManager>();

            }
            return _instance;
        }
    }

    //
    public enum SoundEffect{
        Explosion,
        SpaceCraft,
        Fire,
        GetStar
    }

    private SoundEffect SoundType;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    
    /// <summary>
    /// Plaies the sound.
    /// </summary>
    /// <param name="Sound">Sound.</param>
    public void PlaySound(SoundEffect Sound)
    { 
        source.volume = 1;  
        Play(Sound);
    }
    
    /// <summary>
    /// Plaies the sound.
    /// </summary>
    /// <param name="Sound">Sound.</param>
    /// <param name="Volume">Volume.</param>
    public void PlaySound(SoundEffect Sound, float Volume)
    {
        source.volume = Volume;    
        Play(Sound);
    }

    /// <summary>
    /// Play sound internally.
    /// </summary>
    /// <param name="Sound">Sound.</param>
    private void Play(SoundEffect Sound)
    {
        int IndexSound = GetSoundTypeIndex(Sound);
        source.clip    = Clips[IndexSound];
        source.Play();
    }
    
    /// <summary>
    /// Gets the index of the sound type.
    /// </summary>
    /// <returns>The sound type index.</returns>
    /// <param name="Sound">Sound.</param>
    private int GetSoundTypeIndex(SoundEffect Sound)
    {
        return Sound == SoundEffect.Explosion      ? 0
        :      Sound == SoundEffect.SpaceCraft     ? 1
        :      Sound == SoundEffect.Fire           ? 2
        :      Sound == SoundEffect.GetStar        ? 4
        :      /* Default */                         0;

    }

}
