using System;
using System.Threading;

var choice = 0;
do
{
    Console.Clear();
    choice = Pizza.ReadChoice(choice);
    if (choice >= 1 && choice <= 3)
    {
        var pizza = Pizza.CreatePizza(choice);
        Console.WriteLine(pizza);
        Console.WriteLine("Press any key to continue");
    }
    Console.ReadKey();
} while (choice != 0);
class Pizza
{
    public virtual string Title => $"{nameof(Pizza)}";
    public virtual decimal Price => 10m;

    public override string ToString()
    {
        return $"\n{Title}" +
               $"\n\tPrice: {Price.ToString("C")}";
    }
    public static int ReadChoice(int choice)
    {
        Console.WriteLine("Today's Menu");
        Console.WriteLine("------------");
        Console.WriteLine("1. Chicken");
        Console.WriteLine("2. Vegeterian");
        Console.WriteLine("3. Mexican");
        Console.WriteLine("what is your order: ");
        if (int.TryParse(Console.ReadLine(), out int ch))
        {
            choice = ch;
        }

        return choice;
    }

    public static Pizza CreatePizza(int choice)
    {
        Pizza pizza = null;
        switch (choice)
        {
            case 1:
                pizza = new Chicken();
                break;
            case 2:
                pizza = new Vegeterian();
                break;
            case 3:
                pizza = new Mexican();
                break;
            default:
                break;
        }
        return pizza;
    }
}
class Mexican : Pizza
{
    public override string Title => $"{base.Title} {nameof(Mexican)}"; // Pizza Cheese
    public override decimal Price => base.Price + 3m;
}
class Chicken : Pizza
{
    public override string Title => $"{base.Title} {nameof(Chicken)}"; // Pizza Chicken
    public override decimal Price => base.Price + 6m;
}
class Vegeterian : Pizza
{
    public override string Title => $"{base.Title} {nameof(Vegeterian)}"; // Pizza Vegeterian
    public override decimal Price => base.Price + 4m;
}