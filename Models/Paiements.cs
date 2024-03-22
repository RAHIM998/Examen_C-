using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_De_Facturation.Models
{
    class Paiements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Date { get; set; }
        public int Montant { get; set; }
        [ForeignKey("Factures")]
        public int IdFactures { get; set; }
        public virtual Factures Factures { get; set; }
        [ForeignKey("Comptes")]
        public int IdCompte { get; set; }
        public virtual Comptes Comptes { get; set; }
    }
}
