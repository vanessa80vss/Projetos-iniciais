using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Sprint3_Ecommerce;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        Categoria CategoriaX = new Categoria();
        Categoria CategoriaY = new Categoria();
        SubCategoria SubCategoria1 = new SubCategoria();
        List<Produtos> ListaDeProdutos = new List<Produtos>();
        Produtos Produtos1 = new Produtos();
        Produtos Produtos2 = new Produtos();
        Regex r = new Regex(@"^[a-z A-Z ]{0,128}$");
        Regex r1 = new Regex(@"^[a-z A-Z 0-9]{0,128}$");
        int EscolherOpcao;
        string nomeCategoria;
        Categoria Categoria1 = new Categoria();
        List<Categoria> ListaDeCategorias = new List<Categoria>();


        do
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bem vindo ao seu E-Commerce!");
            Console.ResetColor();
            Console.WriteLine("o que deseja fazer? \n" +
                "Digite: 1 - Cadastrar categoria: \n" +
                "Digite: 2 - Mostre a lista de categoria:\n" +
                "Digite: 3 - Editar categoria: \n" +
                "Digite: 4 - Cadastrar subcategoria: \n" +
                "Digite: 5 - Editar subcategoria: \n" +
                "Digite: 6 - Cadastrar um produto: \n" +
                "Digite: 7 - Editar um produto: \n" +
                "Digite: 8 - Pesquisar um produto: \n" +
                "Digite: 9 - Apenas leitura e sair! ");
            Console.WriteLine();
            EscolherOpcao = int.Parse(Console.ReadLine());

            switch (EscolherOpcao)
            {
                case 1:
                    Console.WriteLine("Quantas categorias deseja cadastrar?");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine("Informe o nome da categoria # " + i + ":");
                        nomeCategoria = Console.ReadLine();
                        bool test = r.IsMatch(nomeCategoria);
                        while (test == false || string.IsNullOrWhiteSpace(nomeCategoria))
                        {
                            Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 128 caracteres!");
                            nomeCategoria = Console.ReadLine();
                            test = r.IsMatch(nomeCategoria);
                        }
                        Categoria1.NomeCategoria = nomeCategoria;
                                               
                        
                    ListaDeCategorias.Add(new Categoria(Categoria1.NomeCategoria, Categoria1.StatusCategoria, DateTime.Now));
                    Console.WriteLine("Categoria adicionada com sucesso! Com Status: Ativo. Data da criaçao:" + DateTime.Now);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Segue categorias adicionadas :  " + ListaDeCategorias.Count);
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Mostre a lista de categorias:");
                    {
                      foreach (var item in ListaDeCategorias)
                      {
                      Console.WriteLine($"Nome da Categoria: {item.NomeCategoria + " " +  "- Status  : " + Categoria1.CadastroStatus() +  "-Data : " +  "" +  DateTime.Now}");
                      }
                    }
                    break;
                case 3:

                    Console.WriteLine("Qual categoria deseja alterar?");
                    Categoria1.NomeCategoria = Console.ReadLine();
                    {
                        var ListaDeCategorias2 = ListaDeCategorias.FindAll(c => c.Equals(Categoria1.NomeCategoria)).ToString();
                        foreach (var item in ListaDeCategorias)
                        {
                            Categoria1.EditarNomeCategoria();
                            Console.WriteLine();
                        }
                       ////     Console.WriteLine("escreva o novo nome da categoria:");//editar fala de novo sobre deseja alterar a categria/colocar junto com mostrar lista
                       //// Categoria1.NomeCategoria = Categoria1.CadastrarCategoria();
                       //// Console.WriteLine("Categoria " + Categoria1.NomeCategoria + "  editada com sucesso" + "  Status : " + Categoria1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
                       //// Console.WriteLine("Gostaria de alterar o status, digite SIM ou NÃO");
                       //// string verificacaoStatus = Console.ReadLine();
                       //// if (verificacaoStatus.ToUpper() == "SIM")
                       //// {
                       ////     Categoria1.VerificacaoStatus();
                       ////     Console.WriteLine("Status : " + Categoria1.CadastroStatus() + " - Data da Modificação:" + DateTime.Now);
                       //// }
                       ////// Console.WriteLine("Qual produto deseja editar");
                       ////// Produtos1.NomeDoProduto = Console.ReadLine();
                       ////// var ListaDeProdutos2 = ListaDeProdutos.FindAll(p => p.Equals(Produtos1.NomeDoProduto)).ToString();
                       //// //foreach (var item in ListaDeProdutos)
                       //// {
                       ////     Produtos1.DescricaoDoProdutoNaLista();
                            
                       //// }
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("A qual categoria, essa subcategoria vai pertencer ?");

                        {
                            var ListaDeCategorias4 = ListaDeCategorias.FindAll(p => p.Equals(Categoria1.NomeCategoria)).ToString();
                            foreach (var item in ListaDeCategorias)

                           Console.WriteLine("escreva o novo nome da categoria:");
                           Categoria1.NomeCategoria = Categoria1.CadastrarCategoria();
                            Console.WriteLine("Categoria " + Categoria1.NomeCategoria + "  Status : " + Categoria1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
                            Console.WriteLine("Agora cadastre a subcategoria, digite o nome:");
                            SubCategoria1.NomeSubCategoria = SubCategoria1.CadastrarSubCategoria();
                        }
                    }
                   break;
                case 5:
                    {
                        Console.WriteLine("Edite uma subcategoria:");
                        SubCategoria1.EditarNomeSubCategoria();
                        Console.WriteLine("Gostaria de alterar o status, digite SIM ou NÃO : ");
                        string verificacaoStatus = Console.ReadLine();
                        if (verificacaoStatus.ToUpper() == "SIM")
                        {
                            CategoriaX.VerificacaoStatus();
                            Console.WriteLine("Status : " + CategoriaX.CadastroStatus() + " - Data da Modificação:" + DateTime.Now);
                        }
                    }
                    break;
                case 6: 
                    {
                        Console.WriteLine("Cadastre um produto:");

                        Produtos1.CadastrarProduto();
                    }
                    break;
                case 7:
                    {
                        decimal pesoCadastrado;
                        decimal alturaCadastrado;
                        decimal larguraCadastrado;
                        decimal comprimentoCadastrado;
                        decimal valorCadastrado;
                        int quantidadeEmEstoqueCadastrado;

                        Console.WriteLine("Qual produto deseja editar");
                        Produtos1.NomeDoProduto = Console.ReadLine();

                        var ListaDeProdutos2 = ListaDeProdutos.FindAll(p => p.Equals(Produtos1.NomeDoProduto)).ToString();
                        foreach (var item in ListaDeProdutos)
                        {
                            Produtos1.DescricaoDoProdutoNaLista();
                            Console.WriteLine();
                        }

                        Console.WriteLine("Qual item deseja editar? \n" +
                        "Digite: 1 - para alterar o nome do produto: \n" +
                        "Digite: 2 - para alterar a descrição do produto: \n" +
                        "Digite: 3 - para alterar o peso do produto: \n" +
                        "Digite: 4 - para alterar a  altura do produto: \n" +
                        "Digite: 5 - para alterar a largura do produto: \n" +
                        "Digite: 6 - para alterar o comprimento do produto: \n" +
                        "Digite: 7 - para alterar o valor do produto: \n" +
                        "Digite: 8 - para alterar a quantidade em estoque: \n" +
                        "Digite: 9 - para alterar o centro de distribuição: \n" +
                        "Digite: 10 - para alterar o nome da categoria: \n" +
                        "Digite: 11 - para alterar o nome da subcategoria: \n" +
                        "Digite: 12 - Deseja alterar outro item ou apenas sair! ");
                        Console.WriteLine();

                        string EscolherOpcaoAlteracaoDoProduto = Console.ReadLine();

                        if (EscolherOpcaoAlteracaoDoProduto == "1")
                        {
                            Console.WriteLine("Digite o novo nome do produto: ");
                            Produtos1.ValidaNomeProduto();
                            Console.Write("Nome Do Produto:  " + Produtos1.NomeDoProduto + " Data da modificação:" + DateTime.Now);
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "2")
                        {
                            Console.WriteLine("Digite a nova descrição do produto:");
                            string descricaoDoProdutoCadastrado = Console.ReadLine();
                            if (descricaoDoProdutoCadastrado.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProdutoCadastrado))
                            {
                                Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
                                descricaoDoProdutoCadastrado = Console.ReadLine();
                                Console.Write("Descrição Do Produto:  " + descricaoDoProdutoCadastrado + " Data da modificação: " + DateTime.Now);
                            }
                            Console.WriteLine("a descrição é: " + descricaoDoProdutoCadastrado);
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "3")
                        {
                            Console.WriteLine("Digite o novo peso do produto:");
                            while (!decimal.TryParse(Console.ReadLine(), out pesoCadastrado))
                            {
                                Console.WriteLine("Sem espaço e somente números decimais!");
                            }
                            Produtos1.Peso = pesoCadastrado;
                            Console.Write("Peso Do Produto: " + Produtos1.Peso + " Data da modificação: " + DateTime.Now);
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "4")
                        {
                            Console.WriteLine("Digite a nova altura do produto:");
                            while (!decimal.TryParse(Console.ReadLine(), out alturaCadastrado))
                            {
                                Console.WriteLine("Sem espaço e somente números decimais!");
                            }
                            Produtos1.Altura = alturaCadastrado;
                            Console.Write("Altura Do Produto: " + Produtos1.Altura + " Data da modificação: " + DateTime.Now);
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "5")
                        {
                            Console.WriteLine("Digite a nova largura do produto:");
                            while (!decimal.TryParse(Console.ReadLine(), out larguraCadastrado))
                            {
                                Console.WriteLine("Sem espaço e somente números decimais!");
                            }
                            Produtos1.Largura = larguraCadastrado;
                            Console.Write("Largura Do Produto: " + Produtos1.Largura + " Data da modificação: " + DateTime.Now);
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "6")
                        {
                            Console.WriteLine("Digite o novo comprimento do produto:");
                            while (!decimal.TryParse(Console.ReadLine(), out comprimentoCadastrado))
                            {
                                Console.WriteLine("Sem espaço e somente números decimais!");
                            }
                            Produtos1.Comprimento = comprimentoCadastrado;
                            Console.Write("Comprimento Do Produto: " + Produtos1.Comprimento + " Data da modificação: " + DateTime.Now);
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "7")
                        {
                            Console.WriteLine("Digite o novo valor do produto:");
                            while (!decimal.TryParse(Console.ReadLine(), out valorCadastrado))
                            {
                                Console.WriteLine("Sem espaço e somente números decimais!");
                            }
                            Produtos1.Valor = valorCadastrado;
                            Console.Write("Valor Do Produto: " + Produtos1.Valor + " Data da modificação: " + DateTime.Now);
                        }
                        if (EscolherOpcaoAlteracaoDoProduto == "8")
                        {
                            Console.WriteLine("Digite a nova quantidade em estoque do produto:");
                            while (!int.TryParse(Console.ReadLine(), out quantidadeEmEstoqueCadastrado))
                            {
                                Console.WriteLine("Sem espaço e somente números decimais!");
                            }
                            Produtos1.QuantidadeEmEstoque = quantidadeEmEstoqueCadastrado;
                            Console.Write("Quantidade em estoque Do Produto: " + Produtos1.QuantidadeEmEstoque + " Data da modificação: " + DateTime.Now);
                        }
                        if (EscolherOpcaoAlteracaoDoProduto == "9")
                        {
                            Console.WriteLine("Digite o novo centro de distribuição, ex. UF:");
                            string centroDeDistribuicao = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(centroDeDistribuicao))
                            {
                                Console.WriteLine("É obrigatório o centro de distribuição!");
                                centroDeDistribuicao = Console.ReadLine();
                                Console.Write("Centro de Distribuição Do Produto: " + centroDeDistribuicao + " Data da modificação: " + DateTime.Now);
                            }
                        }
                        if (EscolherOpcaoAlteracaoDoProduto == "10")
                        {
                            Console.WriteLine("A qual categoria, esse produto vai pertencer?");
                            {
                                Console.WriteLine("Digite SIM para categoria já cadastrada ou NÃO para cadastrar agora ");
                                string repetirCategoria = Console.ReadLine();

                                if (repetirCategoria.ToUpper() == "SIM")
                                {
                                    Console.WriteLine("Repita aqui o nome da categoria:   " + Categoria1.NomeCategoria + "  e Status:" + Categoria1.CadastroStatus());
                                    Console.WriteLine("Agora cadastre a subcategoria, digite o nome:");
                                    SubCategoria1.NomeCategoria = SubCategoria1.CadastrarSubCategoria();
                                }
                                else
                                {
                                    Console.WriteLine("Digite o nome da categoria");
                                    Categoria1.NomeCategoria = Categoria1.CadastrarCategoria();
                                    Console.WriteLine("Categoria: " + Categoria1.NomeCategoria + "  cadastrada com sucesso!  " + " Status : " + Categoria1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
                                }
                            }
                        }

                        if (EscolherOpcaoAlteracaoDoProduto == "11")
                        {
                            Console.WriteLine("Digite o novo nome da subcategoria:");
                            Regex r2 = new Regex(@"^[a-z A-Z ]{0,512}$");
                            string nomeDaSubCategoria = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(nomeDaSubCategoria) || !r2.IsMatch(nomeDaSubCategoria))
                            {
                                Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 512 caracteres!");
                                Console.Write("Nome Da subcategoria: "); break;
                            }
                            nomeDaSubCategoria = Console.ReadLine();
                        }
                        if (EscolherOpcaoAlteracaoDoProduto == "12")
                        {
                            Console.WriteLine("Digite qualquer tecla para sair:");
                            Console.ReadKey();
                        }
                        Produtos1.DescricaoDoProdutoNaLista();
                        Console.WriteLine($"Nome da Categoria: " + Categoria1.NomeCategoria);
                        Console.WriteLine($"Nome da Subcategoria: " + SubCategoria1.NomeSubCategoria);
                        Console.WriteLine();
                    }
                    break;
                case 8:
                    Console.WriteLine("Pesquise ou filtre itens da lista:");
                    ListaDeProdutos = new List<Produtos> { new Produtos(Produtos1.NomeDoProduto, Produtos1.DescricaoDoProduto, Produtos1.Peso, Produtos1.Altura, Produtos1.Largura, Produtos1.Comprimento, Produtos1.Valor, Produtos1.QuantidadeEmEstoque, Produtos1.CentroDeDistribuicao) };
                    {
                        Console.WriteLine("Insira o nome do Produto para pesquisá-lo na lista");
                        Produtos1.NomeDoProduto = Console.ReadLine();
                        Console.WriteLine();

                        var ListaDeProdutos0 = ListaDeProdutos.FindAll(p => p.Equals(Produtos1.NomeDoProduto)).ToString();
                        foreach (var item in ListaDeProdutos)
                        {
                            Produtos1.DescricaoDoProdutoNaLista();
                            Console.WriteLine($"Nome da Categoria: " + CategoriaX.NomeCategoria);
                            Console.WriteLine($"Nome da Subcategoria: " + SubCategoria1.NomeSubCategoria);
                            Console.WriteLine();
                            Console.WriteLine("Para fazer uma nova busca ou editar um produto, volte ao menu anterior");
                            Console.WriteLine();
                        }
                    }

                    break;
                case 9:
                    Console.WriteLine("Apenas Leitura e sair!");
                    {
                        Console.WriteLine("Ok, Não faça nada, apenas leia ou analise e aperte qualquer tecla para sair!");
                        Console.ReadKey();
                    }
                    break;

                default:
                    Console.WriteLine("Digite uma opção válida!");
                    break;
            }
        } while (EscolherOpcao != 9);
    }
}




