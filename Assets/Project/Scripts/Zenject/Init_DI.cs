using UnityEngine;
using Zenject;

public class Init_DI : MonoInstaller
{
    public override void InstallBindings()
    {
        // –егистрируем контроллер и вью из сцены,а быть точнее из иерархии дл€ прокидывани€ зависимостей.
        Container.Bind<QuestController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<QuestView>().FromComponentInHierarchy().AsSingle();
    }
}