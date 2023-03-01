using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace Sprint3_Ecommerce
{
    public class Produtos : Categoria
    {
        public string NomeDoProduto { get; set; }  // 128char - alfanúmerico - 
        public string DescricaoDoProduto { get; set; } //512char / alfanúmerico - 
        public decimal Peso { get; set; } // decimal 0.00
        public decimal Altura { get; set; } //decimal 0.00
        public decimal Largura { get; set; } //decimal 0.00
        public decimal Comprimento { get; set; } // decimal 0.00
        public decimal Valor { get; set; } //decimal
        public double QuantidadeEmEstoque { get; set; }//inteiro na conversão
        public string CentroDeDistribuicao { get; set; }

        public string NomedaCategoria { get; set; }

        Regex r = new Regex(@"^[a-z A-Z ]{0,128}$");
        Regex r1 = new Regex(@"^[a-z A-Z 0-9]{0,128}$");
        Regex r2 = new Regex(@"^[a-z A-Z ]{0,512}$");

        int EscolherOpcaoAlteracaoDoProduto;

        Categoria Categoria1 = new Categoria();

        SubCategoria SubCategoria1 = new SubCategoria();
        List<Categoria> ListaDeCategorias = new List<Categoria>();
        Categoria Categorias1 = new Categoria();
        List<Produtos> ListaDeProdutos = new List<Produtos>();

        public Produtos()
        {

        }

        public Produtos(string nomeDoProduto, string descricaoDoProdutoCadastrado, decimal pesoCadastrado,
            decimal alturaCadastrado, decimal larguraCadastrado, decimal comprimentoCadastrado, decimal valorCadastrado,
            double quantidadeEmEstoqueCadastrado, string centroDeDistribuicaoCadastrado)
        {
            NomeDoProduto = nomeDoProduto;
            DescricaoDoProduto = descricaoDoProdutoCadastrado;
            Peso = pesoCadastrado;
            Altura = alturaCadastrado;
            Largura = larguraCadastrado;
            Comprimento = comprimentoCadastrado;
            Valor = valorCadastrado;
            QuantidadeEmEstoque = quantidadeEmEstoqueCadastrado;
            CentroDeDistribuicao = centroDeDistribuicaoCadastrado;
        }

        public void CadastrarProduto()
        {
            Console.WriteLine("Cadastre um produto:");
            {
                Console.Write("Nome Do Produto :  ");
                NomeDoProduto = ValidaNomeProduto();

                Console.Write("Descrição Do Produto: ");
                string descricaoDoProdutoCadastrado = Console.ReadLine();

                if (descricaoDoProdutoCadastrado.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProdutoCadastrado))
                {
                    Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
                    Console.Write("Descrição Do Produto: ");
                    descricaoDoProdutoCadastrado = Console.ReadLine();
                }
                DescricaoDoProduto = descricaoDoProdutoCadastrado;

                Console.Write("Peso produto: ");
                decimal pesoCadastrado;
                pesoCadastrado = decimal.Parse(Console.ReadLine());
                Peso = pesoCadastrado;

                Console.Write("Altura produto: ");
                decimal alturaCadastrado;
                alturaCadastrado = decimal.Parse(Console.ReadLine());
                Altura = alturaCadastrado;

                Console.Write("Largura do produto: ");
                decimal larguraCadastrado;
                larguraCadastrado = decimal.Parse(Console.ReadLine());
                Largura = larguraCadastrado;

                Console.Write("Comprimento Do Produto: ");
                decimal comprimentoCadastrado;
                comprimentoCadastrado = decimal.Parse(Console.ReadLine());
                Comprimento = comprimentoCadastrado;

                Console.Write("Valor Do Produto: ");
                decimal valorCadastrado;
                valorCadastrado = decimal.Parse(Console.ReadLine());
                Valor = valorCadastrado;

                Console.Write("Quantidade Em estoque: ");
                int quantidadeEmEstoqueCadastrado;
                quantidadeEmEstoqueCadastrado = int.Parse(Console.ReadLine());
                QuantidadeEmEstoque = quantidadeEmEstoqueCadastrado;

                Console.Write("Centro De Distribuicao, exemplo Siglda da UF:  ");
                string centroDeDistribuicaoCadastrado = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(centroDeDistribuicaoCadastrado))
                {
                    Console.WriteLine("É obrigatório o centro de distribuição!");
                    Console.Write("Centro de Distribuiçao: ");
                    centroDeDistribuicaoCadastrado = Console.ReadLine();
                }
                CentroDeDistribuicao = centroDeDistribuicaoCadastrado;

                Console.WriteLine("A qual categoria, esse produto pertence? ");
                {

                    {
                        var ListaDeCategorias2 = ListaDeCategorias.FindAll(p => p.Equals(Categorias1.NomeCategoria)).ToString();
                        foreach (var item in ListaDeCategorias)

                            Console.WriteLine("escreva o novo nome da categoria:");//editar fala de novo sobre deseja alterar a categria/colocar junto com mostrar lista
                        Categorias1.NomeCategoria = Categorias1.CadastrarCategoria();
                        Console.WriteLine("Categoria " + Categorias1.NomeCategoria + "  editada com sucesso" + "  Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
                    }
                }

                Console.WriteLine("A qual subcategoria, esse produto pertence ?");
                {
                    Console.WriteLine("Digite SIM para subcategoria já cadastrada ou NÃO para cadastrar agora: ");
                    string repetirSubCategoria = Console.ReadLine();

                    if (repetirSubCategoria.ToUpper() == "SIM")
                    {
                        Console.WriteLine("Subcategoria:   " + SubCategoria1.NomeSubCategoria + "  e Status:" + Categorias1.CadastroStatus());
                    }
                    else
                    {
                        Console.WriteLine("Digite o nome da Subcategoria");
                        SubCategoria1.NomeSubCategoria = SubCategoria1.CadastrarCategoria();
                        Console.WriteLine("Categoria " + SubCategoria1.NomeSubCategoria + "  cadastrada com sucesso!  " + " Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
                    }
                }
                ListaDeProdutos.Add(new Produtos(NomeDoProduto, DescricaoDoProduto, Peso, Altura, Largura, Comprimento, Valor, QuantidadeEmEstoque, CentroDeDistribuicao));
                Console.WriteLine("Produtos adicionados com sucesso! Com Status: Ativo. Data da criaçao:" + DateTime.Now);
                Console.WriteLine();

                var ListaDeProdutos1 = ListaDeProdutos.FindAll(p => p.Equals(NomeDoProduto)).ToString();
                foreach (

                    var item in ListaDeProdutos)
                {
                    Console.WriteLine("Segue produto adicionado : ");
                }
                DescricaoDoProdutoNaLista();
                Console.WriteLine($"Nome da Categoria: " + Categorias1.NomeCategoria);
                Console.WriteLine($"Nome da Subcategoria: " + SubCategoria1.NomeSubCategoria);
                Console.WriteLine();

            }
        }
        public void DescricaoDoProdutoNaLista()
        {
            Console.WriteLine($"Nome do Produto " + NomeDoProduto);
            Console.WriteLine($"Descrição do Produto: " + DescricaoDoProduto);
            Console.WriteLine($"Peso do Produto: " + Peso);
            Console.WriteLine($"Altura do Produto: " + Altura);
            Console.WriteLine($"Largura do Produto: " + Largura);
            Console.WriteLine($"Comprimento do Produto: " + Comprimento);
            Console.WriteLine($"Valor do Produto: " + Valor);
            Console.WriteLine($"Quantidade em estoque do Produto: " + QuantidadeEmEstoque);
            Console.WriteLine($"Centro de Distribuição: " + CentroDeDistribuicao);

        }

        public string ValidaNomeProduto()
        {
            string nomeDoProdutoCadastrado = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nomeDoProdutoCadastrado) || !r1.IsMatch(nomeDoProdutoCadastrado))
            {
                Console.WriteLine("É obrigatório o nome do produto com letras e números  até 128 caracteres!");
                nomeDoProdutoCadastrado = Console.ReadLine();
            }
            return nomeDoProdutoCadastrado;
        }
    }
}








