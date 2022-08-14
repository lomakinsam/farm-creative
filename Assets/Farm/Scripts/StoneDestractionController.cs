using UnityEngine;
using UnityEngine.VFX;
using DG.Tweening;

public class StoneDestractionController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private Collider relatedCollider;
    [SerializeField] private MeshRenderer[] relatedMeshRenderers;
    [SerializeField] private float activationDelay;
    [Header("Shockwave Effect")]
    [SerializeField] private GameObject shockwaveInstance;
    [SerializeField] private Material shockwaveMaterial;
    [Header("Additional Effects")]
    [SerializeField] private ParticleSystem dustEffect;
    [SerializeField] private VisualEffect destructionEffect;

    private const string expansionStepPropertyRef = "Vector1_22fd289830de447a806ebcc68970b3ec";

    private void Awake() => shockwaveInstance.SetActive(false);

    private void OnTriggerEnter(Collider other)
    {
        // on collision with agrimotor
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer)))
            PlayStoneAnimation();
    }

    private void PlayStoneAnimation()
    {
        DisableRelatedCollider();

        Sequence stoneAnimation = DOTween.Sequence();
        stoneAnimation.AppendInterval(activationDelay);
        stoneAnimation.Append(transform.DOScaleY(0.2f, 0.4f));
        stoneAnimation.Append(transform.DOScaleY(0.05f, 0.15f));

        stoneAnimation.OnComplete(() => {
            DisableMeshRenderers();

            PlayDestractionEffect();
            PlayShockwaveEffect();
            PlayDustEffect();
        });
    }

    private void PlayShockwaveEffect(float duration = 1.5f)
    {
        // prepare shockwave
        shockwaveMaterial.SetFloat(expansionStepPropertyRef, 0);
        shockwaveInstance.SetActive(true);

        float step = 0f;
        Tween stepInterpolation = DOTween.To(() => step, x => { step = x; shockwaveMaterial.SetFloat(expansionStepPropertyRef, step); }, 1.0f, duration);
        stepInterpolation.OnComplete(() => shockwaveInstance.SetActive(false));
    }

    private void PlayDustEffect() => dustEffect.Play();

    private void PlayDestractionEffect() => destructionEffect.gameObject.SetActive(true);

    private void DisableMeshRenderers()
    {
        for (int i = 0; i < relatedMeshRenderers.Length; i++)
            relatedMeshRenderers[i].enabled = false;
    }

    private void DisableRelatedCollider() => relatedCollider.enabled = false;
}
