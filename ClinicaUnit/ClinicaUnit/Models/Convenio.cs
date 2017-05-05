using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    /*    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [NOME]     VARCHAR (50) NOT NULL,
    [SIGLA]    CHAR (10)    NOT NULL,
    [TELEFONE] CHAR (11)    NOT NULL,
    */
    public class Convenio
    {
        private Int32 Id;
        private String Nome;
        private Char Sigla;
        private Char Telefone;

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

        public char sigla
        {
            get
            {
                return Sigla;
            }

            set
            {
                Sigla = value;
            }
        }

        public char telefone
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
    }
}