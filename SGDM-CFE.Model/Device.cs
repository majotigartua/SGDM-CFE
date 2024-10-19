using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class Device
    {
        [Column("IdDevice")]
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public bool IsCriticalMission { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public int IdBusinessProcess { get; set; }
        public int IdCostCenter { get; set; }
        public int IdWorkCenter { get; set; }

        public virtual BusinessProcess BusinessProcess { get; set; }
        public virtual CostCenter CostCenter { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
        public virtual ICollection<MobileDevice> MobileDevices { get; set; }
        public virtual ICollection<OpticalReader> OpticalReaders { get; set; }

        public virtual ICollection<State> States { get; set; }

        public Device()
        {
            MobileDevices = new HashSet<MobileDevice>();
            OpticalReaders = new HashSet<OpticalReader>();
            States = new HashSet<State>();
        }
    }
}