using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Models;

namespace PotionProject
{
    class Program
    {
        private static int lastPotionID = 9;
        private static Cupboard cupboard = new Cupboard() { Id = 1 };

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    System.Console.WriteLine("Главное меню:");
                    System.Console.WriteLine("1 - перейти к списку зелий");
                    System.Console.WriteLine("2 - перейти в шкаф (режим админа)");
                    System.Console.WriteLine("Нажмите любую другую клавишу чтобы выйти из программы");
                    string command = System.Console.ReadLine();
                    if (command == "1")
                    {
                        InformationalMode();
                    }
                    else if (command == "2")
                    {
                        AdminMode();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    PrintExceptionMessage(ex.Message);
                }
            }
        }

        private static void AdminMode()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Шкаф:");
                System.Console.WriteLine("1 - Добавить новое зелье");
                System.Console.WriteLine("2 - Посмотреть старое зелье");
                System.Console.WriteLine("Нажмите любую другую клавишу, чтобы вернуться в главное меню");
                string command = System.Console.ReadLine();
                if (command == "1")
                {
                    AddNewPotionInterface();
                }
                else if (command == "2")
                {
                    LookAtPotionInterface();
                }
                else
                {
                    break;
                }
            }
        }
        private static void LookAtPotionInterface()
        {
            WritePotions(cupboard.Potions);
            Console.WriteLine("Введите номер зелья");
            var potionId = Console.ReadLine();
            var potion = cupboard.GetPotionById(TurnStringToInt(potionId));
            OutputPotionInformation(potion);
            Console.WriteLine();
            Console.WriteLine("Что вы хотите сделать с этим зельем?");
            Console.WriteLine("1 - Изменить");
            Console.WriteLine("2 - Удалить");
            Console.WriteLine("Если вы хотите вернуться в шкаф, нажмите любую другую клавишу.");
            var command = Console.ReadLine();
            if (command == "1")
            {
                EditPotionInterface(potion.PotionID);
            }
            else if (command == "2")
            {
                DeletePotionInterface(potion.PotionID);
            }
        }
        private static void DeletePotionInterface(int potionId)
        {
            System.Console.WriteLine("Вы уверены, что хотите удалить это зелье? (Да/Нет)");
            string command = Console.ReadLine();
            if (command == "Да" ||
                command == "да" ||
                command == "д" ||
                command == "Д")
            {
                cupboard.DeletePotionById(potionId);
            }
            else
            {
                Console.Clear();
            }
        }
        private static void EditPotionInterface(int potionId)
        {
            Console.WriteLine("Введите новое название зелья или нажмите Enter, если не хотите его менять");
            string newTitle = Console.ReadLine();
            Console.WriteLine("Выберите новый эффект (Положительный - п, отрицательный - о, нейтральный - н) или нажмите Enter, если не хотите его менять");
            string newEffect = Console.ReadLine();
            Console.WriteLine("Введите новое описание зелья или нажмите Enter, если не хотите его менять");
            string newDescription = Console.ReadLine();
            cupboard.EditPotion(potionId, newTitle, newEffect, newDescription);
            OutputPotionInformation(cupboard.GetPotionById(potionId));
            Console.ReadLine();
            Console.Clear();
        }
        private static void InformationalMode()
        {
            bool isWorking = true;
            while (isWorking == true)
            {
                WritePotions(cupboard.Potions);
                string desiredPotionNumber = GetPotionNumber();
                int element = TurnStringToInt(desiredPotionNumber);
                if (element != -1)
                {
                    var potion = cupboard.Potions.ElementAt(element);
                    OutputPotionInformation(potion);
                    isWorking = ExitOrStay();
                }
                else
                {
                    isWorking = false;
                }
            }
        }
        private static void AddNewPotionInterface()
        {
            Console.Clear();
            Console.WriteLine("Введите название нового зелья.");
            string newTitle = Console.ReadLine();
            Console.WriteLine("Выберете эффект нового зелья. Положительный - нажмите п, Отрицательный - о, Нейтральный - н.");
            string newEffect = Console.ReadLine();
            Console.WriteLine("Введите описание нового зелья и нажмите enter.");
            string newDescription = Console.ReadLine();

            PotionsInformationClass newPotion = new PotionsInformationClass()
            {
                PotionID = GetNewPotionID(),
                Title = newTitle,
                Effect = GetNewEffect(newEffect),
                Description = newDescription,
            };
            cupboard.AddNewPotion(newPotion);

            Console.Clear();
            Console.WriteLine("Готово! Новое зелье:");
            OutputPotionInformation(newPotion);
            Console.WriteLine("n/Нажмите Enter, чтобы вернуться в шкаф.");
            Console.ReadLine();
        }

        private static void PrintExceptionMessage(string exMessage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            System.Console.WriteLine(exMessage);
            Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static int GetNewPotionID()
        {
            var newPotionId = ++lastPotionID;
            return newPotionId;
        }
        private static Effect GetNewEffect(string NewEffect)
        {
            if (NewEffect == "п")
            {
                return Effect.Positive;
            }
            else if (NewEffect == "о")
            {
                return Effect.Negative;
            }
            else if (NewEffect == "н")
            {
                return Effect.Neutral;
            }
            else
            {
                throw new System.Exception("Невозможный эффект.");
            }
        }
        private static bool ExitOrStay()
        {
            System.Console.WriteLine("Чтобы вернуться к списку зелий, нажмите 1. Чтобы выйти из программы, нажмите 2");
            string userCommand = System.Console.ReadLine();

            if (userCommand == "2")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static string GetPotionNumber()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Введите номер зелья, чтобы получить подробную информацию. Введите -1 чтобы вернуться в главное меню.");
            string desiredPotionNumber = System.Console.ReadLine();
            Console.Clear();

            return desiredPotionNumber;
        }

        private static void WritePotions(List<PotionsInformationClass> potionlist)
        {
            System.Console.WriteLine("Список зелий:");
            System.Console.WriteLine();

            foreach (var potion in potionlist)
            {
                Console.ForegroundColor = GetColor(potion.Effect);
                System.Console.WriteLine(potion.GetShortInfo());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static ConsoleColor GetColor(Effect effect)
        {
            if (effect == Effect.Positive)
            {
                return ConsoleColor.Green;
            }
            else if (effect == Effect.Negative)
            {
                return ConsoleColor.Red;
            }
            else
            {
                return ConsoleColor.White;
            }
        }

        static int TurnStringToInt(string MyString)
        {
            try
            {
                return int.Parse(MyString);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        static void OutputPotionInformation(PotionsInformationClass potion)
        {
            System.Console.Clear();
            Console.WriteLine(potion.GetFullInfo());
        }
    }
}