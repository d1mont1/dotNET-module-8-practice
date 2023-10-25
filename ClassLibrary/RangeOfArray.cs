using System;


namespace ClassLibrary
{
    public class RangeOfArray
    {
        private int lowerBound;
        private int upperBound;
        private int[] array;

        public RangeOfArray(int lower, int upper)
        {
            if (lower > upper)
            {
                throw new ArgumentException("Нижний индекс не может быть больше верхнего.");
            }

            lowerBound = lower;
            upperBound = upper;
            array = new int[upper - lower + 1];
        }

        public int this[int index]
        {
            get
            {
                if (IsIndexValid(index))
                {
                    return array[index - lowerBound];
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс находится вне допустимого диапазона.");
                }
            }
            set
            {
                if (IsIndexValid(index))
                {
                    array[index - lowerBound] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс находится вне допустимого диапазона.");
                }
            }
        }

        private bool IsIndexValid(int index)
        {
            return index >= lowerBound && index <= upperBound;
        }
    }
}
