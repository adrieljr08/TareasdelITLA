namespace paroimpar
{

    internal class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Ingrese un numero: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            if (numero % 2 == 0)
            {
                Console.WriteLine(" El numero es par");
            }
            else
            {
                Console.WriteLine(" El numero es impar");
            }

            Console.ReadLine();
        }

    }
}