//opção 1
     ////{
     ////    Console.WriteLine("Digite uma categoria:");
     ////    CategoriaX.NomeCategoria = CategoriaX.CadastrarCategoria();
     ////    Console.WriteLine("Categoria " + CategoriaX.NomeCategoria + "  cadastrada com sucesso!  " + "Status : " + CategoriaX.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
     ////}
     ////Console.WriteLine();
     ////Console.WriteLine("Deseja cadastrar mais uma categoria? Digite Sim OU não");
     ////string novaCategoria = Console.ReadLine();

////if (novaCategoria.ToUpper() == "SIM")
////{
////    Console.WriteLine("Digite o nome da categoria:");
////    CategoriaY.NomeCategoria = CategoriaY.CadastrarCategoria();
////    Console.WriteLine("Categoria " + CategoriaY.NomeCategoria + "  cadastrada com sucesso!  " + "Status : " + CategoriaY.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
////}
////else
////{
////    Console.WriteLine("Apenas 1 categoria cadastrada.");
////}
//using System;
//using System.Runtime.Serialization;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Globalization;
//using System.Text.RegularExpressions;
//using Sprint3_Ecommerce;
//using System.Collections;

//public class Program
//{
//        static void Main(string[] args)
//        {
//        Categoria CategoriaX = new Categoria();
//        Categoria CategoriaY = new Categoria();
//        SubCategoria SubCategoria1 = new SubCategoria();
//        List<Produtos> ListaDeProdutos = new List<Produtos>();
//        Produtos Produtos1 = new Produtos();
//        Regex r = new Regex(@"^[a-z A-Z ]{0,128}$");
//        Regex r1 = new Regex(@"^[a-z A-Z 0-9]{0,128}$");
//        int EscolherOpcao;
//        string nomeCategoria;
//        List<Categoria> ListaDeCategorias = new List<Categoria>();
//        Categoria Categorias1 = new Categoria();


