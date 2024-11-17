using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketController : MonoBehaviour
{
    [SerializeField] private int taskId;

    [Header("Socket")]
    [SerializeField] private GameObject socketSlot;
    private XRSocketInteractor socket;

    [Header("Item Material")]
    private MeshRenderer itemMeshRenderer;
    [SerializeField] private Material newItemMaterial;
    private Material oldItemMaterial;

    [Header("Tank Material")]
    [SerializeField] private GameObject tank;
    private MeshRenderer tankMeshRenderer;
    [SerializeField] private Material newTankMaterial;
    private Material oldTankMaterial;

    [Header("Audio")]
    private AudioSource audioSource;

    private void Start()
    {
        socket = socketSlot.GetComponent<XRSocketInteractor>();
        tankMeshRenderer = tank.GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnSocketEnter()
    {
        IXRSelectInteractable interactable = socket.GetOldestInteractableSelected();

        if (interactable != null)
        {

            if (interactable.transform.gameObject.TryGetComponent(out itemMeshRenderer))
            {
                UpdateItemAndTankMaterial();
                audioSource.Play();

                UIManager.Instance.TaskCompleted(taskId);
            }
        }
    }

    public void OnSocketExit()
    {
        if (itemMeshRenderer != null)
        {
            ResetItemAndTankMaterial();
        }
    }

    private void UpdateItemAndTankMaterial()
    {
        oldItemMaterial = itemMeshRenderer.material;
        itemMeshRenderer.material = newItemMaterial;

        oldTankMaterial = tankMeshRenderer.material;
        tankMeshRenderer.material = newTankMaterial;
    }

    private void ResetItemAndTankMaterial()
    {
        itemMeshRenderer.material = oldItemMaterial;
        tankMeshRenderer.material = oldTankMaterial;
    }
}
