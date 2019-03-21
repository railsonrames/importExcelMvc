using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace importExcelMvc.Data
{
    public partial class Cliente
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 7)]        
        public string Nome { get; set; }        
        public string Endereco { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Condominio { get; set; }        
        [Required]
        public string Telefone { get; set; }
    }
}