//        do
//        {
//            Console.WriteLine();
//            Console.ForegroundColor = ConsoleColor.Blue;
//            Console.WriteLine("Bem vindo ao seu E-Commerce!");
//            Console.ResetColor();
//            Console.WriteLine("o que deseja fazer? \n" +
//                "Digite: 1 - Cadastrar categoria: \n" +
//                "Digite: 2 - Mostre a lista de categoria:\n" +
//                "Digite: 3 - Editar categoria: \n" +
//                "Digite: 4 - Cadastrar subcategoria: \n" +
//                "Digite: 5 - Editar subcategoria: \n" +
//                "Digite: 6 - Cadastrar um produto: \n" +
//                "Digite: 7 - Editar um produto: \n" +
//                "Digite: 8 - Pesquisar um produto: \n" +
//                "Digite: 9 - Apenas leitura e sair! ");
//            Console.WriteLine();
//            EscolherOpcao = int.Parse(Console.ReadLine());

//            switch (EscolherOpcao)
//            {
//                case 1:

//                    {
//                        Console.WriteLine("Digite uma categoria:");
//                        CategoriaX.NomeCategoria = CategoriaX.CadastrarCategoria();
//                        Console.WriteLine("Categoria " + CategoriaX.NomeCategoria + "  cadastrada com sucesso!  " + "Status : " + CategoriaX.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                    }
//                    Console.WriteLine();
//                    Console.WriteLine("Deseja cadastrar mais uma categoria? Digite Sim OU não");
//                    string novaCategoria = Console.ReadLine();

