using UnityEngine;

public class DistortionEffectController : MonoBehaviour
{
    [SerializeField] private Material distortionMaterial;
    [SerializeField] private SphereCollider relatedCollideer;

    private const string expansionStepPropertyRef = "Vector1_22fd289830de447a806ebcc68970b3ec";
    private const string maxRadiusPropertyRef = "Vector1_353e8dfb5e6e420fa27ceaa22cb13455";

    private void UpdateRelatedCollider()
    {
        float radius = distortionMaterial.GetFloat(maxRadiusPropertyRef) * distortionMaterial.GetFloat(expansionStepPropertyRef) / 2;
        relatedCollideer.radius = radius;
    }

    private void FixedUpdate()
    {
        UpdateRelatedCollider();
    }
}
