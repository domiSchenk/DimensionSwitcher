using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource _collectSoundEffect;
    [SerializeField] private AudioSource _jumpSoundEffect;
    [SerializeField] private AudioSource _deathSoundEffect;
    [SerializeField] private AudioSource _winSoundEffect;
    [SerializeField] private AudioSource _riftSoundEffect;
    [SerializeField] private AudioSource _riftFoundSoundEffect;
    [SerializeField] private AudioSource _footstepSoundEffect;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayCollectSound() => playEffect(_collectSoundEffect);
    public void PlayJumpSound() => playEffect(_jumpSoundEffect);
    public void PlayDeathSound() => playEffect(_deathSoundEffect);
    public void PlayWinSound() => playEffect(_winSoundEffect);
    public void PlayHurtSound() => playEffect(_riftSoundEffect);
    public void PlayFootstepSound() => playEffect(_footstepSoundEffect);
    public void StopFootstepSound() => stopEffect(_footstepSoundEffect);
    public void PlayRiftFoundSound() => playEffect(_riftFoundSoundEffect);
    public void PlayRiftSound() => playEffect(_riftSoundEffect);

    private void playEffect(AudioSource effect)
    {
        if (effect != null && !effect.isPlaying)
        {
            effect.Play();
        }
    }

    private void stopEffect(AudioSource effect)
    {
        if (effect != null && effect.isPlaying)
        {
            effect.Stop();
        }
    }

}
