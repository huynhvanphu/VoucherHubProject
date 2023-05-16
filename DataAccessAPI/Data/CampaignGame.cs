using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("CampaignGame")]
    public class CampaignGame
    {
        [Key]
        public Guid Id { set; get; }

        [StringLength(255)]
        public string Name { set; get; }

        public virtual ICollection<Campaign> Campaigns { set; get; }

    }
}
