using UnityEngine;
using Zenject;

public class QuestView : MonoBehaviour
{
    [SerializeField] private Transform questContainer; // место куда надо ставить задания
    [SerializeField] private QuestItemView questItemPrefab; // префаб - готовая загатовка для заполнения данных и создания уже готового обьекта на сцене.

    public void UpdateView(QuestList questList) // скрипт для обновления данных на сцене и в списке заданий
    {
        // очищаем именно контейнер
        foreach (Transform child in questContainer)
            Destroy(child.gameObject);

        int count = 0;
        foreach (var quest in questList.Quests) //создаем цикл для проверки максимального числа активных заданий и остановки создания в случае превышения
        {
            if (count >= questList.MaxActiveQuests) break; // тормоза

            var item = Instantiate(questItemPrefab, questContainer); //передаем на Instantiate сам префаб и место где необходимо его создать
            DIService.Inject(item); // так как зависимости не прокидываются при создании через Instantiate мы прокидываем их вручную
                                    // можно было бы использовать UIFactory в таком случае зависимости можно было бы не прокидывать
                                    // и они ставились бы самостоятельно через Zenject так реализовано в проекте ExamProject
            item.Setup(quest); // собираем задание по кускам и проверяем его состояние т.е статус 
            count++; // счет для тормозов
        }
    }
}
