using UnityEngine;
using UnityEngine.VFX;

public class EffectStateSwitcher : MonoBehaviour
{
    [SerializeField] private VisualEffect[] VFXEffects;
    [SerializeField] private ParticleSystem[] particleSystemEffects;

    public void SwitchState()
    {
        for (int i = 0; i < VFXEffects.Length; i++)
        {
            if (VFXEffects[i].enabled)
            {
                VFXEffects[i].enabled = false;
            }
            else
            {
                VFXEffects[i].enabled = true;
            }
        }

        for (int i = 0; i < particleSystemEffects.Length; i++)
        {
            if (particleSystemEffects[i].isPaused)
                particleSystemEffects[i].Play();
            else
                particleSystemEffects[i].Pause();
        }
    }
}
