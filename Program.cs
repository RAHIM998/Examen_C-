using Gestion_De_Facturation.Models;
using Gestion_De_Facturation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_De_Facturation
{
    class Program
    {
        static MyDbContext myDbContext = new MyDbContext();
        private static readonly PayerFactureRepository payerfactureRepository = new PayerFactureRepository(new MyDbContext());
        private static readonly AffichagePaiementRepository affichagepaiementRepository = new AffichagePaiementRepository(new MyDbContext());
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Payer facture");
                Console.WriteLine("2. Consulter un solde");
                Console.WriteLine("3. Afficher les paiements");
                Console.WriteLine("4. Quitter");

                Console.Write("Choisissez une option compris entre 1 et 4: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Entrez le numéro de la facture à rechercher : ");
                        string numero = Console.ReadLine();
                        Factures factures = payerfactureRepository.ObtenirFactureParNumero(numero);

                        if (factures != null)
                        {
                            payerfactureRepository.AfficherDetailsFacture(factures);

                            string refFacture = factures.References;

                            Console.WriteLine("Donner le numero de compte : ");
                            string numCompte = Console.ReadLine();
                            try
                            {

                                if (payerfactureRepository.PayerFacture(numCompte, factures.Montant, refFacture))
                                {
                                    payerfactureRepository.ConsulterSolde(numCompte);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erreur lors du paiement de la facture : {ex.Message}");
                            }
                        }

                        break;


                    case "2":

                        Console.WriteLine("Donner le numero de compte svp : ");
                        string NumeroCompte = Console.ReadLine();

                        payerfactureRepository.ConsulterSolde(NumeroCompte);


                        break;

                    case "3":

                        affichagepaiementRepository.AffichageDesPaiements();

                        break;

                    case "4":

                        quit = true;

                        break;

                    default:

                        Console.WriteLine("Choix non valide. Veuillez choisir une option entre 1 et 4.");

                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
