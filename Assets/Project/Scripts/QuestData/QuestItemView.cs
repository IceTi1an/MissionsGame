using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuestItemView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private GameObject completedStatusGO;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button completeButton;

    private Quest _quest;
    private QuestController _controller;

    [Inject]
    public void Construct(QuestController controller)
    {
        _controller = controller;
    }

    public void Setup(Quest quest)
    {
        _quest = quest;

        icon.sprite = quest.icon;
        nameText.text = quest.name;
        descriptionText.text = quest.description;

        if (quest.IsCompleted)
        {
            statusText.text = "Завершен";
            completedStatusGO.SetActive(true);
        }
        else if (quest.IsAccepted)
        {
            statusText.text = "Принят";
            completedStatusGO.SetActive(false);
        }
        else
        {
            statusText.text = "Доступен";
            completedStatusGO.SetActive(false);
        }

        // Привязываем кнопки
        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(() => _controller.AcceptQuest(_quest));

        completeButton.onClick.RemoveAllListeners();
        completeButton.onClick.AddListener(() => _controller.CompleteQuest(_quest));
    }
}
