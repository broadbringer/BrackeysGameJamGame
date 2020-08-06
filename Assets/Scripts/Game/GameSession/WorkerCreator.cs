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
    public List<WorkPlace> Positions;
    private float time;
    public void Create()
    {
        if (WorkerCreated < MaxCount)
        {
            var worker = Instantiate(WorkerPrefab, Positions[WorkerCreated].Position.position, Quaternion.identity);
            Application.GetInstance().GameSessionData.AIWorkers.Add(worker);
            WorkerCreated++;
        }
        
    }
}
