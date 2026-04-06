using UnityEngine;
using Zenject;
public class GlobalDependencyInstaller : MonoInstaller
{
    [SerializeField] private QuestList questList; // —сылка на ScriptableObject со всеми квестами

    public override void InstallBindings()
    {
        // –егистрируем QuestList как глобальную зависимость
        Container.Bind<QuestList>().FromInstance(questList).AsSingle();
    }
}
