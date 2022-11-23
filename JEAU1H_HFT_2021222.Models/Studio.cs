using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Models
{
    public class Studio
    {

        [StringLength(240)]
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioID { get; set; }
        [StringLength(240)]
        public string CEOName { get; set; }
        public Studio()
        {

        }
        public Studio(string name, int id, string ceo)
        {
            this.Name = name;
            this.StudioID = id;
            this.CEOName = ceo;
        }
        public Studio(string name, string ceo)
        {
            this.Name = name;
            
            this.CEOName = ceo;
        }
        public override bool Equals(object obj)
        {
            Studio b = obj as Studio;
            if(b == null)
            {
                return false;
            }
            return (b.CEOName == this.CEOName && b.Name == this.Name && this.StudioID == b.StudioID);
        }
    }
}
