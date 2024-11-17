using UnityEngine;

public enum LightColor
{
    Red = 0,
    Yellow = 1,
    Green = 2
}

public class ValveAndLeverController : MonoBehaviour
{
    [SerializeField] private int taskId;

    [SerializeField] private Quaternion openRotation;
    [SerializeField] private Quaternion closedRotation;

    [SerializeField] private GameObject redLight;
    [SerializeField] private GameObject yellowLight;
    [SerializeField] private GameObject greenLight;

    private float angleEpsilon = 5.0f;

    private void FixedUpdate()
    {
        if (Quaternion.Angle(transform.localRotation, closedRotation) <= angleEpsilon)
        {
            ChangeIndicatorLight(LightColor.Red);
        }
        else if (Quaternion.Angle(transform.localRotation, openRotation) <= angleEpsilon)
        {
            ChangeIndicatorLight(LightColor.Green);

            UIManager.Instance.TaskCompleted(taskId);
        }
        else
        {
            ChangeIndicatorLight(LightColor.Yellow);
        }
    }

    private void ChangeIndicatorLight(LightColor color)
    {
        if (color.Equals(LightColor.Red))
        {
            redLight.SetActive(true);
            yellowLight.SetActive(false);
            greenLight.SetActive(false);
        }
        else if (color.Equals(LightColor.Green))
        {
            redLight.SetActive(false);
            yellowLight.SetActive(false);
            greenLight.SetActive(true);
        }
        else
        {
            redLight.SetActive(false);
            yellowLight.SetActive(true);
            greenLight.SetActive(false);
        }
    }
}
