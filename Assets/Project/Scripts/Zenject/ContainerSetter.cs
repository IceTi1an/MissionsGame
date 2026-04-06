using Zenject;

public class ContainerSetter : MonoInstaller
{
    // делаем второй Installer в SceneContext для использования DIService(ручное прокидывание зависимостей)
    public override void InstallBindings()
    {
        DIService.AddContainer(Container);
    }
}