using UnityEngine;
using Zenject;

public class QuestController : MonoBehaviour
{
    private QuestList _questList;   // список квестов
    private QuestView _questView;   // UI который хранит инфу что и как делать с шаблоном

    [Inject]                       //делаем Inject для прокидывания зависимостей через Zenject
    public void Construct(QuestList questList, QuestView questView)
    {
        _questList = questList;
        _questView = questView;

        // после внедрения зависимостей сразу обновляем список заданий
        _questView.UpdateView(_questList);
    }

    private void Start()
    {
        _questList.ResetAll(); // сбрасываем все значения заданий на старте сцены
        _questView.UpdateView(_questList);
    }

    public void AcceptQuest(Quest quest) //метод для принятия задания
    {
        // считаем активные квесты
        int activeCount = _questList.Quests.FindAll(q => q.IsAccepted && !q.IsCompleted).Count;

        if (activeCount < _questList.MaxActiveQuests)
        {
            quest.IsAccepted = true;
            _questView.UpdateView(_questList); // обновляем список для обновления данных на сцене и UI заданий
        }
    }

    public void CompleteQuest(Quest quest) // метод для завершения задания
    {
        // проверка на то принято ли задание чтобы его завершить или нет.
        if (quest.IsAccepted && !quest.IsCompleted)
        {
            quest.IsCompleted = true;
            _questView.UpdateView(_questList);
        }
    }
}