//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Text.RegularExpressions;
//using System.Collections;

//namespace Sprint3_Ecommerce
//{
//    public class Produtos : Categoria
//    {
//        public string NomeDoProduto { get; set; }  // 128char - alfanúmerico - 
//        public string DescricaoDoProduto { get; set; } //512char / alfanúmerico - 
//        public decimal Peso { get; set; } // decimal 0.00
//        public decimal Altura { get; set; } //decimal 0.00
//        public decimal Largura { get; set; } //decimal 0.00
//        public decimal Comprimento { get; set; } // decimal 0.00
//        public decimal Valor { get; set; } //decimal
//        public double QuantidadeEmEstoque { get; set; }//inteiro na conversão
//        public string CentroDeDistribuicao { get; set; }

//        public string NomedaCategoria { get; set; }

//        public Regex r1 = new Regex(@"^[a-z A-Z 0-9]{0,128}$");
//        public Regex r2 = new Regex(@"^[a-z A-Z ]{0,512}$");

//        int EscolherOpcaoAlteracaoDoProduto;

//        Categoria Categoria1 = new Categoria();

//        SubCategoria SubCategoria1 = new SubCategoria();
//        public Produtos()
//        {

//        }

//        public Produtos(string nomeDoProduto, string descricaoDoProdutoCadastrado, decimal pesoCadastrado,
//            decimal alturaCadastrado, decimal larguraCadastrado, decimal comprimentoCadastrado, decimal valorCadastrado,
//            double quantidadeEmEstoqueCadastrado, string centroDeDistribuicaoCadastrado)
//        {
//            NomeDoProduto = nomeDoProduto;
//            DescricaoDoProduto = descricaoDoProdutoCadastrado;
//            Peso = pesoCadastrado;
//            Altura = alturaCadastrado;
//            Largura = larguraCadastrado;
//            Comprimento = comprimentoCadastrado;
//            Valor = valorCadastrado;
//            QuantidadeEmEstoque = quantidadeEmEstoqueCadastrado;
//            CentroDeDistribuicao = centroDeDistribuicaoCadastrado;
//        }


