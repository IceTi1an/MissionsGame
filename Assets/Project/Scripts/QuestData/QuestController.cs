using UnityEngine;
using Zenject;

public class QuestController : MonoBehaviour
{
    private QuestList _questList;   // Ссылка на список всех квестов
    private QuestView _questView;   // Ссылка на UI, который показывает квесты

    [Inject]                       // Zenject сам подставит сюда зависимости
    public void Construct(QuestList questList, QuestView questView)
    {
        _questList = questList;
        _questView = questView;

        // Вызов сразу после того, как зависимости внедрены
        _questView.UpdateView(_questList);
    }


    public void AcceptQuest(Quest quest)
    {
        // Считаем сколько активных квестов
        int activeCount = _questList.Quests.FindAll(q => q.IsAccepted && !q.IsCompleted).Count;

        // Если лимит не превышен — принимаем квест
        if (activeCount < _questList.MaxActiveQuests)
        {
            quest.IsAccepted = true;
            _questView.UpdateView(_questList); // Обновляем UI
        }
    }

    public void CompleteQuest(Quest quest)
    {
        // Если квест был принят и ещё не завершён — завершаем
        if (quest.IsAccepted && !quest.IsCompleted)
        {
            quest.IsCompleted = true;
            _questView.UpdateView(_questList); // Обновляем UI
        }
    }
}
