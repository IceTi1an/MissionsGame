using UnityEngine;
using Zenject;

public class QuestView : MonoBehaviour
{
    [SerializeField] private Transform questContainer;
    [SerializeField] private QuestItemView questItemPrefab;

    public void UpdateView(QuestList questList)
    {
        // очищаем именно контейнер
        foreach (Transform child in questContainer)
            Destroy(child.gameObject);

        int count = 0;
        foreach (var quest in questList.Quests)
        {
            if (count >= questList.MaxActiveQuests) break;

            var item = Instantiate(questItemPrefab, questContainer);
            item.Setup(quest);
            count++;
        }
    }
}