//        public string ValidaNomeProduto() 
//        {
//            string nomeDoProdutoCadastrado = Console.ReadLine();
//            while (string.IsNullOrWhiteSpace(nomeDoProdutoCadastrado) || !r1.IsMatch(nomeDoProdutoCadastrado))
//            {
//                Console.WriteLine("É obrigatório o nome do produto com letras e números  até 128 caracteres!");
//                nomeDoProdutoCadastrado = Console.ReadLine();
//            }
//            return nomeDoProdutoCadastrado;
//        }

//        public void DescricaoDoProdutoNaLista()
//        {
//            Console.WriteLine($"Nome do Produto "   +  NomeDoProduto);
//            Console.WriteLine($"Descrição do Produto: " + DescricaoDoProduto);
//            Console.WriteLine($"Peso do Produto: " + Peso);
//            Console.WriteLine($"Altura do Produto: " + Altura);
//            Console.WriteLine($"Largura do Produto: " + Largura);
//            Console.WriteLine($"Comprimento do Produto: " + Comprimento);
//            Console.WriteLine($"Valor do Produto: " + Valor);
//            Console.WriteLine($"Quantidade em estoque do Produto: " + QuantidadeEmEstoque);
//            Console.WriteLine($"Centro de Distribuição: " + CentroDeDistribuicao);
            
//        }
//    }
//}











































//Console.Write($"Nome do Produto: {NomeDoProduto}\n");
//string nomedoProduto = Console.ReadLine();
//while (string.IsNullOrWhiteSpace(nomeDoProduto) || !r1.IsMatch(nomeDoProduto))
//{
//    Console.WriteLine("É obrigatório o nome da produto, com letras e números  até 128 caracteres!");
//    nomeDoProduto = Console.ReadLine();
//}
////return nomeDoProduto;


//public static void AdicionarProdutos()
//{
//    Console.Write("Nome Do Produto: ");
//    string nomeDoProduto = Console.ReadLine();
//    while (nomeDoProduto.Length >= 128 || string.IsNullOrWhiteSpace(nomeDoProduto))
//    {
//        Console.WriteLine("É obrigatório o nome do produto, com letras e números até 128 caracteres!");
//        Console.Write("Nome Do Produto: ");
//        nomeDoProduto = Console.ReadLine();
//    }

//    Console.Write("Descrição Do Produto: ");
//    string descricaoDoProduto = Console.ReadLine();
//    if (descricaoDoProduto.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProduto))
//    {
//        Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
//        Console.Write("Descrição Do Produto: ");
//        descricaoDoProduto = Console.ReadLine();
//    }

