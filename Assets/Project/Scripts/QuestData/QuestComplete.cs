using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuestComplete : MonoBehaviour
{
    private QuestController _controller;
    private Quest _quest;

    [Inject]
    public void Construct(QuestController controller)
    {
        _controller = controller;
    }

    public void Init(Quest quest)
    {
        _quest = quest;
        GetComponent<Button>().onClick.AddListener(() => _controller.CompleteQuest(_quest));
    }
}