using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Workers;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class WorkerCreator : MonoBehaviour
{
    public Worker WorkerPrefab;

    private float time;
    
    public void Create()
    {
        var worker = Instantiate(WorkerPrefab, new Vector3(), Quaternion.identity);
        Application.GetInstance().GameSessionData.AIWorkers.Add(worker);
    }
}
