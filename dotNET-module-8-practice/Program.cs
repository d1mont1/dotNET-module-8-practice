using System;
using ClassLibrary;

namespace dotNET_module_8_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача №1
            Console.WriteLine("Задача №1");

            RangeOfArray array = new RangeOfArray(6, 10);

            array[6] = 42;
            array[7] = 23;
            array[8] = 15;
            array[9] = 56;
            array[10] = 77;

            for(int i=6; i<=10; i++)
            {
                Console.WriteLine($"array[{i}] = {array[i]}");
            }

            //Задача №2
            Console.WriteLine("Задача №2");

            Supermarket supermarket = new Supermarket();

            Console.WriteLine("Добро пожаловать в продуктовый супермаркет!");
            Console.WriteLine("Введите продукты (название и цену) или введите 'завершить', чтобы закончить покупки.");

            while (true)
            {
                Console.Write("Введите название продукта (или 'завершить'): ");
                string productName = Console.ReadLine();

                if (productName.ToLower() == "завершить")
                    break;

                Console.Write("Введите цену продукта: ");
                double productPrice = double.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                supermarket.AddProduct(product);
            }

            Console.Write("Введите время покупки (часы): ");
            int purchaseHour = int.Parse(Console.ReadLine());

            DateTime purchaseTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, purchaseHour, 0, 0);

            supermarket.ApplyDiscount(purchaseTime);
            double totalAmount = supermarket.CalculateTotal();

            Console.WriteLine("Итоговая сумма: " + totalAmount.ToString("C"));
            Console.WriteLine("Спасибо за покупки!");

            //Задача №3
            Console.WriteLine("Задача №3");

            // Данные о продажах за последние 5 месяцев
            double[] sales = { 120, 140, 160, 180, 200 };

            // Номера месяцев (1, 2, 3, 4, 5)
            int[] months = { 1, 2, 3, 4, 5 };

            // Найдем суммы продаж и суммы произведений месяцев и продаж
            int n = sales.Length;
            double sumSales = 0;
            double sumMonth = 0;
            double sumMonthSales = 0;

            for (int i = 0; i < n; i++)
            {
                sumSales += sales[i];
                sumMonth += months[i];
                sumMonthSales += months[i] * sales[i];
            }

            // Рассчитаем коэффициенты линейной регрессии (a и b)
            double a = (n * sumMonthSales - sumMonth * sumSales) / (n * sumMonth * sumMonth - sumMonth * sumMonth);
            double b = (sumSales - a * sumMonth) / n;

            // Прогнозируем продажи на следующие 3 месяца (6, 7, 8)
            for (int i = 6; i <= 8; i++)
            {
                double forecast = a * i + b;
                Console.WriteLine($"Прогноз продаж на месяц {i}: {forecast:F2}");
            }
        }
    }
}