//    Console.Write("Peso produto: ");
//    decimal peso;
//    peso = decimal.Parse(Console.ReadLine());

//    Console.Write("Altura produto: ");
//    decimal altura;
//    altura = decimal.Parse(Console.ReadLine());

//    Console.Write("Largura do produto: ");
//    decimal largura;
//    largura = decimal.Parse(Console.ReadLine());

//    Console.Write("Comprimento Do Produto: ");
//    decimal comprimento;
//    comprimento = decimal.Parse(Console.ReadLine());

//    Console.Write("Valor Do Produto: ");
//    decimal valor;
//    valor = decimal.Parse(Console.ReadLine());

//    Console.Write("Quantidade Em estoque: ");
//    int quantidadeEmEstoque;
//    quantidadeEmEstoque = int.Parse(Console.ReadLine());

//    Console.Write("Centro De Distribuicao: ");
//    string centroDeDistribuicao = Console.ReadLine();
//    if (string.IsNullOrWhiteSpace(centroDeDistribuicao))
//    {
//        Console.WriteLine("É obrigatório o centro de distribuição!");
//        Console.Write("Centro de Distribuiçao: ");
//        centroDeDistribuicao = Console.ReadLine();
//    }

//    Console.Write("Nome da categoria:"); //nomeDaCategoria.CadastrarCategoria();
//    Regex r1 = new Regex(@"^[a-z A-Z ]{0,128}$");
//    string nomeDaCategoria = Console.ReadLine();
//    while (string.IsNullOrWhiteSpace(nomeDaCategoria) || !r1.IsMatch(nomeDaCategoria))
//    {
//        Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 128 caracteres!");
//        nomeDaCategoria = Console.ReadLine(); 
//    }
//    Console.WriteLine("Categoria " + nomeDaCategoria + "  editada com sucesso!  -" + " Status:  Ativo " + " Data da criaçao:");

//    Console.Write("Nome da subcategoria:");
//    Regex r2 = new Regex(@"^[a-z A-Z ]{0,128}$");
//    string nomeDaSubCategoria = Console.ReadLine();
//    while (string.IsNullOrWhiteSpace(nomeDaSubCategoria) || !r2.IsMatch(nomeDaSubCategoria))
//    {
//        Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 128 caracteres!");
//        Console.Write("Nome Da subcategoria: "); 
//    }
//    nomeDaSubCategoria = Console.ReadLine();

//    List<Produtos> ListaDeProdutos = new List<Produtos>();

//    //parenteses e min/chama do metodo
//    ListaDeProdutos.Add(new Produtos(nomeDoProduto, descricaoDoProduto, peso, altura, largura, comprimento, valor, quantidadeEmEstoque, centroDeDistribuicao, nomeDaCategoria, nomeDaSubCategoria));
//    Console.WriteLine("Produtos adicionados com sucesso! Com Status: Ativo. Data da criaçao:" + DateTime.Now);
//    Console.WriteLine();

//    var ListaDeProdutos1 = ListaDeProdutos.FindAll(p => p.Equals(nomeDoProduto)).ToString();
//    foreach (var item in ListaDeProdutos)
//    {
//        //Console.Write($"Nome do produto:{item.NomeDoProduto}\n"); aqui vou chamar o que foi cadastrado
//        //DescricaoDoProdutoNaLista();
//        Console.WriteLine();
//        Console.WriteLine("Para fazer uma nova busca ou editar um produto, volte ao menu anterior");
//        Console.WriteLine();
//    }
//    //Produtos.PesquisarProdutos(ListaDeProdutos, busca);
//}

//public Produtos EditarProdutos(Produtos produtos)  // switch mesmo // fazer retorno de objeto aqui
//{
//    
//    do
//    {
//        Console.WriteLine("Qual item deseja alterar? \n" +
//        "Digite: 1 - para alterar o nome do produto: \n" +
//        "Digite: 2 - para alterar a descrição do produto: \n" +
//        "Digite: 3 - para alterar o peso do produto: \n" +
//        "Digite: 4 - para alterar a  altura do produto: \n" +
//        "Digite: 5 - para alterar a largura do produto: \n" +
//        "Digite: 6 - para alterar o comprimento do produto: \n" +
//        "Digite: 7 - para alterar o valor do produto: \n" +
//        "Digite: 8 - para alterar a quantidade em estoque: \n" +
//        "Digite: 9 - para alterar o centro de distribuição: \n" +
//        "Digite: 10 - para alterar o nome da categoria: \n" +
//        "Digite: 11 - para alterar o nome da subcategoria: \n" +
//        "Digite: 12 - Deseja alterar outro item ou apenas sair! ");

