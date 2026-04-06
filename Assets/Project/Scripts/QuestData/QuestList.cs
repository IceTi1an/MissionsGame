using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestList", menuName = "Quest/QuestList")] // создаем QuestList в AssetMenu где будем хранит лист этих самых уже готовых заданий
public class QuestList : ScriptableObject
{
    public List<Quest> Quests; // создаем лист заданий для ссылки на нее в последующем
    public int MaxActiveQuests = 4; // число максимально активных заданий, можно изменять через сам QuestList

    public void ResetAll() // сбрасываем статус принятия и завершения чтобы квесты начинались заново
    {
        foreach (var quest in Quests) // цикл для сброса значений всех квестов в списке
        {
            quest.IsAccepted = false;
            quest.IsCompleted = false;
        }
    }
}
