using System.Collections.Generic;
using UnityEngine;

public class DailyTasksPresenter : MonoBehaviour
{
    public static void CheckUsedBaffForTask(int _numberBaff)
    {
        List<DailyTasksInfoValue> todayTasks = NewDayEventModel._instance.tasksOnToday;
        for (int i = 0; i < todayTasks.Count; i++)
        {
            if (todayTasks[i]._typeTaskEnum == TypeTask.UseBaff && todayTasks[i]._numberUseBaff == _numberBaff) todayTasks[i].SaveProgressTask(i, 1);
        }
    }

    public static void CheckCreateForTask(int _objectCreateLevel)
    {
        List<DailyTasksInfoValue> todayTasks = NewDayEventModel._instance.tasksOnToday;
        for (int i = 0; i < todayTasks.Count; i++)
        {
            if (todayTasks[i]._typeTaskEnum == TypeTask.Create && todayTasks[i]._objectLevel == _objectCreateLevel) todayTasks[i].SaveProgressTask(i, 1);
        }
    }

    public static void CheckClickForTask()
    {
        List<DailyTasksInfoValue> todayTasks = NewDayEventModel._instance.tasksOnToday;
        for (int i = 0; i < todayTasks.Count; i++)
        {
            if (todayTasks[i]._typeTaskEnum == TypeTask.Click) todayTasks[i].SaveProgressTask(i, 1);
        }
    }
}