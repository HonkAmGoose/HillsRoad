namespace PlayerClasses
{
    internal class ComputerPlayer : Player
    {
        protected override int ChooseCard(int[] ints, string[] options)
        {
            Random rnd = new();
            int num = rnd.Next(ints.Length);

            return ints[num];
        }

        protected override ConsoleColor ChooseColour()
        {
            return colours[0];
        }

        protected override string ChooseName()
        {
            string name = names[0];
            Console.WriteLine($"Computer player {ID} is called {name}");
            return name;
        }
    }
}
