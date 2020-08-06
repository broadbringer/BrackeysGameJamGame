using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using UnityEngine;
using UnityEngine.EventSystems;
using Application = Assets.Scripts.Core.Application;


public class WorkPlace : MonoBehaviour,IPointerClickHandler
{
    private PlaceState _state;

    
    [SerializeField] private int _dayToOpen;
    [SerializeField] private WorkPlaceView _view;
    public int DayToOpen => _dayToOpen;

    [SerializeField] private float _price;

    public float Price => _price;

    public Transform Position;
    
    private void Start()
    {
        Position = GetComponent<Transform>();
        _state = PlaceState.Close;
    }

    
    public void ChangeState()
    {
        _state = PlaceState.Open;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //Открываем UI, который привязан к этому объекту. Делаем проверку на то, какой сегодня день. Если день позвоялет купить, делаем кнопку Buy активной.
        if (_state == PlaceState.Close)
        {
            _view.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }



    private enum PlaceState
    {
        Open,
        Close
    }
}