//                    if (novaCategoria.ToUpper() == "SIM")
//                    {
//                        Console.WriteLine("Digite o nome da categoria:");
//                        CategoriaY.NomeCategoria = CategoriaY.CadastrarCategoria();
//                        Console.WriteLine("Categoria " + CategoriaY.NomeCategoria + "  cadastrada com sucesso!  " + "Status : " + CategoriaY.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Apenas 1 categoria cadastrada.");
//                    }
//                    Console.WriteLine();
//                    break;

//                case 2:
//                   // List<Categoria> ListaDeCategorias = new List<Categoria>();
//                    Console.WriteLine("Mostre a lista de categorias:");
//                    {
//                        ListaDeCategorias.Add(CategoriaX);//pode puxar o bolo cadastarda em status tal
//                        ListaDeCategorias.Add(CategoriaY);

//                        {
//                            foreach (var item in ListaDeCategorias)
//                            {
//                                Console.WriteLine(item.NomeCategoria);
//                            }
//                        }
//                    }

//                    break;
//                case 3:
//                    //Categoria Categorias1 = new Categoria();
//                    Console.WriteLine("Qual categoria deseja alterar?");
//                    Categorias1.NomeCategoria = Console.ReadLine();
//                    {
//                        var ListaDeCategorias2 = ListaDeCategorias.FindAll(p => p.Equals(Categorias1.NomeCategoria)).ToString();
//                        foreach (var item in ListaDeCategorias)

