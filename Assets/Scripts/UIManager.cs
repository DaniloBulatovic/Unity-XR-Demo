using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text Task1Label;
    [SerializeField] private GameObject Task1Checkmark;

    [SerializeField] private TMP_Text Task2Label;
    [SerializeField] private GameObject Task2Checkmark;

    [SerializeField] private TMP_Text Task3Label;
    [SerializeField] private GameObject Task3Checkmark;

    [SerializeField] private TMP_Text Task4Label;
    [SerializeField] private GameObject Task4Checkmark;

    private void Start()
    {
        InitializeTaskUI();
    }

    private void InitializeTaskUI()
    {
        Task1Label.color = Color.red;
        Task1Checkmark.SetActive(false);

        Task2Label.color = Color.red;
        Task2Checkmark.SetActive(false);

        Task3Label.color = Color.red;
        Task3Checkmark.SetActive(false);

        Task4Label.color = Color.red;
        Task4Checkmark.SetActive(false);
    }

    public void TaskCompleted(int taskNumber)
    {
        switch (taskNumber)
        {
            case 1:
                Task1Label.color = Color.green;
                Task1Checkmark.SetActive(true);
                break;
            case 2:
                Task2Label.color = Color.green;
                Task2Checkmark.SetActive(true);
                break;
            case 3:
                Task3Label.color = Color.green;
                Task3Checkmark.SetActive(true);
                break;
            case 4:
                Task4Label.color = Color.green;
                Task4Checkmark.SetActive(true);
                break;
        }
    }
}
