using System;

namespace rock_climber
{
    class Way
    {
        int height;
        int height_three;
        int duration;
        Random random = new();

        public Way()
        {
            Console.WriteLine("Введите максимальную высоту возвышенности которую скалолаз сможет преодолеть:");
            try
            {
                height = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка");
                height = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите высоту перепада трех ближайших препятствий:");
            try
            {
                height_three = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка");
                height_three = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите продолжительность маршрута:");
            try
            {
                duration = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка");
                duration = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void _Way()
        {
            int[] Way = new int[height_three];
            Way[0] = random.Next(0, Math.Min(height + 1, duration + 1));
            Way[1] = random.Next(0, Math.Min(height + 1, Way[0] + duration));
            Console.Write(Way[0]);
            Console.Write(Way[1]);

            for (int count = 2; count < height_three; count++)
            {
                Way[count] = nextTop(Math.Max(Way[count - 1], Way[count - 2]), Math.Min(Way[count - 1], Way[count - 2]));
                Console.Write(Way[count]);
            }

            Console.WriteLine();
            int maxNumber = 0;

            foreach (int element in Way)
            {
                if (element > maxNumber)
                {
                    maxNumber = element;
                }
            }

            for (int height = maxNumber; height > 0; height--)
            {
                for (int element = 0; element < height_three; element++)
                {
                    if (Way[element] == height)
                    {
                        Console.Write("*");
                        Way[element]--;
                    }
                    else if (Way[element] == 0 && height == 1)
                    {
                        Console.Write("_");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public int nextTop(int max, int min)
        {
            int a = max - min;
            int minTop = min - (duration - a);
            if (minTop < 0)
            {
                minTop = 0;
            }
            int maxTop = max + (duration - a);
            if (maxTop > height)
            {
                maxTop = height;
            }
            int Top = random.Next(minTop, maxTop + 1);
            return Top;
        }
    }
}
