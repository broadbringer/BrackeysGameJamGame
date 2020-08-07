using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Workers;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class WorkerCreator : MonoBehaviour
{
    public Worker WorkerPrefab;
    private int WorkerCreated = 0;
    private int MaxCount = 4;
    public Queue<WorkPlace> Positions;
    private float time;

    private void Start()
    {
        Positions = new Queue<WorkPlace>();
    }
    public void Create()
    {
        if (WorkerCreated < MaxCount)
        {
            if (Positions.Count != 0)
            {
                var worker = Instantiate(WorkerPrefab, Positions.Dequeue().Position.position, Quaternion.identity);
                Application.GetInstance().GameSessionData.AIWorkers.Add(worker);
                WorkerCreated++;
            }
        }
    }
    //Тут же и будем проверять есть ли свободные столы.
}
