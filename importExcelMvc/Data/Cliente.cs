using System;
using System.Collections.Generic;

namespace importExcelMvc.Data
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Condominio { get; set; }
        public string Telefone { get; set; }
    }
}
