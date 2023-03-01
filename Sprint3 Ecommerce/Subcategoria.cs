using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Sprint3_Ecommerce
{
    public class SubCategoria : Categoria
    {
        public string NomeSubCategoria;
        public string EditeNomeSubCategoria { get; set; }
        public string StatusSubCategoria { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }

        Categoria Categoria1 = new Categoria();
        public string nomeCategoria;
        public SubCategoria()
        {

        }
      
        public string CadastrarSubCategoria()
        {
            string nomeSubCategoria = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nomeSubCategoria) || !r.IsMatch(nomeSubCategoria))
            {
                Console.WriteLine("É obrigatório o nome da Subcategoria, somente letras  até 128 caracteres!");
                nomeSubCategoria = Console.ReadLine();
            }
            Console.WriteLine("Subcategoria " + nomeSubCategoria + "  cadastrada com sucesso!  -" + " Status:  Ativo " + " Data da criaçao:" + DateTime.Now);
            return nomeSubCategoria;
        }

        public string EditarNomeSubCategoria()
        {
            Console.WriteLine("Edite o novo nome da subcategoria:");
            string newnome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newnome) || !r.IsMatch(newnome))
            {
                Console.WriteLine("É obrigatório o nome da subcategoria, somente letras  até 128 caracteres!");
                newnome = Console.ReadLine();
            }
            Console.WriteLine("SubCategoria " + newnome + "  editada com sucesso! - Status:  " + CadastroStatus() + " Data da criaçao:" + DateTime.Now);
            return newnome;
        }
    }
}





//public string CadastrarSubCategoria() - ver com o Gabs se esse raciocinio está certo
//{
//    Console.WriteLine("Informe o nome da Subcategoria:");
//    string nomeSubCategoria = Console.ReadLine();
//    categoria1.NomeCategoria = categoria1.CadastrarCategoria();
//}
//   return nomeSubCategoria;
//Console.WriteLine("Subcategoria " + nomeCategoria + "  cadastrada com sucesso!  -" + " Status:  Ativo " + " Data da criaçao:");

//public string CadastrarSubComCategoria()
//{
//        Console.WriteLine("Digite SIM para categoria já cadastrada ou NÃO para cadastrar agora: ");
//        string repetirCategoria = Console.ReadLine();

//        if (repetirCategoria.ToUpper() == "SIM")
//        {
//            Console.WriteLine("Categoria cadastrada:   " + nomeCategoria + "  e Status:" + Categoria1.CadastroStatus());
//            Console.WriteLine("Agora cadastre a subcategoria, digite o nome:");
//            NomeSubCategoria = CadastrarSubCategoria();
//        }
//        else
//        {
//            Console.WriteLine("Digite o nome da categoria:");
//            Categoria1.NomeCategoria = Categoria1.CadastrarCategoria();
//            Console.WriteLine("Categoria " + Categoria1.NomeCategoria + "  cadastrada com sucesso!  " + "Status : " + Categoria1.CadastroStatus() + " - Data da criaçao:" + DateTime.Now);
//            Console.WriteLine("Cadastre a subcategoria, digite o nome: ");
//            NomeSubCategoria = CadastrarSubCategoria();
//        } return repetirCategoria;
//} 



//public void VerificacaoStatus()
//{
//    StatusCategoria = !StatusCategoria;
//}


//public string CadastroStatus()
//{
//    if (StatusCategoria)
//        return "Ativo";
//    else
//        return "Inativo";
//}

//    public void VerificacaoStatus()
//    {
//        Regex R1 = new Regex("[1 - 2]");
//        EscolherStatusDeCategoria = (Console.ReadLine());
//        bool TestStatus = R1.IsMatch(EscolherStatusDeCategoria);

//        while (!TestStatus)
//        {
//            Console.WriteLine("Digite uma opção válida !");
//            Console.WriteLine("Status está ativo, digite 1 para manter ou 2 para alterar: ");
//            EscolherStatusDeCategoria = (Console.ReadLine());
//            break;
//        }

//        do
//        {
//            switch (EscolherStatusDeCategoria)
//            {
//                case "1":
//                    StatusCategoria = "Ativo";
//                    Console.WriteLine("Ok, Mantido: Status Ativo!");
//                    break;

//                case "2":
//                    StatusCategoria = "Inativo";
//                    Console.WriteLine("Ok, Alterado Status Inativo!");
//                    break;

//                default:
//                    Console.WriteLine("Digite uma opção válida: 1 para Ativar ou 2 para Inativar!");
//                    break;
//            }
//        } while (!true);

//    }





