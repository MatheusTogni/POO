using System;
using Classes;

class Program
{
    static void Main(string[] args)
    {
        SpeciesCatalog speciesCatalog = new SpeciesCatalog();
        HabitatCatalog habitatCatalog = new HabitatCatalog();
        Report report = new Report(speciesCatalog, habitatCatalog);
        int choice = 0;

        do
        {
            // Exibir menu
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

            // Ler escolha do usuário
            if (int.TryParse(Console.ReadLine(), out choice))
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
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.\n");
            }

        } while (choice != 8);
    }

    static void CatalogSpecies(SpeciesCatalog speciesCatalog)
    {
        int id;
        bool validId = false;

        do
        {
            id = GetValidatedSpeciesId();
            if (speciesCatalog.IsIdInUse(id))
            {
                Species species = speciesCatalog.GetSpeciesById(id);
                Console.WriteLine($"ID já está sendo usado pela espécie: {species.Name}\n");
            }
            else
            {
                validId = true;
            }
        } while (!validId);

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

        string status = GetValidatedSpeciesStatus();

        Species newSpecies = new Species(id, name, status);
        speciesCatalog.CatalogSpecies(newSpecies);
    }

    static void ChangeSpeciesStatus(SpeciesCatalog speciesCatalog)
    {
        int id = GetValidatedSpeciesId();
        Species species = speciesCatalog.GetSpeciesById(id);
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

    static void ShowSpeciesReport(Report report)
    {
        int id = GetValidatedSpeciesId();
        report.DisplaySpeciesById(id);
    }

    static void ShowAllSpecies(Report report)
    {
        report.DisplayAllSpecies();
    }

    static void CatalogHabitat(HabitatCatalog habitatCatalog)
    {
        int id;
        bool validId = false;

        do
        {
            id = GetValidatedHabitatId();
            if (habitatCatalog.IsIdInUse(id))
            {
                Habitat habitat = habitatCatalog.GetHabitatById(id);
                Console.WriteLine($"ID já está sendo usado pelo habitat: {habitat.Name}\n");
            }
            else
            {
                validId = true;
            }
        } while (!validId);

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

        Habitat newHabitat = new Habitat(id, name, description);
        habitatCatalog.CatalogHabitat(newHabitat);
    }

    static void ShowAllHabitats(Report report)
    {
        report.DisplayAllHabitats();
    }

    static void AssociateHabitatToSpecies(SpeciesCatalog speciesCatalog, HabitatCatalog habitatCatalog)
    {
        if (speciesCatalog.GetAllSpecies().Count == 0 && habitatCatalog.GetAllHabitats().Count == 0)
        {
            Console.WriteLine("Não há espécies nem habitats catalogados.\n");
            return;
        }
        else if (speciesCatalog.GetAllSpecies().Count == 0)
        {
            Console.WriteLine("Não há espécies catalogadas.\n");
            return;
        }
        else if (habitatCatalog.GetAllHabitats().Count == 0)
        {
            Console.WriteLine("Não há habitats catalogados.\n");
            return;
        }

        int speciesId;
        bool validSpeciesId = false;

        do
        {
            speciesId = GetValidatedSpeciesId();
            Species species = speciesCatalog.GetSpeciesById(speciesId);
            if (species == null)
            {
                Console.WriteLine("Espécie não encontrada. Digite um ID válido.\n");
            }
            else
            {
                validSpeciesId = true;
            }
        } while (!validSpeciesId);

        int habitatId;
        bool validHabitatId = false;

        do
        {
            habitatId = GetValidatedHabitatId();
            Habitat habitat = habitatCatalog.GetHabitatById(habitatId);
            if (habitat == null)
            {
                Console.WriteLine("Habitat não encontrado. Digite um ID válido.\n");
            }
            else
            {
                validHabitatId = true;
            }
        } while (!validHabitatId);

        Species speciesToUpdate = speciesCatalog.GetSpeciesById(speciesId);
        Habitat habitatToAssociate = habitatCatalog.GetHabitatById(habitatId);

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