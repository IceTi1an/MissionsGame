using Zenject;

public static class InjectService
{
    public static void Inject(object obj)
    {
        ProjectContext.Instance.Container.Inject(obj);
    }
}
