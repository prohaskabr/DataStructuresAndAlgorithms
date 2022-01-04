using Trees;

namespace TreeViewer.Console
{
    internal class ConsoleOutputText : IOutputText
    {
        public void Write(string text)
        {
            System.Console.WriteLine(text);
        }

        public void Write(int value)
        {
            System.Console.WriteLine(value);
        }
    }
}