//                            Console.WriteLine("escreva o novo nome da categoria:");//editar fala de novo sobre deseja alterar a categria/colocar junto com mostrar lista
//                            Categorias1.NomeCategoria = Categorias1.CadastrarCategoria();
//                            Console.WriteLine("Categoria " + Categorias1.NomeCategoria + "  editada com sucesso" + "  Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now );
//                            Console.WriteLine("Gostaria de alterar o status, digite SIM ou NÃO");
//                            string verificacaoStatus = Console.ReadLine();
//                            if (verificacaoStatus.ToUpper() == "SIM")
//                            {
//                                Categorias1.VerificacaoStatus();
//                                Console.WriteLine("Status : " + Categorias1.CadastroStatus() + " - Data da Modificação:" + DateTime.Now);
//                            }

//                    }

//            break;
//                case 4:
//                    //Console.WriteLine("A qual categoria, essa subcategoria vai pertencer ?"); aqui qual categoria
//                    //SubCategoria1.NomeSubCategoria = SubCategoria1.CadastrarSubComCategoria();
//                    {
//                        Console.WriteLine("A qual categoria, essa subcategoria vai pertencer ?");
//                        {
//                            Console.WriteLine("Digite SIM para categoria já cadastrada ou NÃO para cadastrar agora: ");
//                            string repetirCategoria = Console.ReadLine();

//                            if (repetirCategoria.ToUpper() == "SIM")
//                            {
//                                Console.WriteLine("Categoria cadastrada:   " + Categorias1.NomeCategoria + "  e Status:" + Categorias1.CadastroStatus());
//                                Console.WriteLine("Agora cadastre a subcategoria, digite o nome:");
//                                SubCategoria1.NomeSubCategoria = SubCategoria1.CadastrarSubCategoria();
//                            }
//                            else
//                            {
//                                Console.WriteLine("Digite o nome da categoria:");
//                                Categorias1.NomeCategoria = Categorias1.CadastrarCategoria();
//                                Console.WriteLine("Categoria " + Categorias1.NomeCategoria + "  cadastrada com sucesso!  " + " Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                                Console.WriteLine("Cadastre a subcategoria, digite o nome: ");
//                                SubCategoria1.NomeSubCategoria = SubCategoria1.CadastrarSubCategoria();
//                            }
//                        }
//                    }
//                    break;
//                case 5:
//                    {
//                        Console.WriteLine("Edite uma subcategoria:");
//                        SubCategoria1.EditarNomeSubCategoria();
//                        Console.WriteLine("Gostaria de alterar o status, digite SIM ou NÃO : ");
//                        string verificacaoStatus = Console.ReadLine();
//                        if (verificacaoStatus.ToUpper() == "SIM")
//                        {
//                            Categorias1.VerificacaoStatus();
//                            Console.WriteLine("Status : " + Categorias1.CadastroStatus() + " - Data da Modificação:" + DateTime.Now);
//                        }
//                    }
//                    break;
//                case 6: //pq não cadastro isso um metodo ai chama cadastrar produto 2
//                    {
//                        Console.WriteLine("Cadastre um produto:");
//                        {
//                            Console.Write("Nome Do Produto :  ");
//                            Produtos1.NomeDoProduto = Produtos1.ValidaNomeProduto();

//                            Console.Write("Descrição Do Produto: ");
//                            string descricaoDoProdutoCadastrado = Console.ReadLine();

//                            if (descricaoDoProdutoCadastrado.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProdutoCadastrado))
//                            {
//                                Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
//                                Console.Write("Descrição Do Produto: ");
//                                descricaoDoProdutoCadastrado = Console.ReadLine();
//                            }
//                            Produtos1.DescricaoDoProduto = descricaoDoProdutoCadastrado;

//                            Console.Write("Peso produto: ");
//                            decimal pesoCadastrado;
//                            pesoCadastrado = decimal.Parse(Console.ReadLine());
//                            Produtos1.Peso = pesoCadastrado;

//                            Console.Write("Altura produto: ");
//                            decimal alturaCadastrado;
//                            alturaCadastrado = decimal.Parse(Console.ReadLine());
//                            Produtos1.Altura = alturaCadastrado;

