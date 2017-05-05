﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    /*    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [NOME]     VARCHAR (50) NOT NULL,
    [CPF]      VARCHAR (11) NOT NULL,
    [TELEFONE] VARCHAR (11) NULL,
    [CRM]      CHAR (10)    NOT NULL,
    [ENDERECO] VARCHAR (50) NULL,
    [CIDADE]   VARCHAR (50) NULL,
    [UF]       CHAR (2)     NULL,
    [TURNO]    CHAR (1)     NOT NULL,
    */
    public class Medico
    {

        private Int32 Id;
        private String Nome;
        private String CPF;
        private String Telefone;
        private Char CRM;
        private String Endereco;
        private String Cidade;
        private Char UF;
        private Char Turno;

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

        public char uf
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

        public char crm
        {
            get
            {
                return CRM;
            }

            set
            {
                CRM = value;
            }
        }
        public char turno
        {
            get
            {
                return Turno;
            }

            set
            {
                Turno = value;
            }
        }
    }
}