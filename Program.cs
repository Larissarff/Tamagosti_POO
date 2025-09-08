using Tamagosti.TamagostiModel;

class Program
{
    static void Main(string[] args)
    {
        TamagostiModel tamagostiUm = new TamagostiModel
        {
            Id = 1,
            Name = "LariTama"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("     (o_o)     ");
            Console.WriteLine("    /(   )\\    ");
            Console.WriteLine("     /   \\     ");
            Console.WriteLine(" Tamagosti - " + tamagostiUm.Name);
            Console.WriteLine("----------------------------------");
            Console.WriteLine($" Felicidade: {tamagostiUm.Felicidade}");
            Console.WriteLine($" Saciedade: {tamagostiUm.Saciedade}");
            Console.WriteLine($" Sono: {tamagostiUm.Energia}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Escolha uma ação:");
            Console.WriteLine("1 - Brincar");
            Console.WriteLine("2 - Alimentar");
            Console.WriteLine("3 - Dormir");
            Console.WriteLine("0 - Sair");

            string? opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.Write("Digite quanto você quer brincar: ");
                    if (int.TryParse(Console.ReadLine(), out int qtdBrincar))
                        tamagostiUm.Brincar(tamagostiUm, qtdBrincar);
                    else
                        Console.WriteLine("Valor inválido!");
                    break;

                case "2":
                    Console.Write("Digite a quantidade de comida: ");
                    if (int.TryParse(Console.ReadLine(), out int qtdComida))
                        tamagostiUm.Alimentar(tamagostiUm, qtdComida);
                    else
                        Console.WriteLine("Valor inválido!");
                    break;

                case "3":
                    Console.Write("Digite o tempo de sono: ");
                    if (int.TryParse(Console.ReadLine(), out int qtdSono))
                        tamagostiUm.Dormir(tamagostiUm, qtdSono);
                    else
                        Console.WriteLine("Valor inválido!");
                    break;

                case "0":
                    Console.WriteLine("Até logo! 👋");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (tamagostiUm.Energia == 0 || tamagostiUm.Saciedade == 0 || tamagostiUm.Felicidade == 0)
            {
                Console.WriteLine("Você perdeu, seu bichinho morreu!");
            }
            NormalizarValores(tamagostiUm);

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void NormalizarValores(TamagostiModel tama)
    {
        tama.GetType()
            .GetProperties()
            .Where(p => p.PropertyType == typeof(int) && p.CanRead)
            .ToList()
            .ForEach(prop =>
            {
                int valor = (int)prop.GetValue(tama)!;
                if (valor < 0) prop.SetValue(tama, 0);
                if (valor > 100) prop.SetValue(tama, 100);
            });
    }
}
