using UnityEngine;
using Zenject;

// так как зависимости не прокидываются автоматически при создании через Zenject делаем контейнер и методы для их ручного прокидывания.
public class DIService : MonoBehaviour
{
    // создаем статистический контейнер через SceneContext для дальнейшей ссылки на данный контейнер 
    // внутри которого уже сам Zenject прокинет нужные зависимости потому что при создании через 
    // Instantiate зависимости не прокидываются
    private static DiContainer container { get; set; }

    public static void AddContainer(DiContainer newContainer)
    {
        container = newContainer;
    }

    // делаем метод для ручного прокидывания зависимостей, а если быть проще то мы просто помещаем в контейнер наш обьект а Zenject там дальше сам справляется
    public static void Inject(object obj)
    {
        container?.Inject(obj);
    }
}