//                            Console.Write("Largura do produto: ");
//                            decimal larguraCadastrado;
//                            larguraCadastrado = decimal.Parse(Console.ReadLine());
//                            Produtos1.Largura = larguraCadastrado;

//                            Console.Write("Comprimento Do Produto: ");
//                            decimal comprimentoCadastrado;
//                            comprimentoCadastrado = decimal.Parse(Console.ReadLine());
//                            Produtos1.Comprimento = comprimentoCadastrado;

//                            Console.Write("Valor Do Produto: ");
//                            decimal valorCadastrado;
//                            valorCadastrado = decimal.Parse(Console.ReadLine());
//                            Produtos1.Valor = valorCadastrado;

//                            Console.Write("Quantidade Em estoque: ");
//                            int quantidadeEmEstoqueCadastrado;
//                            quantidadeEmEstoqueCadastrado = int.Parse(Console.ReadLine());
//                            Produtos1.QuantidadeEmEstoque = quantidadeEmEstoqueCadastrado;

//                            Console.Write("Centro De Distribuicao, exemplo Siglda da UF:  ");
//                            string centroDeDistribuicaoCadastrado = Console.ReadLine();
//                            if (string.IsNullOrWhiteSpace(centroDeDistribuicaoCadastrado))
//                            {
//                                Console.WriteLine("É obrigatório o centro de distribuição!");
//                                Console.Write("Centro de Distribuiçao: ");
//                                centroDeDistribuicaoCadastrado = Console.ReadLine();
//                            }
//                            Produtos1.CentroDeDistribuicao = centroDeDistribuicaoCadastrado;

//                            Console.WriteLine("A qual categoria, esse produto pertence? ");
//                            {
//                                Console.WriteLine("Digite SIM para categoria já cadastrada ou NÃO para cadastrar agora: ");
//                                string repetirCategoria = Console.ReadLine();

//                                if (repetirCategoria.ToUpper() == "SIM")
//                                {
//                                    Console.WriteLine("Categoria:   " + Categorias1.NomeCategoria + "  e Status:" + Categorias1.CadastroStatus());
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Digite o nome da categoria: ");
//                                    Categorias1.NomeCategoria = Categorias1.CadastrarCategoria();
//                                    Console.WriteLine("Categoria " + Categorias1.NomeCategoria + "  cadastrada com sucesso!  " + " Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                                }

//                            }

//                            Console.WriteLine("A qual subcategoria, esse produto pertence ?");
//                            {
//                                Console.WriteLine("Digite SIM para subcategoria já cadastrada ou NÃO para cadastrar agora: ");
//                                string repetirSubCategoria = Console.ReadLine();

//                                if (repetirSubCategoria.ToUpper() == "SIM")
//                                {
//                                    Console.WriteLine("Subcategoria:   " + SubCategoria1.NomeSubCategoria + "  e Status:" + Categorias1.CadastroStatus());
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Digite o nome da Subcategoria");
//                                    SubCategoria1.NomeSubCategoria = SubCategoria1.CadastrarCategoria();
//                                    Console.WriteLine("Categoria " + SubCategoria1.NomeSubCategoria + "  cadastrada com sucesso!  " + " Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                                }
//                            }
//                            ListaDeProdutos.Add(new Produtos(Produtos1.NomeDoProduto, Produtos1.DescricaoDoProduto, Produtos1.Peso, Produtos1.Altura, Produtos1.Largura, Produtos1.Comprimento, Produtos1.Valor, Produtos1.QuantidadeEmEstoque, Produtos1.CentroDeDistribuicao)) ; 
//                            Console.WriteLine("Produtos adicionados com sucesso! Com Status: Ativo. Data da criaçao:" + DateTime.Now);
//                            Console.WriteLine();

//                            var ListaDeProdutos1 = ListaDeProdutos.FindAll(p => p.Equals(Produtos1.NomeDoProduto)).ToString();
//                            foreach (

//                                var item in ListaDeProdutos)
//                            {
//                                Console.WriteLine("Segue produto adicionado : ");
//                            }
//                                 Produtos1.DescricaoDoProdutoNaLista();
//                            Console.WriteLine($"Nome da Categoria: " +  Categorias1.NomeCategoria);
//                            Console.WriteLine($"Nome da Subcategoria: " + SubCategoria1.NomeSubCategoria);
//                            Console.WriteLine();

//                        }
//                    }
//                    break;
//                case 7:
//                    {
//                        decimal pesoCadastrado;
//                        decimal alturaCadastrado;
//                        decimal larguraCadastrado;
//                        decimal comprimentoCadastrado;
//                        decimal valorCadastrado;
//                        int quantidadeEmEstoqueCadastrado;

//                        Console.WriteLine("Qual produto deseja editar");
//                        Produtos1.NomeDoProduto = Console.ReadLine();

//                        var ListaDeProdutos2 = ListaDeProdutos.FindAll(p => p.Equals(Produtos1.NomeDoProduto)).ToString();
//                        foreach (var item in ListaDeProdutos)
//                        {
//                            Produtos1.DescricaoDoProdutoNaLista();
//                            Console.WriteLine();
//                        }

