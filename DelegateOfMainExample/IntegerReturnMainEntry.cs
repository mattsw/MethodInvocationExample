namespace DelegateOfMainExample
{
    public class IntegerReturnMainEntry
    {
        public static bool HasRun { get; set; }

        public static int Main(string[] args)
        {
            HasRun = true;
            return 0;
        }

        public static int Main()
        {
            HasRun = true;
            return 0;
        }
    }
}
