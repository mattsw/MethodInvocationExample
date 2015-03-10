namespace DelegateOfMainExample
{

    public class VoidReturnMainEntry
    {
        public static bool HasRun { get; set; }
        public static void Main(string[] args)
        {
            HasRun = true;
        }

        public static void Main()
        {
            HasRun = true;
        }
    }
}
