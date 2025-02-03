using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

class Program
{
    static string chamadosFile = "chamados.json";
    static string melhoriasFile = "melhorias.json";
    static List<Chamado> chamados = new List<Chamado>();
    static List<string> melhorias = new List<string>();

    static void Main()
    {
        CarregarDados();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Controle de Qualidade - QA ===");
            Console.WriteLine("1. Registrar Chamado");
            Console.WriteLine("2. Listar Chamados");
            Console.WriteLine("3. Apagar Chamado");
            Console.WriteLine("4. Ver Estatísticas");
            Console.WriteLine("5. Adicionar Melhoria");
            Console.WriteLine("6. Ver Melhorias");
            Console.WriteLine("7. Apagar Melhoria");
            Console.WriteLine("8. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1": RegistrarChamado(); break;
                case "2": ListarChamados(); break;
                case "3": ApagarChamado(); break;
                case "4": VerEstatisticas(); break;
                case "5": AdicionarMelhoria(); break;
                case "6": VerMelhorias(); break;
                case "7": ApagarMelhoria(); break;
                case "8": SalvarDados(); return;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }
    }

    static void RegistrarChamado()
    {
        Console.Clear();
        Console.WriteLine("Registro de Chamado");
        Console.Write("ID do chamado: ");
        string id = Console.ReadLine();

        Console.WriteLine("1. Bug");
        Console.WriteLine("2. Reclamação");
        Console.WriteLine("3. Sugestão");
        Console.Write("Escolha a categoria: ");

        string categoria = Console.ReadLine();
        if (categoria == "1") categoria = "Bug";
        else if (categoria == "2") categoria = "Reclamação";
        else if (categoria == "3") categoria = "Sugestão";
        else { Console.WriteLine("Categoria inválida!"); return; }

        Console.Write("Descrição do chamado: ");
        string descricao = Console.ReadLine();

        chamados.Add(new Chamado { Id = id, Categoria = categoria, Descricao = descricao, DataRegistro = DateTime.Now });
        Console.WriteLine("Chamado registrado com sucesso!");
        SalvarDados();
        Console.ReadKey();
    }

    static void ListarChamados()
    {
        Console.Clear();
        if (chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado registrado.");
        }
        else
        {
            Console.WriteLine("Lista de Chamados:");
            foreach (var chamado in chamados)
            {
                Console.WriteLine($"ID: {chamado.Id}, Categoria: {chamado.Categoria}, Descrição: {chamado.Descricao}, Data: {chamado.DataRegistro:dd/MM/yyyy HH:mm}");
            }
        }
        Console.ReadKey();
    }

    static void ApagarChamado()
    {
        Console.Clear();
        Console.Write("Digite o ID do chamado a ser apagado: ");
        string id = Console.ReadLine();
        var chamado = chamados.FirstOrDefault(c => c.Id == id);
        if (chamado != null)
        {
            chamados.Remove(chamado);
            Console.WriteLine("Chamado apagado com sucesso!");
            SalvarDados();
        }
        else
        {
            Console.WriteLine("Chamado não encontrado!");
        }
        Console.ReadKey();
    }

    static void VerEstatisticas()
    {
        Console.Clear();
        if (chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado registrado.");
        }
        else
        {
            var agrupados = chamados.GroupBy(c => c.Categoria)
                                    .Select(g => new { Categoria = g.Key, Quantidade = g.Count() })
                                    .ToList();

            foreach (var item in agrupados)
            {
                double percentual = (item.Quantidade / (double)chamados.Count) * 100;
                Console.WriteLine($"{item.Categoria}: {item.Quantidade} chamados ({percentual:F2}%)");
            }
        }
        Console.ReadKey();
    }

    static void AdicionarMelhoria()
    {
        Console.Clear();
        Console.Write("Digite sua sugestão de melhoria: ");
        string melhoria = Console.ReadLine();
        melhorias.Add(melhoria);
        Console.WriteLine("Melhoria adicionada!");
        SalvarDados();
        Console.ReadKey();
    }

    static void VerMelhorias()
    {
        Console.Clear();
        if (melhorias.Count == 0)
        {
            Console.WriteLine("Nenhuma melhoria registrada.");
        }
        else
        {
            Console.WriteLine("Lista de Melhorias:");
            for (int i = 0; i < melhorias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {melhorias[i]}");
            }
        }
        Console.ReadKey();
    }

    static void ApagarMelhoria()
    {
        Console.Clear();
        Console.Write("Digite o número da melhoria a ser apagada: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= melhorias.Count)
        {
            melhorias.RemoveAt(index - 1);
            Console.WriteLine("Melhoria apagada com sucesso!");
            SalvarDados();
        }
        else
        {
            Console.WriteLine("Número inválido!");
        }
        Console.ReadKey();
    }

    static void SalvarDados()
    {
        File.WriteAllText(chamadosFile, JsonConvert.SerializeObject(chamados, Newtonsoft.Json.Formatting.Indented));
        File.WriteAllText(melhoriasFile, JsonConvert.SerializeObject(melhorias, Newtonsoft.Json.Formatting.Indented));
    }

    static void CarregarDados()
    {
        if (File.Exists(chamadosFile))
            chamados = JsonConvert.DeserializeObject<List<Chamado>>(File.ReadAllText(chamadosFile)) ?? new List<Chamado>();

        if (File.Exists(melhoriasFile))
            melhorias = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(melhoriasFile)) ?? new List<string>();
    }
}

class Chamado
{
    public string Id { get; set; }
    public string Categoria { get; set; }
    public string Descricao { get; set; }
    public DateTime DataRegistro { get; set; }
}
