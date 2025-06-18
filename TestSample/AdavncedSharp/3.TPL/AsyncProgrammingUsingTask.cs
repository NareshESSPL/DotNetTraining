using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class AsyncProgrammingUsingTask
    {
        public void LongRunningProcess()
        {
            Thread.Sleep(1000);
        }
        public void LongRunningProcess2()
        {
            Thread.Sleep(1000);
        }
        public void LongRunningProcess3()
        {
            Thread.Sleep(1000);
        }
        public void LongRunningProcess4()
        {
            Thread.Sleep(1000);
        }

        public void Test1()
        {
            //Start the task asynchronously
            var task = new Task(() => LongRunningProcess());
            task.Start();

            //Start the task synchronously
            var task2 = new Task(() => LongRunningProcess2());
            task2.RunSynchronously();

            //Use cancellation token to cancel the task
            //as the task createa separate thread, it can't be stopped if from the current method
            //Henace we need a cancellation token
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(5000);
            var task3 = new Task(() => LongRunningProcess3(), cancellationTokenSource.Token);
            task3.Start();
                        
            Task.Run(() => LongRunningProcess4());
        }


        public void TestContinueAndWait()
        {
            Task<int> t = new Task<int>(() => { return 43; });
            t.Start();

            //output of first task will be input of second task
            Task<int> t2 = t.ContinueWith<int>((i) => { return i.Result * 2; });

            Console.WriteLine("i = {0}", t2.Result.ToString());

            //Current thread or method will till the task is completed
            t2.Wait();

            if(t2.IsCompleted)
                Console.WriteLine("task completed");
        }

        public void TestTaskFactory()
        {
            Task[] tasks = new Task[2];
            String[] files = null;
            String[] dirs = null;
            String docsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            tasks[0] = Task.Factory.StartNew(() => files = Directory.GetFiles(docsDirectory));
            tasks[1] = Task.Factory.StartNew(() => dirs = Directory.GetDirectories(docsDirectory));

            Task.Factory.ContinueWhenAll(tasks, completedTasks => {
                Console.WriteLine("{0} contains: ", docsDirectory);
                Console.WriteLine("   {0} subdirectories", dirs.Length);
                Console.WriteLine("   {0} files", files.Length);
            });
        }
    }
}
