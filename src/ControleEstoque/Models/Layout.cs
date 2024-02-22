namespace ControleEstoque.Models
{
    public class Layout
    {
        private static List<Medicamento> medicamentos = new();
        private static int opcao = 0;

        private static void Tela()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("\nMundial Pharma - CONTROLE DE ESTOQUE\n");
        }

        private static void Voltar(Login login)
        {
            Console.WriteLine("\nDigite [ 1 ] para voltar\n");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Menu(login);
            }
        }

        public static void TelaPrincipal()
        {
            try
            {
                Tela();

                Console.WriteLine("Digite uma opção:\n");
                Console.WriteLine("[1] - Login");
                Console.WriteLine("[2] - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        TelaPrincipal();
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                TelaPrincipal();
            }
        }

        private static void Login()
        {
            Tela();
            Login login = new();

            Console.WriteLine("Digite a Matrícula:");
            login.Matricula = Console.ReadLine();
            if (string.IsNullOrEmpty(login.Matricula)) throw new Exception("Campo [Matrícula] é obrigatório");

            Console.WriteLine("Digite a Senha:");
            login.Senha = Console.ReadLine();
            if (string.IsNullOrEmpty(login.Senha)) throw new Exception("Campo [Senha] é obrigatório");

            if (login.Matricula == "67544" && login.Senha == "senha#888")
            {
                Console.WriteLine("Login efetuado com sucesso.");

                Thread.Sleep(2000);
                Menu(login);
            }
            else
            {
                Console.WriteLine("Matricula/Senha inválido, verifique os dados e tente novamente");

                Thread.Sleep(2000);
                TelaPrincipal();
            }
        }

        private static void Menu(Login login)
        {
            try
            {
                Tela();

                Console.WriteLine("Digite uma opção:\n");
                Console.WriteLine("[1] - Cadastrar");
                Console.WriteLine("[2] - Listar");
                Console.WriteLine("[3] - Buscar");
                Console.WriteLine("[4] - Recebimento");
                Console.WriteLine("[5] - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Cadastrar(login);
                        break;
                    case 2:
                        Listar(login);
                        break;
                    case 3:
                        Buscar(login);
                        break;
                    case 4:
                        Recebimento(login);
                        break;
                    case 5:
                        TelaPrincipal();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);
                        Menu(login);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Menu(login);
            }
        }

        private static void Cadastrar(Login login)
        {
            Tela();
            Console.WriteLine("CADASTRAR MEDICAMENTOS\n");

            Console.WriteLine("Nome do Medicamento:");
            string nomeMedicamento = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(nomeMedicamento)) throw new Exception("Campo obrigatório");

            Console.WriteLine("Princípio Ativo:");
            string principioAtivo = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(principioAtivo)) throw new Exception("Campo obrigatório");

            Console.WriteLine("Fabricante:");
            string fabricante = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(fabricante)) throw new Exception("Campo obrigatório");

            Console.WriteLine("Código de Barra:");
            string codigoBarra = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(codigoBarra)) throw new Exception("Campo obrigatório");
            if (CodigoJaCadastrado(codigoBarra)) throw new Exception("Código de Barra já cadastrado");

            Console.WriteLine("Código Interno:");
            string codigoInterno = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(codigoInterno)) throw new Exception("Campo obrigatório");

            Medicamento medicamento = new();

            medicamento.Nome = nomeMedicamento;
            medicamento.PricipioAtivo = principioAtivo;
            medicamento.Fabricante = fabricante;
            medicamento.CodigoBarra = codigoBarra;
            medicamento.CodigoInterno = codigoInterno;


            medicamentos.Add(medicamento);

            Console.WriteLine("\nMedicamento cadastrado com sucesso");

            Voltar(login);
        }

        private static bool CodigoJaCadastrado(string codigoBarra)
        {
            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento.CodigoBarra == codigoBarra)
                {
                    return true;
                }
            }

            return false;
        }

        private static void Listar(Login login)
        {
            Tela();
            Console.WriteLine("LISTAR MEDICAMENTOS CADASTRADOS\n");

            if (medicamentos.Count <= 0)
            {
                Console.WriteLine("Não há medicamentos cadastrado!");
            }
            else
            {
                foreach (var medicamento in medicamentos)
                {
                    Console.WriteLine($"Nome do Medicamento: {medicamento.Nome}");
                    Console.WriteLine($"Princípio Ativo: {medicamento.PricipioAtivo}");
                    Console.WriteLine($"Fabricante: {medicamento.Fabricante}");
                    Console.WriteLine($"Código de Barra: {medicamento.CodigoBarra}");
                    Console.WriteLine($"Código Interno: {medicamento.CodigoInterno}");
                    Console.WriteLine($"Quantidade: {medicamento.Quantidade}\n");
                }
            }

            Voltar(login);
        }

        private static void Buscar(Login login)
        {
            Tela();
            Console.WriteLine("BUSCAR MEDICAMENTO PELO CÓDIGO DE BARRA\n");

            Console.WriteLine("Digite o Código de Barra:");
            string codigoBarra = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(codigoBarra)) throw new Exception("Campo obrigatório");

            var buscarMedicamento = medicamentos.Where(x => x.CodigoBarra == codigoBarra).FirstOrDefault();

            if (buscarMedicamento == null)
            {
                throw new Exception("Medicamento não encontrado");
            }

            Console.WriteLine($"\nNome do Medicamento: {buscarMedicamento.Nome}");
            Console.WriteLine($"Princípio Ativo: {buscarMedicamento.PricipioAtivo}");
            Console.WriteLine($"Fabricante: {buscarMedicamento.Fabricante}");
            Console.WriteLine($"Código de Barra: {buscarMedicamento.CodigoBarra}");
            Console.WriteLine($"Código Interno: {buscarMedicamento.CodigoInterno}");
            Console.WriteLine($"Quantidade: {buscarMedicamento.Quantidade}");

            Voltar(login);
        }

        private static void Recebimento(Login login)
        {
            Tela();
            Console.WriteLine("RECEBIMENTO DE MEDICAMENTOS\n");
            Medicamento medicamento = new();

            Console.WriteLine("Digite o Código de Barra:");
            string codigoBarra = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(codigoBarra)) throw new Exception("Campo obrigatório");

            var codigoMedicamento = medicamentos.Where(x => x.CodigoBarra == codigoBarra).FirstOrDefault();

            if (codigoMedicamento == null)
            {
                throw new Exception("Medicamento com este código de barras ainda não foi cadastrado. Cadastre-o na opção [CADASTRAR] e retorne para lançar o recebimento");
            }

            Console.WriteLine("Digite a Quantidade:");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade > 0)
            {
                medicamento.Receber(codigoMedicamento, quantidade);

                Console.WriteLine("\nRecebimento lançado com sucesso.");
            }

            Voltar(login);
        }
    }
}
