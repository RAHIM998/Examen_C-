using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_De_Facturation.Models
{
    class Factures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string References { get; set; }
        public string Montant { get; set; }
        public string Fournisseur { get; set; }
        public string TeleClient { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public virtual Clients Client { get; set; }
        public virtual ICollection<Paiements> Paiements { get; set; }
    }
}
                                                                                       