//        Console.WriteLine();
//        int EscolherOpcaoAlteracaoDoProduto = int.Parse(Console.ReadLine());

//        switch (EscolherOpcaoAlteracaoDoProduto)
//        {
//            case 1:
//                {
//                    Console.WriteLine("Digite o novo nome do produto:");
//                    string nomeDoProduto = Console.ReadLine();
//                    while (nomeDoProduto.Length >= 128 || string.IsNullOrWhiteSpace(nomeDoProduto))
//                    {
//                        Console.WriteLine("É obrigatório o novo nome do produto, com letras e números até 128 caracteres!");
//                        nomeDoProduto = Console.ReadLine();
//                        Console.Write("Nome Do Produto:" + nomeDoProduto + "Data da modificação:" + DateTime.Now);
//                    }
//                }
//                break;
//            case 2:
//                {
//                    Console.WriteLine("Digite a nova descrição do produto:");
//                    string descricaoDoProduto = Console.ReadLine();
//                    if (descricaoDoProduto.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProduto))
//                    {
//                        Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
//                        descricaoDoProduto = Console.ReadLine();
//                        Console.Write("Nome Do Produto:" + descricaoDoProduto + "Data da modificação:" + DateTime.Now);
//                    }
//                }
//                break;
//            case 3:
//                {
//                    Console.WriteLine("Digite o novo peso do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int peso))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Peso Do Produto:" + peso + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 4:
//                {
//                    Console.WriteLine("Digite a nova altura do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int altura))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Altura Do Produto:" + altura + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 5:
//                {
//                    Console.WriteLine("Digite a nova largura do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int largura))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Largura Do Produto:" + largura + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 6:
//                {
//                    Console.WriteLine("Digite o novo comprimento do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int comprimento))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Comprimento Do Produto:" + comprimento + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 7:
//                {
//                    Console.WriteLine("Digite o novo valor do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int valor))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToInt32(Console.ReadLine());
//                    Console.Write("Valor Do Produto:" + valor + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 8:
//                {
//                    Console.WriteLine("Digite a nova quantidade em estoque do produto:");
//                    if (!double.TryParse(Console.ReadLine(), out double quantidadeEmEstoque))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToInt32(Console.ReadLine());
//                    Console.Write("Quantidade em estoque Do Produto:" + quantidadeEmEstoque + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 9:
//                {
//                    Console.WriteLine("Digite o novo centro de distribuição:");
//                    string centroDeDistribuicao = Console.ReadLine();
//                    if (string.IsNullOrWhiteSpace(centroDeDistribuicao))
//                    {
//                        Console.WriteLine("É obrigatório o centro de distribuição!");
//                        centroDeDistribuicao = Console.ReadLine();
//                        Console.Write("Nome Do Produto:" + centroDeDistribuicao + "Data da modificação:" + DateTime.Now);
//                    }
//                }
//                break;
//            case 10:
//                //{
//                //    Console.WriteLine("A qual categoria, essa subcategoria vai pertencer?");
//                //    {
//                //        Console.WriteLine("Digite SIM para categoria já cadastrada ou NÃO para cadastrar agora ");
//                //        string repetirCategoria = Console.ReadLine();

