using System;

class Program
{
    static void Main(string[] args)
    {
        SpeciesCatalog speciesCatalog = new SpeciesCatalog();
        HabitatCatalog habitatCatalog = new HabitatCatalog();
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
                        CatalogSpecies(speciesCatalog, habitatCatalog);
                        break;
                    case 2:
                        ChangeSpeciesStatus(speciesCatalog);
                        break;
                    case 3:
                        ShowSpeciesReport(speciesCatalog);
                        break;
                    case 4:
                        ShowAllSpecies(speciesCatalog);
                        break;
                    case 5:
                        CatalogHabitat(habitatCatalog);
                        break;
                    case 6:
                        ShowAllHabitats(habitatCatalog);
                        break;
                    case 7:
                        AssociateHabitatToSpecies(speciesCatalog, habitatCatalog);
                        break;
                    case 8:
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

    // Método para catalogar uma nova espécie
    static void CatalogSpecies(SpeciesCatalog speciesCatalog, HabitatCatalog habitatCatalog)
    {
        int id;
        bool validId = false;

        do
        {
            id = GetSpeciesId();
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
            if (speciesCatalog.IsNameInUse(name))
            {
                Console.WriteLine($"Nome {name} já está sendo usado. Digite um nome diferente.\n");
            }
            else
            {
                validName = true;
            }
        } while (!validName);

        string status = GetSpeciesStatus();

        Species newSpecies = new Species(id, name, status);
        speciesCatalog.CatalogSpecies(newSpecies);
    }

    // Método para alterar o status de uma espécie
    static void ChangeSpeciesStatus(SpeciesCatalog speciesCatalog)
    {
        int id = GetSpeciesId();
        Species species = speciesCatalog.GetSpeciesById(id);
        if (species != null)
        {
            string newStatus = GetSpeciesStatus();
            species.ChangeStatus(newStatus);
        }
        else
        {
            Console.WriteLine("Espécie não encontrada.\n");
        }
    }

    // Método para mostrar relatório de uma espécie pelo ID
    static void ShowSpeciesReport(SpeciesCatalog speciesCatalog)
    {
        int id = GetSpeciesId();
        speciesCatalog.DisplaySpeciesById(id);
    }

    // Método para mostrar todas as espécies catalogadas
    static void ShowAllSpecies(SpeciesCatalog speciesCatalog)
    {
        speciesCatalog.DisplayAllSpecies();
    }

    // Método para catalogar um novo habitat
    static void CatalogHabitat(HabitatCatalog habitatCatalog)
    {
        int id;
        bool validId = false;

        do
        {
            id = GetHabitatId();
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
            if (habitatCatalog.IsNameInUse(name))
            {
                Console.WriteLine($"Nome {name} já está sendo usado. Digite um nome diferente.\n");
            }
            else
            {
                validName = true;
            }
        } while (!validName);

        Console.Write("Digite a descrição do habitat: ");
        string description = Console.ReadLine();

        Habitat newHabitat = new Habitat(id, name, description);
        habitatCatalog.CatalogHabitat(newHabitat);
    }

    // Método para mostrar todos os habitats catalogados
    static void ShowAllHabitats(HabitatCatalog habitatCatalog)
    {
        habitatCatalog.DisplayAllHabitats();
    }

    // Método para associar um habitat a uma espécie
    static void AssociateHabitatToSpecies(SpeciesCatalog speciesCatalog, HabitatCatalog habitatCatalog)
    {
        Console.Write("Digite o ID da espécie que deseja associar um habitat: ");
        int speciesId = int.Parse(Console.ReadLine());
        Species species = speciesCatalog.GetSpeciesById(speciesId);
        if (species != null)
        {
            Console.Write("Digite o ID do habitat que deseja associar: ");
            int habitatId = int.Parse(Console.ReadLine());
            Habitat habitat = habitatCatalog.GetHabitatById(habitatId);
            if (habitat != null)
            {
                species.Habitat = habitat;
                Console.WriteLine($"Habitat {habitat.Name} associado à espécie {species.Name} com sucesso.\n");
            }
            else
            {
                Console.WriteLine("Habitat não encontrado.\n");
            }
        }
        else
        {
            Console.WriteLine("Espécie não encontrada.\n");
        }
    }

    // Método para obter o status da espécie com validação
    static string GetSpeciesStatus()
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

    // Método para obter o ID da espécie com validação
    static int GetSpeciesId()
    {
        int id;
        bool validId = false;

        do
        {
            Console.Write("Digite o ID da espécie: ");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                validId = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número.\n");
            }

        } while (!validId);

        return id;
    }

    // Método para obter o ID do habitat com validação
    static int GetHabitatId()
    {
        int id;
        bool validId = false;

        do
        {
            Console.Write("Digite o ID do habitat: ");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                validId = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número.\n");
            }

        } while (!validId);

        return id;
    }
}
