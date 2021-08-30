using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsApi.Models
{
    public class Ticket
    {
        public Ticket()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        public DateTime DateExpiration { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public List<Reserve> Reserves{ get; set; }


    }
}
