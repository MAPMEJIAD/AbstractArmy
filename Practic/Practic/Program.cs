using System.Data;
using Practic.Interfaces;
using Practic.Models;

int GetKeyIntValue()
{
    while (true)
    {
        ConsoleKeyInfo userInput = Console.ReadKey();
        if (char.IsDigit(userInput.KeyChar))
        {
            return int.Parse(userInput.KeyChar.ToString());
        }
    }
}

char GetKeyValue()
{
    while (true)
    {
        ConsoleKeyInfo userInput = Console.ReadKey();
        if (char.IsLetter(userInput.KeyChar))
        {
            return userInput.KeyChar;
        }
    }
}

int GetIntValue()
{
    while (true)
    {
        string amountString = Console.ReadLine();
        if (int.TryParse(amountString, out int amount))
        {
            return amount;
        }
    }
}

void EditTroopMenu()
{
    Console.Clear();
    Console.WriteLine("[1]. Выбрать тип армии");
    Console.WriteLine("[2]. Поставить командира в армию");
    Console.WriteLine("[3]. Добавить война в армию");
    Console.WriteLine("[4]. Закончить редактирование взвода");
    Console.WriteLine("[5]. Атаковать");
    Console.WriteLine("[6]. Защищаться");
}

void ArmyTypesMenu()
{
    Console.Clear();
    Console.WriteLine("[1]. Артиллерия");
    Console.WriteLine("[2]. Кавалерия");
    Console.WriteLine("[3]. Пехота");
}

void MainMenu()
{
    Console.Clear();
    Console.WriteLine("[1]. Создать взвод");
    Console.WriteLine("[2]. Отредактировать взвод");
    Console.WriteLine("[3]. Текущие взводы");
    Console.WriteLine("[4]. Сражения со взводами");
}

List<Troop> troops = new List<Troop>();
Troop currentTroop = null;
IArmyFactory currentFactory = null;
bool isFinished;
int troopNumberCounter = 1;

while (true)
{
    MainMenu();
    isFinished = false;
    switch (GetKeyIntValue())
    {
        case 1:
            currentTroop = new Troop(troopNumberCounter++);
            Console.Clear();
            Console.WriteLine("Взвод успешно создан!");
            Console.ReadKey();
            Console.Clear();
            break;
        case 2:
            if (currentTroop is null)
            {
                currentTroop = new Troop(troopNumberCounter++);
            }
            while (!isFinished)
            {
                EditTroopMenu();
                switch (GetKeyIntValue())
                {
                    case 1:
                        ArmyTypesMenu();
                        switch (GetKeyIntValue())
                        {
                            case 1:
                                currentFactory = new ArtilleryFactory();
                                Console.Clear();
                                Console.WriteLine("Артиллерийская армия выбрана.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 2:
                                currentFactory = new CavalryFactory();
                                Console.Clear();
                                Console.WriteLine("Кавалерийская армия выбрана.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 3:
                                currentFactory = new InfantryFactory();
                                Console.Clear();
                                Console.WriteLine("Пехотная армия выбрана.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }

                        break;
                    case 2:
                        if (currentFactory is null)
                        {
                            Console.Clear();
                            Console.WriteLine("Тип армии не выбран");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        currentTroop.SetCommander(currentFactory.CreateCommander());
                        Console.Clear();
                        Console.WriteLine("Командир успешно добавлен!");
                        Console.ReadKey();
                        Console.Clear();
                        
                        break;
                    case 3:
                        if (currentFactory is null)
                        {
                            Console.Clear();
                            Console.WriteLine("Тип армии не выбран");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        currentTroop.AddUnit(currentFactory.CreateUnit());
                        Console.Clear();
                        Console.WriteLine("Воин успешно добавлен!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        troops.Add(currentTroop);
                        currentTroop = null;
                        isFinished = true;
                        break;
                    case 5:
                        if (currentTroop.Commander is not null)
                        {
                            Console.Clear();
                            currentTroop.Commander.OrderToAttack();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 6:
                        if (currentTroop.Commander is not null)
                        {
                            Console.Clear();
                            currentTroop.Commander.OrderToDefend();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
            }
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Number\tUnit count");
            foreach (var troop in troops)
            {
                Console.WriteLine($"{troop.Number}\t{troop.Units.Count}");
            }

            Console.ReadKey();
            Console.Clear();
            break;
        case 4:
            Console.Clear();
            foreach (var troop in troops)
            {
                foreach (var anotherTroop in troops)
                {
                    if (troop == anotherTroop) continue;
                    var winner = troop.Fight(anotherTroop) ? troop : anotherTroop;
                    var looser = troop.Fight(anotherTroop) ? anotherTroop : troop;
                    Console.WriteLine($"Troop {winner.Number} won {looser.Number}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            break;
    }
}

