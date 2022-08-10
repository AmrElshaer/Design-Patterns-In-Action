namespace Design_patterns_in_action.Behavioral
{
    public class Strategy
    {
        interface ISortStrategy
        {
            List<int> Sort(List<int> dataset);
        }

        class BubbleSortStrategy : ISortStrategy
        {
            public List<int> Sort(List<int> dataset)
            {
                Console.WriteLine("Sorting using Bubble Sort !");
                return dataset;
            }
        }

        class QuickSortStrategy : ISortStrategy
        {
            public List<int> Sort(List<int> dataset)
            {
                Console.WriteLine("Sorting using Quick Sort !");
                return dataset;
            }
        }
        class Sorter
        {
            private readonly ISortStrategy mSorter;

            public Sorter(ISortStrategy sorter)
            {
                mSorter = sorter;
            }

            public List<int> Sort(List<int> unSortedList)
            {
                return mSorter.Sort(unSortedList);
            }
        }
    }
}
