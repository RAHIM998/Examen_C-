using Gestion_De_Facturation.Models;
using System;
using System.Linq;

namespace Gestion_De_Facturation.Repository
{
    class PayerFactureRepository
    {
        private readonly MyDbContext myDbContext;

        public PayerFactureRepository(MyDbContext dbContext)
        {
            myDbContext = dbContext;
        }

        public Factures ObtenirFactureParNumero(string numero)
        {
            return myDbContext.Factures.FirstOrDefault(f => f.References == numero);
        }

        public void AfficherDetailsFacture(Factures facture)
        {
            Console.WriteLine("Détails de la facture :");
            Console.WriteLine($"Références : {facture.References}");
            Console.WriteLine($"Montant : {facture.Montant}");
            Console.WriteLine($"Fournisseur : {facture.Fournisseur}");
            Console.WriteLine($"Téléphone du client : {facture.TeleClient}");
        }


        // Méthode de génération du numéro de paiement 
        public string GenererNumeroPaiement()
        {
            return $"{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N").Substring(0, 4)}";
        }

        public bool PayerFacture(string numCompte, string mtFacture, string referenceFacture)
        {
            if (!int.TryParse(mtFacture, out int montant))
            {
                Console.WriteLine("Montant de la facture non valide !");
                return false;
            }

            Comptes compte = myDbContext.Comptes.FirstOrDefault(c => c.Numero == numCompte);

            if (compte != null && compte.Solde >= montant)
            {
                Factures facture = myDbContext.Factures.FirstOrDefault(f => f.References == referenceFacture);

                if (facture != null)
                {
                    // Génération du numéro de paiement
                    string numeroPaiement = GenererNumeroPaiement();

                    compte.Solde -= montant;

                    Paiements paiement = new Paiements
                    {
                        Numero = numeroPaiement,
                        Date = DateTime.Now,
                        Montant = montant,
                        IdFactures = facture.Id,
                        IdCompte = compte.Id
                    };

                    myDbContext.Paiements.Add(paiement);
                    myDbContext.SaveChanges();

                    Console.WriteLine("Paiement effectué avec succès !");
                    return true;
                }
                else
                {
                    Console.WriteLine("Aucune facture trouvée avec la référence spécifiée !");
                }
            }
            else
            {
                Console.WriteLine("Ce compte n'existe pas ou son solde est inférieur au montant dû !");
                return false;
            }

            return false;
        }



        //Méthode de consultation du solde
        public int ConsulterSolde(string numCompte)
        {
            Comptes compte = myDbContext.Comptes.FirstOrDefault(c => c.Numero == numCompte);

            if (compte != null)
            {
                Console.WriteLine($"Le montant actuel est : {compte.Solde}");
                return compte.Solde;
            }

            return -1;
        }
    }
}
