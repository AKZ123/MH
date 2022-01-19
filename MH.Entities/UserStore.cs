using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Entities
{
    public class UserStore
    {
        [Key, Column(Order = 1)]
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }


        [Key, Column(Order = 2)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string UserStatus { get; set; }
        //public UserStatus UserStatus { get; set; }
        public DateTime StartDate { get; set; }
    }
}
