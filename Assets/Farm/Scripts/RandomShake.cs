using UnityEngine;
using DG.Tweening;

public class RandomShake : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float duration = 10f;
    [Header("Shake Rotation Config")]
    [SerializeField] private float rotationShakeStrength = 1f;
    [SerializeField] private int rotationShakeFrequency = 10;
    [Header("Shake Position Config")]
    [SerializeField] private float positionShakeStrength = 0.06f;
    [SerializeField] private int positionShakeFrequency = 10;

    public void Shake()
    {
        transform.DOShakeRotation(duration:duration, strength:rotationShakeStrength, vibrato:rotationShakeFrequency, fadeOut:false);
        transform.DOShakePosition(duration:duration, strength:positionShakeStrength, vibrato:positionShakeFrequency, fadeOut: false);
    }
}