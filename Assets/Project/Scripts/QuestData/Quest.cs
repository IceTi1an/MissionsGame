using System;
using UnityEngine;
using UnityEngine.UI;

//—оздаем контейнер дл€ хранени€ данных о квесте
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;

    [HideInInspector] public bool IsAccepted;
    [HideInInspector] public bool IsCompleted;
}