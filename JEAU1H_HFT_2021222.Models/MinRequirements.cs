using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Models
{
    public class MinRequirements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReqId { get; set; }
       
        [StringLength(240)]
        public string CPU { get; set; }
        [StringLength(240)]
        public string GPU { get; set; }

        public MinRequirements()
        {

        }
        public MinRequirements(int id,  string cpu, string gpu)
        {
            this.ReqId = id;
           
            this.CPU = cpu;
            this.GPU = gpu;
        }
    }
}
