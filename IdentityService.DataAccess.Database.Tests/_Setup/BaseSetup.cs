using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Unities;

namespace IdentityService.DataAccess.Database.Tests._Setup;

[Parallelizable(scope: ParallelScope.None)]
[NonParallelizable]
[TestFixture]
[FixtureLifeCycle(LifeCycle.SingleInstance)]
public class BaseSetup
{
    
    protected IUnitOfWorkTenant UnitOfWorkTenant;
    private IGetDbConnection _getDbConnection;
    private List<TaskRunningModel> _tasks = new List<TaskRunningModel>();
    public string? _database = null;
    
    [SetUp]
    public void Setup()
    {
        CreateConnection();
    }
    
    public IUnitOfWorkTenant GetUnitOfWork(string database)

    {
        IGetDbConnection getDbConnection = new GetDbConnectionSqlite(database);
        getDbConnection.Init();
        return new UnitOfWorkTenant(getDbConnection.GetConnection());
    }
    
    public IUnityOfWorkGlobal GetUnitOfWorkGlobal(string database)

    {
        IGetDbConnection getDbConnection = new GetDbConnectionSqlite(database);
        getDbConnection.Init();
        return new UnitOfWorkGlobal(getDbConnection.GetConnectionGlobal());
    }

    private void CreateConnection()
    {
        if(_getDbConnection == null)
        {
            if(_database == null)
            {
                _getDbConnection = new GetDbConnectionSqlite();
            }
            else
            {
                
                _getDbConnection = new GetDbConnectionSqlite(_database);
            }
            _getDbConnection.Init();
            UnitOfWorkTenant = new UnitOfWorkTenant(_getDbConnection.GetConnection());
        }
    }
    
    // Create method that resolve the queue of tasks
    static TaskQueue _taskQueue = new TaskQueue();
    public void RunTasks()
    {

        foreach (var task in _tasks)
        {
            _taskQueue.Enqueue(task.Task);
            _taskQueue.Enqueue(YourTask(task));
        }
    }
    

    
    public Task YourTask(TaskRunningModel task)
    {
        return TaskUtils.WaitUntil(() =>task.IsRunning == false);
        // or as lambda
        //await TaskUtils.WaitUntil(() => condition);

        
    }
    
    
    
    [TearDown]
    public void TearDown()
    {
        _getDbConnection.Destroy();

        var task = _tasks.SingleOrDefault(x => x.IsRunning);
        if(task != null)
        {
            task.IsRunning = false;
        }
        
        
        // Tear down code goes here
    }
    
    public void TearDown_v(string database)
    {
        var getDbConnection = new GetDbConnectionSqlite(database);
        getDbConnection.Destroy();
    }
}

public class TaskRunningModel
{
    public Task Task { get; set; }
    public bool IsRunning { get; set; }
}

public static class TaskUtils
{
    public static async Task WaitUntil(Func<bool> predicate, int sleep = 50)
    {
        while (!predicate())
        {
            await Task.Delay(sleep);
        }
    }
}


public class TaskQueue
{
    private SemaphoreSlim semaphore;
    public TaskQueue()
    {
        semaphore = new SemaphoreSlim(1);
    }

    public async Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
    {
        await semaphore.WaitAsync();
        try
        {
            return await taskGenerator();
        }
        finally
        {
            semaphore.Release();
        }
    }
    public async Task Enqueue(Func<Task> taskGenerator)
    {
        await semaphore.WaitAsync();
        try
        {
            await taskGenerator();
        }
        finally
        {
            semaphore.Release();
        }
    }
    
    public async Task Enqueue(Task task)
    {
        await semaphore.WaitAsync();
        try
        {
            //create cancellation token
            var cts = new CancellationTokenSource();
            await task.WaitAsync(cts.Token);
        }
        finally
        {
            semaphore.Release();
        }
    }
}