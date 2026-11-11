
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera mainCamera;

    [SerializeField] private float interactionDistance = 3f;

    private GlowProp currentTarget;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = mainCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        RaycastHit hit;

        GlowProp newTarget = null;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                newTarget = hit.collider.GetComponent<GlowProp>();
            }
        }

        if (currentTarget == newTarget)
            return;

        if (currentTarget != null)
        {
            currentTarget.DisableGlow();
        }

        currentTarget = newTarget;

        if (currentTarget != null)
        {
            currentTarget.EnableGlow();
        }
    }

    void Interact()
    {
        if (currentTarget != null)
        {
            Debug.Log("Interacted with: " + currentTarget.name);

            // Add your interaction logic here
        }
    }
}