//                        Console.WriteLine("Qual item deseja editar? \n" +
//                        "Digite: 1 - para alterar o nome do produto: \n" +
//                        "Digite: 2 - para alterar a descrição do produto: \n" +
//                        "Digite: 3 - para alterar o peso do produto: \n" +
//                        "Digite: 4 - para alterar a  altura do produto: \n" +
//                        "Digite: 5 - para alterar a largura do produto: \n" +
//                        "Digite: 6 - para alterar o comprimento do produto: \n" +
//                        "Digite: 7 - para alterar o valor do produto: \n" +
//                        "Digite: 8 - para alterar a quantidade em estoque: \n" +
//                        "Digite: 9 - para alterar o centro de distribuição: \n" +
//                        "Digite: 10 - para alterar o nome da categoria: \n" +
//                        "Digite: 11 - para alterar o nome da subcategoria: \n" +
//                        "Digite: 12 - Deseja alterar outro item ou apenas sair! ");
//                        Console.WriteLine();

//                        string EscolherOpcaoAlteracaoDoProduto = Console.ReadLine();

//                        if (EscolherOpcaoAlteracaoDoProduto == "1")
//                        {
//                            Console.WriteLine("Digite o novo nome do produto: ");
//                            Produtos1.ValidaNomeProduto();
//                            Console.Write("Nome Do Produto:  "  +  Produtos1.NomeDoProduto + " Data da modificação:" + DateTime.Now);
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "2")
//                        {
//                            Console.WriteLine("Digite a nova descrição do produto:");
//                            string descricaoDoProdutoCadastrado = Console.ReadLine();
//                            if (descricaoDoProdutoCadastrado.Length >= 512 || string.IsNullOrWhiteSpace(descricaoDoProdutoCadastrado))
//                            {
//                                Console.WriteLine("É obrigatório a descrição do produto, com letras e números até 512 caracteres!");
//                                descricaoDoProdutoCadastrado = Console.ReadLine();
//                                Console.Write("Descrição Do Produto:  "  +  descricaoDoProdutoCadastrado + " Data da modificação: " + DateTime.Now);
//                            }
//                            Console.WriteLine("a descrição é: " + descricaoDoProdutoCadastrado);
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "3")
//                        {
//                            Console.WriteLine("Digite o novo peso do produto:");
//                            while (!decimal.TryParse(Console.ReadLine(), out pesoCadastrado))
//                            {
//                                Console.WriteLine("Sem espaço e somente números decimais!");
//                            }
//                            Produtos1.Peso = pesoCadastrado;
//                            Console.Write("Peso Do Produto: " + Produtos1.Peso + " Data da modificação: " + DateTime.Now);
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "4")
//                        {
//                            Console.WriteLine("Digite a nova altura do produto:");
//                            while (!decimal.TryParse(Console.ReadLine(), out alturaCadastrado))
//                            {
//                                Console.WriteLine("Sem espaço e somente números decimais!");
//                            }
//                            Produtos1.Altura = alturaCadastrado;
//                            Console.Write("Altura Do Produto: " +  Produtos1.Altura + " Data da modificação: " + DateTime.Now);
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "5")
//                        {
//                            Console.WriteLine("Digite a nova largura do produto:");
//                            while (!decimal.TryParse(Console.ReadLine(), out larguraCadastrado))
//                            {
//                                Console.WriteLine("Sem espaço e somente números decimais!");
//                            }
//                            Produtos1.Largura = larguraCadastrado;
//                            Console.Write("Largura Do Produto: " + Produtos1.Largura + " Data da modificação: " + DateTime.Now);
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "6")
//                        {
//                            Console.WriteLine("Digite o novo comprimento do produto:");
//                            while (!decimal.TryParse(Console.ReadLine(), out comprimentoCadastrado))
//                            {
//                                Console.WriteLine("Sem espaço e somente números decimais!");
//                            }
//                           Produtos1.Comprimento = comprimentoCadastrado;
//                            Console.Write("Comprimento Do Produto: " + Produtos1.Comprimento + " Data da modificação: " + DateTime.Now);
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "7")
//                        {
//                            Console.WriteLine("Digite o novo valor do produto:");
//                            while (!decimal.TryParse(Console.ReadLine(), out valorCadastrado))
//                            {
//                                Console.WriteLine("Sem espaço e somente números decimais!");
//                            }
//                            Produtos1.Valor = valorCadastrado;
//                            Console.Write("Valor Do Produto: " +  Produtos1.Valor + " Data da modificação: " + DateTime.Now);
//                        }
//                        if (EscolherOpcaoAlteracaoDoProduto == "8")
//                        {
//                            Console.WriteLine("Digite a nova quantidade em estoque do produto:");
//                            while (!int.TryParse(Console.ReadLine(), out quantidadeEmEstoqueCadastrado))
//                            {
//                                Console.WriteLine("Sem espaço e somente números decimais!");
//                            }
//                        Produtos1.QuantidadeEmEstoque = quantidadeEmEstoqueCadastrado;
//                            Console.Write("Quantidade em estoque Do Produto: " + Produtos1.QuantidadeEmEstoque + " Data da modificação: " + DateTime.Now);
//                        }
//                        if (EscolherOpcaoAlteracaoDoProduto == "9")
//                        {
//                            Console.WriteLine("Digite o novo centro de distribuição, ex. UF:");
//                            string centroDeDistribuicao = Console.ReadLine();
//                            if (string.IsNullOrWhiteSpace(centroDeDistribuicao))
//                            {
//                                Console.WriteLine("É obrigatório o centro de distribuição!");
//                                centroDeDistribuicao = Console.ReadLine();
//                                Console.Write("Centro de Distribuição Do Produto: " + centroDeDistribuicao + " Data da modificação: " + DateTime.Now);
//                            }
//                        }
//                        if (EscolherOpcaoAlteracaoDoProduto == "10")
//                        {
//                            Console.WriteLine("A qual categoria, esse produto vai pertencer?");
//                            {
//                                Console.WriteLine("Digite SIM para categoria já cadastrada ou NÃO para cadastrar agora ");
//                                string repetirCategoria = Console.ReadLine();

