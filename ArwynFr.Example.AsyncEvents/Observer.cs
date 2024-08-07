namespace ArwynFr.Example.AsyncEvents;

public class Observer(ConsoleColor color, int duration)
{
    private readonly ConsoleColor color = color;
    private readonly int duration = duration;

    internal async Task OnPriceUpdated(object sender, PriceUpdated e)
    {
        Console.ForegroundColor = color;
        Console.WriteLine("await");

        await Task.Delay(duration).ConfigureAwait(false);

        // other instances could have changed it while this one awaits
        Console.ForegroundColor = color;
        Console.WriteLine($"Price updated : {e.id}{e.price}");
    }
}