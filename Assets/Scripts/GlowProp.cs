using UnityEngine;

public class GlowProp : MonoBehaviour
{
    [SerializeField] private Material glowMaterial;

    private Renderer objectRenderer;
    private Material originalMaterial;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    public void EnableGlow()
    {
        objectRenderer.material = glowMaterial;
    }

    public void DisableGlow()
    {
        objectRenderer.material = originalMaterial;
    }
}