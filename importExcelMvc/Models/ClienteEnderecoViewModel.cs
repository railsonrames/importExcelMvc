using importExcelMvc.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace importExcelMvc.Models
{
    public class ClienteEnderecoViewModel
    {
        public List<Cliente> Clientes;
        public SelectList Enderecos;        
        public string ClienteEndereco { get; set; }
        public string TermoDeBusca { get; set; }
    }
}
