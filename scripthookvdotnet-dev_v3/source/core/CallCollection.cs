using System.Collections.Generic;

namespace GTA.Native
{
    public class CallCollection
    {
        private List<Function.NativeTask> taskList;

        public CallCollection()
        {
            taskList = new List<Function.NativeTask>();
        }

        public void Call(Hash hash, params InputArgument[] args)
        {
            var task = new Function.NativeTask();
            task.Hash = (ulong)hash;
            task.Arguments = args;

            taskList.Add(task);
        }

        public int Execute()
        {
            var taskColl = new Function.NativeTaskCollection();
            taskColl._tasks = new Function.NativeTask[taskList.Count];

            for (int i = 0; i < taskList.Count; i++)
            {
                taskColl._tasks[i] = taskList[i];
            }

            ScriptDomain.CurrentDomain.ExecuteTask(taskColl);
            return taskList.Count;
        }
    }
}