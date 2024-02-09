﻿namespace NorthwindWebMvc.Basic.Models.Interface
{
    public interface IAuditedModel
    {
        public string CreateByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedON { get; set; }
    }
}
