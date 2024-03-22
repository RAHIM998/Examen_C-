using Gestion_De_Facturation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_De_Facturation.Repository
{
    class AffichagePaiementRepository
    {
        private readonly MyDbContext myDbContext;


        //Constructeur
        public AffichagePaiementRepository(MyDbContext dbContext)
        {
            myDbContext = dbContext;
        }


        //Affichage des paiements
        public void AffichageDesPaiements()
        {
            var paiements = myDbContext.Paiements.ToList();

            if (paiements.Any())
            {
                Console.WriteLine("Liste des paiements :");
                Console.WriteLine();
                foreach (var paiement in paiements)
                {
                    Console.WriteLine($"ID Paiement: {paiement.Id}");
                    Console.WriteLine($"Numéro Paiement: {paiement.Numero}");
                    Console.WriteLine($"Date Paiement: {paiement.Date}");
                    Console.WriteLine($"Montant Paiement: {paiement.Montant}");
                    Console.WriteLine($"ID Facture: {paiement.IdFactures}");
                    Console.WriteLine($"Id Compte: {paiement.IdCompte}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Aucun paiement trouvé dans la base de données.");
            }
        }
    }
}



