using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    /*    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [NOME]     VARCHAR (50) NOT NULL,
    [CPF]      VARCHAR (11) NOT NULL,
    [TELEFONE] VARCHAR (11) NOT NULL,
    [ENDERECO] VARCHAR (50) NOT NULL,
    [CIDADE]   VARCHAR (50) NOT NULL,
    [UF]       CHAR (2)     NOT NULL,
    [PLANO]    VARCHAR (20) NOT NULL,
    [SEXO]     CHAR (1)     NOT NULL,
    [DTNACI]   DATE         NOT NULL,
    */
    public class Paciente
    {
        private Int32 Id;
        private String Nome;
        private String CPF;
        private String Telefone;
        private String Endereco;
        private String Cidade;
        private String UF;
        private String Plano;
        private String Sexo;
        private DateTime Dtnaci;

        public int id
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string nome
        {
            get
            {
                return Nome;
            }

            set
            {
                Nome = value;
            }
        }

        public string cpf
        {
            get
            {
                return CPF;
            }

            set
            {
                CPF = value;
            }
        }

        public string telefone
        {
            get
            {
                return Telefone;
            }

            set
            {
                Telefone = value;
            }
        }

        public string endereco
        {
            get
            {
                return Endereco;
            }

            set
            {
                Endereco = value;
            }
        }

        public string cidade
        {
            get
            {
                return Cidade;
            }

            set
            {
                Cidade = value;
            }
        }

        public string uf
        {
            get
            {
                return UF;
            }

            set
            {
                UF = value;
            }
        }

        public string plano
        {
            get
            {
                return Plano;
            }

            set
            {
                Plano = value;
            }
        }

        public string sexo
        {
            get
            {
                return Sexo;
            }

            set
            {
                Sexo = value;
            }
        }
        public DateTime dtnaci
        {
            get
            {
                return Dtnaci;
            }

            set
            {
                Dtnaci = value;
            }
        }
    }
}