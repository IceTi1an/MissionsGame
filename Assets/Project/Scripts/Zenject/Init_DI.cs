using UnityEngine;
using Zenject;

public class Init_DI : MonoInstaller
{
    public override void InstallBindings()
    {
        // Регистрируем контроллер и вью из сцены
        Container.Bind<QuestController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<QuestView>().FromComponentInHierarchy().AsSingle();
    }
}