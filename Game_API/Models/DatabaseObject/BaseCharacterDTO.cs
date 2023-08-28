﻿using System.ComponentModel.DataAnnotations;

namespace API.Models.DatabaseObject
{
    public class BaseCharacterDTO
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int typeId { get; set; }
    }
}