//                //        if (repetirCategoria.ToUpper() == "SIM")
//                //        {
//                //            Console.WriteLine("Repita aqui o nome da categoria:   " + Categoria1.NomeCategoria + "  e Status:" + Categoria1.CadastroStatus());
//                //            Console.WriteLine("Agora cadastre a subcategoria, digite o nome:");
//                //            SubCategoria1.NomeCategoria = SubCategoria1.CadastrarSubCategoria();
//                //        }
//                //        else
//                //        {
//                //            Console.WriteLine("Digite o nome da categoria");
//                //            Categoria1.NomeCategoria = Categoria1.CadastrarCategoria();
//                //            Console.WriteLine("Categoria " + Categoria1.NomeCategoria + "  cadastrada com sucesso!  " + "Status : " + Categoria1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                //            Console.WriteLine("Cadastre a subcategoria, digite o nome:");
//                //            SubCategoria1.NomeCategoria = SubCategoria1.CadastrarSubCategoria();
//                //            Console.WriteLine("SubCategoria " + SubCategoria1.NomeCategoria + "Status : " + Categoria1.CadastroStatus() + " - Data da Modificação:" + DateTime.Now);
//                //        }
//                //    }
//                //}
//                {
//                    Console.WriteLine("Digite o novo nome da categoria do produto:"); //nomeDaCategoria.CadastrarCategoria();
//                    Regex r1 = new Regex(@"^[a-z A-Z ]{0,128}$");
//                    string nomeDaCategoria = Console.ReadLine();
//                    nomeDaCategoria = Console.ReadLine();
//                    while (string.IsNullOrWhiteSpace(nomeDaCategoria) || !r1.IsMatch(nomeDaCategoria))
//                    {
//                        Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 128 caracteres!");
//                        nomeDaCategoria = Console.ReadLine();
//                    }
//                    Console.WriteLine("Categoria " + nomeDaCategoria + "  cadastrada com sucesso!  -" + " Status:  Ativo " + " Data da criaçao:");
//                }
//                break;
//            case 11:
//                {
//                    Console.WriteLine("Digite o novo nome da subcategoria:");
//                    Regex r2 = new Regex(@"^[a-z A-Z ]{0,512}$");
//                    string nomeDaSubCategoria = Console.ReadLine();
//                    while (string.IsNullOrWhiteSpace(nomeDaSubCategoria) || !r2.IsMatch(nomeDaSubCategoria))
//                    {
//                        Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 512 caracteres!");
//                        Console.Write("Nome Da subcategoria: "); break;
//                    }
//                    nomeDaSubCategoria = Console.ReadLine();
//                }
//                break;
//            case 12:
//                {
//                    Console.WriteLine("Digite qualquer tecla para sair:");
//                    Console.ReadKey();
//                }
//                break;
//            default:
//                Console.WriteLine("Digite uma opção válida!");
//                break;
//        }
//    } while (EscolherOpcaoAlteracaoDoProduto != 12);
//    return produtos;
//}

//public static Produtos PesquisarProdutos(List<Produtos> lista, string item)
//{
//    //return lista.First(p => p.Equals(item));
//    return (Produtos) lista.Where(p => p.NomeDoProduto.Contains(item));
//}

//public Produtos EditarProdutos(Produtos produtos)  // switch mesmo // fazer retorno de objeto aqui
//                                                   // public string EditarProdutos(string produtos)
//{
//    Console.WriteLine();
//    do
//    {
//        Console.WriteLine("Qual item deseja alterar? \n" +
//        "Digite: 1 - para alterar o nome do produto: \n" +
//        "Digite: 2 - para alterar a descrição do produto: \n" +
//        "Digite: 3 - para alterar o peso do produto: \n" +
//        "Digite: 4 - para alterar a  altura do produto: \n" +
//        "Digite: 5 - para alterar a largura do produto: \n" +
//        "Digite: 6 - para alterar o comprimento do produto: \n" +
//        "Digite: 7 - para alterar o valor do produto: \n" +
//        "Digite: 8 - para alterar a quantidade em estoque: \n" +
//        "Digite: 9 - para alterar o centro de distribuição: \n" +
//        "Digite: 10 - para alterar o nome da categoria: \n" +
//        "Digite: 11 - para alterar o nome da subcategoria: \n" +
//        "Digite: 12 - Deseja alterar outro item ou apenas sair! ");

//        Console.WriteLine();
//        int EscolherOpcaoAlteracaoDoProduto = int.Parse(Console.ReadLine());

