using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Models
{
    public class Game
    {
        [StringLength(240)]
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }
        public string Pyear { get; set; }

        public int StudioId { get; set; }
        public int ReqId { get; set; }
        public Game()
        {

        }
        public Game(string name, int id, string pyear, int studioId, int reqid)
        {
            this.Name = name;
            this.GameID = id;
            this.Pyear = pyear;
            this.StudioId = studioId;
            this.ReqId = reqid;
        }
        public Game(string name, string pyear, int studioId, int reqid)
        {
            this.Name = name;
            this.Pyear = pyear;
            this.StudioId = studioId;
            this.ReqId = reqid;
        }
    }
}
