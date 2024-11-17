using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandController : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerInput;
    [SerializeField] private InputActionReference gripInput;

    private Animator handAnimator;
    private float triggerValue;
    private float gripValue;

    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateTrigger();
        AnimateGrip();
    }

    private void AnimateTrigger()
    {
        triggerValue = triggerInput.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
    }

    private void AnimateGrip()
    {
        gripValue = gripInput.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
