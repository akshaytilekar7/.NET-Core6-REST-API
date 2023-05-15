using CourseLibrary.API;

var builder = WebApplication.CreateBuilder(args);

// Throttle the thread pool (set available threads to amount of processors)
ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();


// for demo purposes, delete the database & migrate on startup so 
// we can start with a clean slate
await app.ResetDatabaseAsync();

// run the app
app.Run();
