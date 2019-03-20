using importExcelMvc.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace importExcelMvc.Models
{
    public class ClienteCondominioViewModel
    {
        public List<Cliente> Clientes;
        public SelectList Condominios;
        public string ClienteCondominio { get; set; }
        public string TermoDeBusca { get; set; }
    }
}