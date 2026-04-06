using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuestAccept : MonoBehaviour
{
    [Inject]

    public QuestController _controller;
    public Quest _quest;

    public void Construct(QuestController controller)
    {
        _controller = controller;
    }

    public void Init(Quest quest)
    {
        _quest = quest;
        GetComponent<Button>().onClick.AddListener(() => _controller.AcceptQuest(_quest));
    }
}