﻿namespace DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Status { get; set; }
    }
}