//                                if (repetirCategoria.ToUpper() == "SIM")
//                                {
//                                    Console.WriteLine("Repita aqui o nome da categoria:   " + Categorias1.NomeCategoria + "  e Status:" + Categorias1.CadastroStatus());
//                                    Console.WriteLine("Agora cadastre a subcategoria, digite o nome:");
//                                    SubCategoria1.NomeCategoria = SubCategoria1.CadastrarSubCategoria();
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Digite o nome da categoria");
//                                    Categorias1.NomeCategoria = Categorias1.CadastrarCategoria();
//                                    Console.WriteLine("Categoria: " + Categorias1.NomeCategoria + "  cadastrada com sucesso!  " + " Status : " + Categorias1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//                                }
//                            }
//                        }

//                        if (EscolherOpcaoAlteracaoDoProduto == "11")
//                        {
//                            Console.WriteLine("Digite o novo nome da subcategoria:");
//                            Regex r2 = new Regex(@"^[a-z A-Z ]{0,512}$");
//                            string nomeDaSubCategoria = Console.ReadLine();
//                            while (string.IsNullOrWhiteSpace(nomeDaSubCategoria) || !r2.IsMatch(nomeDaSubCategoria))
//                            {
//                                Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 512 caracteres!");
//                                Console.Write("Nome Da subcategoria: "); break;
//                            }
//                            nomeDaSubCategoria = Console.ReadLine();
//                        }
//                        if (EscolherOpcaoAlteracaoDoProduto == "12")
//                        {
//                            Console.WriteLine("Digite qualquer tecla para sair:");
//                            Console.ReadKey();
//                        }
//                        Produtos1.DescricaoDoProdutoNaLista();
//                        Console.WriteLine($"Nome da Categoria: " + Categorias1.NomeCategoria);
//                        Console.WriteLine($"Nome da Subcategoria: " + SubCategoria1.NomeSubCategoria);
//                        Console.WriteLine();
//                    }
//                    break;
//                case 8:
//                    Console.WriteLine("Pesquise ou filtre itens da lista:");
//                    ListaDeProdutos = new List<Produtos> { new Produtos(Produtos1.NomeDoProduto, Produtos1.DescricaoDoProduto, Produtos1.Peso, Produtos1.Altura, Produtos1.Largura, Produtos1.Comprimento, Produtos1.Valor, Produtos1.QuantidadeEmEstoque, Produtos1.CentroDeDistribuicao)}; 
//                        {
//                        Console.WriteLine("Insira o nome do Produto para pesquisá-lo na lista");
//                        Produtos1.NomeDoProduto = Console.ReadLine();
//                        Console.WriteLine();

//                        var ListaDeProdutos0 = ListaDeProdutos.FindAll(p => p.Equals(Produtos1.NomeDoProduto)).ToString();
//                           foreach (var item in ListaDeProdutos)
//                           {
//                           Produtos1.DescricaoDoProdutoNaLista();
//                            Console.WriteLine($"Nome da Categoria: " + CategoriaX.NomeCategoria);
//                            Console.WriteLine($"Nome da Subcategoria: " + SubCategoria1.NomeSubCategoria);
//                            Console.WriteLine();
//                            Console.WriteLine("Para fazer uma nova busca ou editar um produto, volte ao menu anterior");
//                            Console.WriteLine();
//                           }
//                        }
//                  break;
//                  case 9:
//                    Console.WriteLine("Apenas Leitura e sair!");
//                    {
//                     Console.WriteLine("Ok, Não faça nada, apenas leia ou analise e aperte qualquer tecla para sair!");
//                     Console.ReadKey();
//                    }
//                    break;

//                default:
//                    Console.WriteLine("Digite uma opção válida!");
//                    break;
//            }
//           } while (EscolherOpcao != 9);
//        }
//}


