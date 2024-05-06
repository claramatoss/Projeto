using Projeto;
List<CCorrente> contas = new List<CCorrente>();
string? i;
int op;
do
{
    op = Menu();
    switch (op)
    {
        case 1:
            AcessoAdm();
            break;
        case 2:
            CaixaEletronico();
            break;
        case 3:
            break;
        default:
            Console.WriteLine("Opção inválida, redigite!\n");
            break;
    }

} while (op != 3);
int Menu()
{
    Console.WriteLine("1. Acesso Administrativo");
    Console.WriteLine("2. Caixa Eletrônico");
    Console.WriteLine("3. Sair");
    Console.Write("Digite sua opção: ");

    i = Console.ReadLine();
    Int32.TryParse(i, out op);
    return op;
}
void AcessoAdm()
{
    do
    {
        Console.WriteLine("1. Cadastro de Conta Corrente");
        Console.WriteLine("2. Mostrar os saldos de todas as contas");
        Console.WriteLine("3. Excluir uma conta específica");
        Console.WriteLine("4. Voltar");
        Console.Write("Digite sua opção: ");

        i = Console.ReadLine();
        Int32.TryParse(i, out op);

        switch (op)
        {
            case 1:
                CadastrarConta();
                break;
            case 2:
                MostrarSaldos();
                break;
            case 3:
                ExcluirConta();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Opção inválida, redigite!\n");
                break;
        }
    } while (op != 4);
}
void CadastrarConta()
{
    double limite;

    Console.Write("Digite o número da conta:");
    string num = Console.ReadLine();

    Console.Write("Digite o limite da conta:");
    i = Console.ReadLine();
    Double.TryParse(i, out limite);

    contas.Add(new CCorrente(num, limite));
    Console.WriteLine("Conta cadastrada com sucesso!\n");
}
void MostrarSaldos()
{
    foreach (var conta in contas)
    {
        Console.WriteLine(conta.numero + " - " + conta.saldo);
    }
}
void ExcluirConta()
{
    Console.Write("Digite o número da conta: ");
    string num = Console.ReadLine();

    CCorrente conta = contas.Find(c => c.numero == num); 
    conta.status = false;
    Console.WriteLine("Conta excluída com sucesso! \n");
}
void CaixaEletronico()
{
    double valor;
    Console.Write("Digite o número da conta: ");
    string num = Console.ReadLine();

    CCorrente conta = contas.Find(c => c.numero == num);
    if (conta != null)
    {
        do
        {
            Console.WriteLine("1. Saque");
            Console.WriteLine("2. Depósito");
            Console.WriteLine("3. Transferência");
            Console.WriteLine("4. Voltar");
            Console.Write("Digite sua opção: ");
            i = Console.ReadLine();
            Int32.TryParse(i, out op);
            switch (op)
            {
                case 1:
                    Console.Write("Digite o valor: ");
                    i = Console.ReadLine();
                    Double.TryParse(i, out valor);
                    if (conta.Sacar(valor))
                    {
                        Console.WriteLine("Saque realizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível realizar o saque!");
                    }
                    break;
                case 2:
                    Console.Write("Digite o valor: ");
                    i = Console.ReadLine();
                    Double.TryParse(i, out valor);
                    if (conta.Depositar(valor))
                    {
                        Console.WriteLine("Depósito realizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível realizar o depósito!");
                    }
                    break;
                case 3:
                    Console.Write("Digite o número da conta destino: ");
                    string destino = Console.ReadLine();
                    CCorrente ContaDestino = contas.Find(c => c.numero == destino);
                    if (ContaDestino != null)
                    {
                        Console.Write("Digite o valor da transferência: ");
                        i = Console.ReadLine();
                        Double.TryParse(i, out valor);
                        if (conta.Transferir(ContaDestino, valor))
                            Console.WriteLine("Transferência realizada com sucesso!");
                        else
                            Console.WriteLine("Não foi possível realizar a transferência!");
                    }
                    else
                    {
                        Console.WriteLine("Conta destino não encontrada!");
                    }
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Opção inválida, redigite!");
                    break;
            }
        }while (op != 4);
    }
    else
    {
        Console.WriteLine("Conta não encontrada!");
    }
}
