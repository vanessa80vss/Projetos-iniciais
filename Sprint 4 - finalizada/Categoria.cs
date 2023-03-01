using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;
using System.Text.RegularExpressions;

namespace Sprint3_Ecommerce
{
    public class Categoria
    {
        public string NomeCategoria { get; set; }
        public string EditeNomeCategoria { get; set; }
        public bool StatusCategoria { get; set; } = true;
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public DateTime DataModificacao { get; private set; } = DateTime.Now;

        public Regex r = new Regex(@"^[a-z A-Z ]{0,128}$");

        public string EscolherStatusDeCategoria;

        public string editarNomeCategoria;

        public Categoria()
        {

        }
        public string CadastrarCategoria() //ta passando objeto p ele, precisa de retorno, vários argumentos. 
        {
            string nomeCategoria = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nomeCategoria) || !r.IsMatch(nomeCategoria))
            {
                Console.WriteLine("É obrigatório o nome da categoria, somente letras  até 128 caracteres!");
                nomeCategoria = Console.ReadLine();
            }
            return nomeCategoria;
        }


        public string EditarNomeCategoria()
        {
            Console.WriteLine("Gostaria de editar uma categoria? Digite SIM ou NÃO :");
            string escolherEditarNomeCategoria = Console.ReadLine();
            {
                if (escolherEditarNomeCategoria.ToUpper() == "SIM")
                    Console.WriteLine("Digite o novo nome da categoria:");
                string nomeCategoria = Console.ReadLine();
                Console.WriteLine("Categoria " + nomeCategoria + "  editada com sucesso!  " + "Status : " + CadastroStatus() + " - Data da Modificação:" + DateTime.Now);

            }
            return editarNomeCategoria;
        }
        public string CadastroStatus()
        {
            if (StatusCategoria)
                return "Ativo";
            else
                return "Inativo";
        }

        public void VerificacaoStatus()
        {
            StatusCategoria = !StatusCategoria;
        }

        


    }
}


//public virtual List<Categoria> AdicionandoCategorias(string CategoriaX, string CategoriaY)
//{
//    string CategoriaX = categoriax;
//    string CategoriaY = categoriay;
//    return new List<Categoria>();
//}

//public virtual string MostrarLista()
//{
//    List<Categoria> ListaDeCategorias = new List<Categoria>();
//    {
//        ListaDeCategorias.Add(CategoriaX);
//        ListaDeCategorias.Add(CategoriaY);


//        {
//            foreach (var item in ListaDeCategorias)
//            {
//                if (item.Equals()) ;
//                Console.WriteLine(item.ToString());


//            }
//            return "lista adicionada.";

//        }



//    }
//}

//{
//    ListaDeCategorias.Add(Categoria1);
//    ListaDeCategorias.Add(Categoria2);

//    Console.WriteLine("Mostre a lista de categorias:");
//    // string busca = Console.ReadLine();

//    {
//        foreach (var item in ListaDeCategorias)
//        {
//            //if (item.Equals()) ;
//            Console.WriteLine(item.ToString());


//        }
//    }
//}
////foreach (Categoria item in ListaDeCategorias)
////{
////    Console.WriteLine(item.ToList());
////Console.WriteLine("Categoria pesquisada: ");
////}

//public ListaDeCategorias(string CategoriaX, string CategoriaY)
//{
//    CategoriaX = categoriaX;
//    CategoriaY = categoriaY;
//}

//{
//    foreach (var item in ListaDeCategorias)
//    {
//        Console.WriteLine(item);
//    }
//}



//{
//    string AlteraCategoria = Console.ReadLine();

//    if (AlteraCategoria == CategoriaX.NomeCategoria) ;
//    Console.WriteLine("escreva o novo nome da categoria:");
//    CategoriaX.NomeCategoria = CategoriaX.CadastrarCategoria();
//    Console.WriteLine("Categoria " + CategoriaX.NomeCategoria + "  editada com sucesso!  " + "Status : " + CategoriaX.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//    Console.WriteLine("Gostaria de alterar o status, digite SIM ou NÃO");
//    string verificacaoStatus = Console.ReadLine();
//    if (verificacaoStatus.ToUpper() == "SIM")
//    {
//        CategoriaX.VerificacaoStatus();
//        Console.WriteLine("Status : " + CategoriaX.CadastroStatus() + " - Data da Modificação:" + DateTime.Now);
//    }
//}


//ListaDeCategorias = new List<Categoria> { new Categorias1(CategoriaX, CategoriaY) };
//{
//    Console.WriteLine("Insira o nome da categoria para pesquisá-la na lista e alterar");
//    Categorias1.NomeCategoria = Console.ReadLine();
//    Console.WriteLine();

//    var ListaDeCategorias0 = ListaDeCategorias.FindAll(p => p.Equals(Categorias1.NomeCategoria)).ToString();
//    foreach (var item in ListaDeCategorias)
//    {
//        //Produtos1.DescricaoDoProdutoNaLista();


//        var ListaDeCategorias1 = ListaDeCategorias.FindAll(p => p.Equals(CategoriaX.NomeCategoria)).ToString();
//        foreach (var item in ListaDeCategorias)
//        {
//            Console.WriteLine("Categoria: " + CategoriaX.NomeCategoria + "editada com sucesso");
//        }

//    }