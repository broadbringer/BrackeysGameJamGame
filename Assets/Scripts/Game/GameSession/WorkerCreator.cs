using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Workers;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class WorkerCreator : MonoBehaviour
{
    public Worker WorkerPrefab;

    private float time;
    public Transform Position;
    public void Create()
    {
        var worker = Instantiate(WorkerPrefab, Position.position, Quaternion.identity);
        Application.GetInstance().GameSessionData.AIWorkers.Add(worker);
    }
}
