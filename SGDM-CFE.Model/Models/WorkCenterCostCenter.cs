﻿namespace SGDM_CFE.Model.Models
{
    public partial class WorkCenterCostCenter
    {
        public int Id { get; set; }
        public int WorkCenterId { get; set; }
        public int CostCenterId { get; set; }

        public virtual CostCenter CostCenter { get; set; } = null!;
        public virtual WorkCenter WorkCenter { get; set; } = null!;

        public virtual ICollection<State> States { get; set; } = [];
    }
}