using System.Collections.Generic;
using UnityEngine;

public class DailyTasksPresenter : MonoBehaviour
{
    public static void CheckUsedBaffForTask(int _numberBaff)
    {
        List<DailyTasksInfoValue> _todayTasks = NewDayEventModel._instance._tasksOnToday;
        for (int i = 0; i < _todayTasks.Count; i++)
        {
            if (_todayTasks[i]._typeTaskEnum == TypeTask.UseBaff && _todayTasks[i]._numberUseBaff == _numberBaff) _todayTasks[i].SaveProgressTask(i, 1);
        }
    }

    public static void CheckCreateForTask(int _objectCreateLevel)
    {
        List<DailyTasksInfoValue> _todayTasks = NewDayEventModel._instance._tasksOnToday;
        for (int i = 0; i < _todayTasks.Count; i++)
        {
            if (_todayTasks[i]._typeTaskEnum == TypeTask.Create && _todayTasks[i]._objectLevel == _objectCreateLevel) _todayTasks[i].SaveProgressTask(i, 1);
        }
    }

    public static void CheckClickForTask()
    {
        List<DailyTasksInfoValue> _todayTasks = NewDayEventModel._instance._tasksOnToday;
        for (int i = 0; i < _todayTasks.Count; i++)
        {
            if (_todayTasks[i]._typeTaskEnum == TypeTask.Click) _todayTasks[i].SaveProgressTask(i, 1);
        }
    }
}