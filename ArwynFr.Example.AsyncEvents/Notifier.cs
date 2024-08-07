namespace ArwynFr.Example.AsyncEvents;

public class Notifier
{
    public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e);
    public event AsyncEventHandler<PriceUpdated> PriceUpdate = null!;

    internal async Task Insert(int id, decimal price)
    {
        await Task.WhenAll(PriceUpdate.GetInvocationList()
            .Select(_ => _.DynamicInvoke(this, new PriceUpdated(id, price)))
            .OfType<Task>());
    }
}