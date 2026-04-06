using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestList", menuName = "Quest/QuestList")]
public class QuestList : ScriptableObject
{
    public List<Quest> Quests;
    public int MaxActiveQuests = 4;
}
