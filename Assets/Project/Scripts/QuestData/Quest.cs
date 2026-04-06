using System;
using UnityEngine;
using UnityEngine.UI;

// создаем контейнер для хранения данных о квесте и уже в движке заполняем все что нам нужно 
//если что можем добавить убавить или вообще поменять квесты и их данные
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    // делаем данные для заданий чтобы потом мы могли их заполнить

    [HideInInspector] public bool IsAccepted;
    [HideInInspector] public bool IsCompleted;
    // создаем логическую переменную и далее скрываем ее в инспекторе потому что нам нужен будет public
    // для использования переменного в других скриптах, а оставить ее в инспекторе ну не красиво
}