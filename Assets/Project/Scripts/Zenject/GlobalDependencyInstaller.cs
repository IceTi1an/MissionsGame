using UnityEngine;
using Zenject;
public class GlobalDependencyInstaller : MonoInstaller // создаем DI для ProjectContext
{
    [SerializeField] private QuestList questList;

    public override void InstallBindings()
    {
        // прокидываем на QuestList глобальную зависимость
        Container.Bind<QuestList>().FromInstance(questList).AsSingle();
    }
}
