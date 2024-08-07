using ArwynFr.Example.AsyncEvents;

var notifier = new Notifier();
var observer1 = new Observer(ConsoleColor.Green, 3000);
var observer2 = new Observer(ConsoleColor.Red, 1000);

notifier.PriceUpdate += observer1.OnPriceUpdated;
notifier.PriceUpdate += observer2.OnPriceUpdated;

await notifier.Insert(1, 10);

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Complete");
