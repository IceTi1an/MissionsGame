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
    // все что выше мы создаем переменные для привязки заданий и дальнейшего их создания
    // а [SerializeField] делаем чтобы они были видны в Unity чтобы мы могли задать их

    private Quest _quest;
    private QuestController _controller;

    [Inject] // если быть проще то с помощью данной штуки Zenject находит для метода ниже ему нужный QuestController
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
        // собираем задание по кусочкам

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
        // все что стоит в условных операторах это проверка что если задание принято его можно завершить в противном случае нет

        // убираем все задачи с кнопок потом задаем им метод которые необходимо запустить при нажатии кнопки
        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(() => _controller.AcceptQuest(_quest));

        completeButton.onClick.RemoveAllListeners();
        completeButton.onClick.AddListener(() => _controller.CompleteQuest(_quest));
    }
}
