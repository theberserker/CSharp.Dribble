using static System.Console; // importing a static class

namespace CSharp.Dribble.Exam70483.LanguageFeatures
{
    public class CSharpV7
    {
        void  A()
        {
            if (int.TryParse("1", out int i))
            {
                WriteLine("Testing the out parameter.");
            }

        }
    }
}
