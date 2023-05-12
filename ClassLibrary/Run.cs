using Microsoft.EntityFrameworkCore;

namespace ClassLibrary;

public static class Run
{
    public static void DoIt()
    {
        var context = new Context(new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase("InMemoryDbTestName")
            .EnableSensitiveDataLogging(true)
            .Options);

        var testDate = new DateTimeOffset(2000, 1, 1, 2, 0, 0, default);
        context.Add(new Entity() {Modifified = testDate});
        context.SaveChanges();
        
        const string date = "2000-01-01T04:00:00.000+02:00";
        var t = context.Set<Entity>().Where(e => e.Modifified == DateTimeOffset.Parse(date));
        Console.WriteLine(testDate == DateTimeOffset.Parse(date));
        Console.WriteLine(t.ToList().Count);
    }
}