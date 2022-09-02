namespace Design_patterns_in_action.Behavioral
{
    // is very similar to state design pattern
    public interface IFiliter
    {
        void ApplyFiliter();
    }

    class BWFiliter : IFiliter
    {
        public void ApplyFiliter()
        {
            Console.WriteLine("BW Filiter");
        }
    }
    class HighContrastFiliter : IFiliter
    {
        public void ApplyFiliter()
        {
            Console.WriteLine("High Contrast Filiter");
        }
    }

    public class ImageStorage
    {
        private readonly IFiliter mFiliter;
        private readonly ICompression mCompression;

        public ImageStorage(IFiliter filiter, ICompression compression)
        {
            mFiliter = filiter;
            mCompression = compression;
        }
        public void Store()
        {
            mFiliter.ApplyFiliter();
            mCompression.CompressionAlgo();
        }
    }
    public interface ICompression
    {
        void CompressionAlgo();
    }

    class JPEGCompression : ICompression
    {
        public void CompressionAlgo()
        {
            Console.WriteLine("JPEG compression algo");
        }
    }

    class PngCompression : ICompression
    {
        public void CompressionAlgo()
        {
            Console.WriteLine("Png compression algo");
        }
    }
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
