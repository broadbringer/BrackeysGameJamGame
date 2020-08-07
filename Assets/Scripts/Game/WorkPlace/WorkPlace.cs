using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using UnityEngine;
using UnityEngine.EventSystems;
using Application = Assets.Scripts.Core.Application;


public class WorkPlace : MonoBehaviour,IPointerClickHandler
{
    private PlaceState _state;
    
    public Sprite OpenTableSprite;
    
    [SerializeField] private int _dayToOpen;
    [SerializeField] private WorkPlaceView _view;
    public int DayToOpen => _dayToOpen;

    [SerializeField] private float _price;

    public float Price => _price;

    public Transform Position { get; set; }
    
    private void Start()
    {
        Position = GetComponent<Transform>();
        _state = PlaceState.Close;
        
    }
    
    public void ChangeState()
    {
        _state = PlaceState.Open;
        Application.GetInstance().Creator.Positions.Enqueue(this);
        _view.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = OpenTableSprite;
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

