
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Objetos;
using Name;
using System.Diagnostics;




namespace Name

{
   
public static class Menu
{
    // Movendo a declaração do array de vagas para um escopo mais amplo
    private static Vaga[] vagas = new Vaga[11]; 

    public static void Principal()
    {
        Console.WriteLine("Bem Vindo!");
        Console.WriteLine("Selecione uma das opções:");
        Console.WriteLine("1 - Cadastrar");        
        Console.WriteLine("2 - Verificar");
        Console.WriteLine("3 - Pagar");
        Console.WriteLine("4 - Sair"); 

        int Choose = Convert.ToInt32(Console.ReadLine());
        switch(Choose)
        {
            case 1:
            Cadastrar();
            break;
            case 2:
            Verificar();
            break;
            case 3:
            Excluir();
            break;
            case 4:
            Sair();
            break;
        }
            
    }

        //Funçoes do Menu Principal//
        public static void Cadastrar()
        {
           
           Console.WriteLine("Vamos cadastrar");
           try
            {
                Console.WriteLine("Digite um número da vaga:");
                int vagaNova = Convert.ToInt32(Console.ReadLine());

                if(vagaNova < 11){
                    vagas[vagaNova] = new Vaga
                    {
                        CVaga = vagaNova
                    };

                    Console.WriteLine("Qual a Placa do Carro?");
                    string Placa = Console.ReadLine();
                    vagas[vagaNova].CPlaca = Placa;

                    Console.WriteLine($"Carro cadastrado com sucesso\n verifique os dados");
                    Console.WriteLine($"Vaga: {vagas[vagaNova].CVaga}\nPlaca: {vagas[vagaNova].CPlaca} \n(S/N)");
                    string decisao =Console.ReadLine();
                    if(decisao.ToLower() == "s"){
                        Console.WriteLine("Cadastrado com sucesso");
                        Menu.Principal();}
                        else{ Console.Clear();Cadastrar();}
                }
                else
                {
                Console.Clear();

                Console.WriteLine("Vaga nao existente !");
                Cadastrar();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, digite um número válido.");
                Cadastrar();
            }
           
           
        }

        
        public static void Verificar()
        
        {
             
             Console.WriteLine("Vamos verificar!");
             Console.WriteLine("As vagas ocupadas são:");

        for (int i = 0; i < vagas.Length; i++)
        {
            if (vagas[i] != null)
            {
                Console.WriteLine($"Vaga: {vagas[i].CVaga}\nPlaca: {vagas[i].CPlaca}");
            }
        }
        Console.Clear();
        Menu.Principal();
        }


public static void Excluir()
{
    try
    {
        Console.WriteLine("Digite o número da vaga que deseja liberar:");
        int vagaExcluir = Convert.ToInt32(Console.ReadLine());

        if (vagaExcluir >= 0 && vagaExcluir < vagas.Length)
        {
            if (vagas[vagaExcluir] != null)
            {
                Console.WriteLine("quantas horas o carro ficou estacionado?");
                int hrsparking = Convert.ToInt32(Console.ReadLine());
                hrsparking = hrsparking * 60;
                Console.WriteLine($"o Valor foi de R${hrsparking}");
                Console.WriteLine("JA foi pago ?");
                string pg = Console.ReadLine();
                pg = pg.ToLower();
                if(pg =="s" || pg == "sim"){
                Console.WriteLine($"Vaga {vagaExcluir} liberada. Carro com placa {vagas[vagaExcluir].CPlaca} foi removido.");
                vagas[vagaExcluir] = null;}
                else{Excluir();}
            }
            else
            {
                Console.WriteLine("Esta vaga já está vazia.");
            }
        }
        else
        {
            Console.WriteLine("Vaga inválida. Por favor, insira um número de vaga válido.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Por favor, digite um número válido para a vaga.");
    }
}

        public static void Sair()
        {
            Environment.Exit(0);
        }


}
}

