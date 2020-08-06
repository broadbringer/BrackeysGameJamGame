using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorker
{
    float Productivity { get; set; }
    float CurrentCassetDurabillity { get; set; }
    Tool WorkItem { get; set; }
    void SetWorkItem(Tool item);
    void SpinCassette();
}
