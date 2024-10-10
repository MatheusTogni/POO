//só sucesso
using System;
using Classes;
using Interfaces;

class Program
{
    static void Main(string[] args)
    {
        ISpeciesCatalog speciesCatalog = new SpeciesCatalog();
        IHabitatCatalog habitatCatalog = new HabitatCatalog();
        IReport report = new Report(speciesCatalog, habitatCatalog);
        int choice = 0;

        do
        {
            DisplayMenu();
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                ExecuteChoice(choice, speciesCatalog, habitatCatalog, report);
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.\n");
            }

        } while (choice != 8);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("### Menu ###");
        Console.WriteLine("1. Catalogar espécie");
        Console.WriteLine("2. Alterar status da espécie");
        Console.WriteLine("3. Mostrar relatório da espécie (por ID)");
        Console.WriteLine("4. Mostrar todas as espécies catalogadas");
        Console.WriteLine("5. Catalogar habitat");
        Console.WriteLine("6. Mostrar todos os habitats catalogados");
        Console.WriteLine("7. Associar habitat a uma espécie");
        Console.WriteLine("8. Sair do programa");
        Console.Write("Escolha uma opção: ");
    }

    static void ExecuteChoice(int choice, ISpeciesCatalog speciesCatalog, IHabitatCatalog habitatCatalog, IReport report)
    {
        switch (choice)
        {
            case 1:
                CatalogSpecies(speciesCatalog);
                break;
            case 2:
                ChangeSpeciesStatus(speciesCatalog);
                break;
            case 3:
                ShowSpeciesReport(report);
                break;
            case 4:
                ShowAllSpecies(report);
                break;
            case 5:
                CatalogHabitat(habitatCatalog);
                break;
            case 6:
                ShowAllHabitats(report);
                break;
            case 7:
                AssociateHabitatToSpecies(speciesCatalog, habitatCatalog);
                break;
            case 8:
                Console.WriteLine("Encerrando o programa...");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.\n");
                break;
        }
    }

    static void CatalogSpecies(ISpeciesCatalog speciesCatalog)
    {
        int id = GetValidatedSpeciesId(speciesCatalog);
        string name = GetValidatedSpeciesName(speciesCatalog);
        string status = GetValidatedSpeciesStatus();

        ISpecies newSpecies = new Species(id, name, status);
        speciesCatalog.CatalogSpecies(newSpecies);
    }

    static int GetValidatedSpeciesId(ISpeciesCatalog speciesCatalog)
    {
        int id;
        bool validId = false;

        do
        {
            Console.Write("Digite o ID da espécie: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out id) && id > 0 && !speciesCatalog.IsIdInUse(id))
            {
                validId = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida ou ID já está sendo usado. Digite um número válido.\n");
            }

        } while (!validId);

        return id;
    }

    static string GetValidatedSpeciesName(ISpeciesCatalog speciesCatalog)
    {
        string name;
        bool validName = false;

        do
        {
            Console.Write("Digite o nome da espécie: ");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Nome não pode ser nulo ou vazio. Digite um nome válido.\n");
            }
            else if (speciesCatalog.IsNameInUse(name))
            {
                Console.WriteLine($"Nome {name} já está sendo usado. Digite um nome diferente.\n");
            }
            else
            {
                validName = true;
            }
        } while (!validName);

        return name;
    }

    static void ChangeSpeciesStatus(ISpeciesCatalog speciesCatalog)
    {
        if (speciesCatalog.GetAllSpecies().Count == 0)
        {
            Console.WriteLine("Não há espécies catalogadas.\n");
            return;
        }

        int id = GetValidatedSpeciesId(speciesCatalog);
        ISpecies species = speciesCatalog.GetSpeciesById(id);
        if (species != null)
        {
            string newStatus = GetValidatedSpeciesStatus();
            species.ChangeStatus(newStatus);
        }
        else
        {
            Console.WriteLine("Espécie não encontrada.\n");
        }
    }

    static void ShowSpeciesReport(IReport report)
    {
        if (report.GetSpeciesCatalog().GetAllSpecies().Count == 0)
        {
            Console.WriteLine("Não há espécies catalogadas.\n");
            return;
        }

        int id = GetValidatedSpeciesId(report.GetSpeciesCatalog());
        report.DisplaySpeciesById(id);
    }

    static void ShowAllSpecies(IReport report)
    {
        report.DisplayAllSpecies();
    }

    static void CatalogHabitat(IHabitatCatalog habitatCatalog)
    {
        int id = GetValidatedHabitatId(habitatCatalog);
        string name = GetValidatedHabitatName(habitatCatalog);
        string description = GetValidatedHabitatDescription();

        IHabitat newHabitat = new Habitat(id, name, description);
        habitatCatalog.CatalogHabitat(newHabitat);
    }

    static int GetValidatedHabitatId(IHabitatCatalog habitatCatalog)
    {
        int id;
        bool validId = false;

        do
        {
            Console.Write("Digite o ID do habitat: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out id) && id > 0 && !habitatCatalog.IsIdInUse(id))
            {
                validId = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida ou ID já está sendo usado. Digite um número válido.\n");
            }

        } while (!validId);

        return id;
    }

    static string GetValidatedHabitatName(IHabitatCatalog habitatCatalog)
    {
        string name;
        bool validName = false;

        do
        {
            Console.Write("Digite o nome do habitat: ");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Nome não pode ser nulo ou vazio. Digite um nome válido.\n");
            }
            else if (habitatCatalog.IsNameInUse(name))
            {
                Console.WriteLine($"Nome {name} já está sendo usado. Digite um nome diferente.\n");
            }
            else
            {
                validName = true;
            }
        } while (!validName);

        return name;
    }

    static string GetValidatedHabitatDescription()
    {
        string description;
        bool validDescription = false;

        do
        {
            Console.Write("Digite a descrição do habitat: ");
            description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Descrição não pode ser nula ou vazia. Digite uma descrição válida.\n");
            }
            else
            {
                validDescription = true;
            }
        } while (!validDescription);

        return description;
    }

    static void ShowAllHabitats(IReport report)
    {
        report.DisplayAllHabitats();
    }

    static void AssociateHabitatToSpecies(ISpeciesCatalog speciesCatalog, IHabitatCatalog habitatCatalog)
    {
        if (speciesCatalog.GetAllSpecies().Count == 0)
        {
            Console.WriteLine("Não há espécies catalogadas.\n");
            return;
        }
        if (habitatCatalog.GetAllHabitats().Count == 0)
        {
            Console.WriteLine("Não há habitats catalogados.\n");
            return;
        }

        int speciesId = GetValidatedSpeciesId(speciesCatalog);
        int habitatId = GetValidatedHabitatId(habitatCatalog);

        ISpecies speciesToUpdate = speciesCatalog.GetSpeciesById(speciesId);
        IHabitat habitatToAssociate = habitatCatalog.GetHabitatById(habitatId);

        speciesToUpdate.Habitat = habitatToAssociate;
        Console.WriteLine($"Habitat {habitatToAssociate.Name} associado à espécie {speciesToUpdate.Name} com sucesso.\n");
    }

    static string GetValidatedSpeciesStatus()
    {
        int statusChoice;
        string status = string.Empty;

        do
        {
            Console.WriteLine("Digite o status da espécie:");
            Console.WriteLine("1. Ativa");
            Console.WriteLine("2. Extinta");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out statusChoice))
            {
                if (statusChoice == 1)
                {
                    status = "Ativa";
                }
                else if (statusChoice == 2)
                {
                    status = "Extinta";
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número.\n");
            }

        } while (statusChoice != 1 && statusChoice != 2);

        return status;
    }



static int GetValidatedSpeciesId()
    {
        int id;
        bool validId = false;

        do
        {
            Console.Write("Digite o ID da espécie: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out id) && id > 0)
            {
                validId = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número válido.\n");
            }

        } while (!validId);

        return id;
    }

    static int GetValidatedHabitatId()
    {
        int id;
        bool validId = false;

        do
        {
            Console.Write("Digite o ID do habitat: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out id) && id > 0)
            {
                validId = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número válido.\n");
            }

        } while (!validId);

        return id;
    }
}