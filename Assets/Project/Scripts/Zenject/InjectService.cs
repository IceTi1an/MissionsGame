using Zenject;

public static class InjectService
{
    // на самом деле не сильно шарю как это работает но здесь мы создаем метод 
    //Inject чтобы в других скриптах можно было делать так - [Inject]
    public static void Inject(object obj)
    {
        ProjectContext.Instance.Container.Inject(obj);
    }
}
