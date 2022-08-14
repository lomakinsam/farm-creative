using UnityEngine;
using DG.Tweening;

public class Environment : MonoBehaviour
{
    [SerializeField] private LayerMask collisionLayers;
    [Header("Animation config")]
    [SerializeField] private float shakeAnimDuration = 1.0f;
    [SerializeField] private float scaleStrength = 0.4f;
    [SerializeField] private float rotationStrength = 4.0f;

    private Tween shakeScaleAnim;
    private Tween shakeRotationAnim;

    private void OnTriggerEnter(Collider other)
    {
        // on collision with shockwave
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer)))
            Shake();
    }

    private void Shake()
    {
        if (shakeScaleAnim.IsActive() || shakeRotationAnim.IsActive())
            return;

        shakeScaleAnim = transform.DOShakeScale(shakeAnimDuration, scaleStrength); // Default: 1.0f, 0.4f
        shakeRotationAnim = transform.DOShakeRotation(shakeAnimDuration, rotationStrength); // Default: 1.0f, 4.0f
    }
}