//        switch (EscolherOpcaoAlteracaoDoProduto)
//        {
//            case 1:
//                {
//                    Console.WriteLine("Digite o novo nome do produto:");
//                    string nomeDoProduto = Console.ReadLine();
//                    while (nomeDoProduto.Length >= 128 || string.IsNullOrWhiteSpace(nomeDoProduto))
//                    {
//                        Console.WriteLine("É obrigatório o novo nome do produto, com letras e números até 128 caracteres!");
//                        nomeDoProduto = Console.ReadLine();
//                        Console.Write("Nome Do Produto:" + nomeDoProduto + "Data da modificação:" + DateTime.Now);
//                    }
//                }
//                break;
//            case 2:
//                {
//                    Console.WriteLine("Digite a nova descrição do produto:");
//                    string descricaoDoProduto = Console.ReadLine();
//                    if (descricaoDoProduto.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProduto))
//                    {
//                        Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
//                        descricaoDoProduto = Console.ReadLine();
//                        Console.Write("Nome Do Produto:" + descricaoDoProduto + "Data da modificação:" + DateTime.Now);
//                    }
//                }
//                break;
//            case 3:
//                {
//                    Console.WriteLine("Digite o novo peso do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int peso))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Peso Do Produto:" + peso + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 4:
//                {
//                    Console.WriteLine("Digite a nova altura do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int altura))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Altura Do Produto:" + altura + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 5:
//                {
//                    Console.WriteLine("Digite a nova largura do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int largura))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Largura Do Produto:" + largura + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 6:
//                {
//                    Console.WriteLine("Digite o novo comprimento do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int comprimento))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToDecimal(Console.ReadLine());
//                    Console.Write("Comprimento Do Produto:" + comprimento + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 7:
//                {
//                    Console.WriteLine("Digite o novo valor do produto:");
//                    if (!int.TryParse(Console.ReadLine(), out int valor))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToInt32(Console.ReadLine());
//                    Console.Write("Valor Do Produto:" + valor + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 8:
//                {
//                    Console.WriteLine("Digite a nova quantidade em estoque do produto:");
//                    if (!double.TryParse(Console.ReadLine(), out double quantidadeEmEstoque))
//                        Console.WriteLine("Sem espaço e somente números decimais!");
//                    Convert.ToInt32(Console.ReadLine());
//                    Console.Write("Quantidade em estoque Do Produto:" + quantidadeEmEstoque + "Data da modificação:" + DateTime.Now);
//                }
//                break;
//            case 9:
//                {
//                    Console.WriteLine("Digite o novo centro de distribuição:");
//                    string centroDeDistribuicao = Console.ReadLine();
//                    if (string.IsNullOrWhiteSpace(centroDeDistribuicao))
//                    {
//                        Console.WriteLine("É obrigatório o centro de distribuição!");
//                        centroDeDistribuicao = Console.ReadLine();
//                        Console.Write("Nome Do Produto:" + centroDeDistribuicao + "Data da modificação:" + DateTime.Now);
//                    }
//                }
//                break;
//            case 10:
//                {
//                    Console.WriteLine("Digite o novo nome da categoria do produto:"); //nomeDaCategoria.CadastrarCategoria();
//                    Regex r1 = new Regex(@"^[a-z A-Z ]{0,128}$");
//                    string nomeDaCategoria = Console.ReadLine();
//                    nomeDaCategoria = Console.ReadLine();
//                    while (string.IsNullOrWhiteSpace(nomeDaCategoria) || !r1.IsMatch(nomeDaCategoria))
//                    {
//                        Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 128 caracteres!");
//                        nomeDaCategoria = Console.ReadLine();
//                    }
//                    Console.WriteLine("Categoria " + nomeDaCategoria + "  cadastrada com sucesso!  -" + " Status:  Ativo " + " Data da criaçao:");
//                }
//                break;
//            case 11:
//                {
//                    Console.WriteLine("Digite o novo nome da subcategoria:");
//                    Regex r2 = new Regex(@"^[a-z A-Z ]{0,512}$");
//                    string nomeDaSubCategoria = Console.ReadLine();
//                    while (string.IsNullOrWhiteSpace(nomeDaSubCategoria) || !r2.IsMatch(nomeDaSubCategoria))
//                    {
//                        Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 512 caracteres!");
//                        Console.Write("Nome Da subcategoria: "); break;
//                    }
//                    nomeDaSubCategoria = Console.ReadLine();
//                }
//                break;
//            case 12:
//                {
//                    Console.WriteLine("Digite qualquer tecla para sair:");
//                    Console.ReadKey();
//                }
//                break;
//            default:
//                Console.WriteLine("Digite uma opção válida!");
//                break;
//        }
//    } while (EscolherOpcaoAlteracaoDoProduto != 12);
//    return produtos;
//}