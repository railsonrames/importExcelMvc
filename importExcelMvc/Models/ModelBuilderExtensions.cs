using importExcelMvc.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace importExcelMvc.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                    new Cliente
                    {
                        Id = 1,
                        Nome = "Fulano de Tal da Silva Sauro",
                        Endereco = "ST. SAGOCAN LT. 2 RES. JK BL. C APTO. 701",
                        Condominio = "RESIDENCIAL JK",
                        Telefone = "6197745120"
                    },
                    new Cliente
                    {
                        Id = 2,
                        Nome = "Rosicleide Morais Oliveira Costa e Silva",
                        Endereco = "ST. SAGOCAN LT. 3 RES. ESPLANADA BL. A APTO. 1101",
                        Condominio = "RESIDENCIAL ESPLANADA",
                        Telefone = "61983325471"
                    },
                    new Cliente
                    {
                        Id = 3,
                        Nome = "Basília Rodrigues de Sá",
                        Endereco = "SHJB COND. ESTÂNCIA QUINTAS DA ALVORADA RUA 5 CASA 23",
                        Condominio = "ESTÂNCIA QUINTAS DA ALVORADA",
                        Telefone = "6132050411"
                    },
                    new Cliente
                    {
                        Id = 4,
                        Nome = "Virgolina Inácia Pereira dos Montes",
                        Endereco = "SHJB COND. ESTÂNCIA QUINTAS DA ALVORADA RUA 12 CASA 6",
                        Condominio = "ESTÂNCIA QUINTAS DA ALVORADA",
                        Telefone = "61982475151"
                    },
                    new Cliente
                    {
                        Id = 5,
                        Nome = "Balbino Diniz de Oliveira Conde",
                        Endereco = "AOS 7 BL. A APTO. 16, ÁREA OCTOGONAL, CRUZEIRO",
                        Condominio = "CONDOMÍNIO POR DO SOL",
                        Telefone = "61984217140"
                    }
                );
        }
    }
}
