using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//Используем данный класс для хранения ссылок на нужные объекты в игре.

/// <summary>
/// Общие правила написание кода, чтобы не было всяких различий
///
/// private переменные называем в стиле _name , то есть с нижнего подчеркивания и с маленькой буквы
/// public переменные называем в стиле Name, то есть просто с большой буквы
///
/// Старайся придумывать названия для переменных методов, по которым сразу понятно что оно хранит в себе или что этот метод должен делать
/// Если метод имеет возвращаемый тип, то желательно называть его с Get. Типа, GetDistanceBetween(), но если это свойство, то его называем без Get.
///
/// Расположение методов в скрипте:
///
/// Сначала идут public переменные, потом private. Потом свойства. После идут Monobeh методы по порядку Awake -> OnEnable -> Start -> Update -> LateUpate -> FixedUpdate
/// Enum, который относится к данному классу находится в самом начале кода.
///
///
/// Так-же, переменные, которые являются составляющими одного объекта, к примеру RigidBody, не надо делать public и перекидывать через инспектор.
/// Делаем их private, или если к ним получать доступ из других скриптов, то можно сделать public, но инициализируем их на старте при помощи GetComponent
/// </summary>

public class Application : MonoBehaviour
{

    private static Application _instance;

    public static Application GetInstance()
    {
        return _instance == null ? null : _instance;
    }
    
    private void Start()
    {
        _instance = this;
        
    }
}
