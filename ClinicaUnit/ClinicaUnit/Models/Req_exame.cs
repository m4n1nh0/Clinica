using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    /*    [id_paciente] INT            NOT NULL,
    [id_exame]    INT            NOT NULL,
    [DTEXAME]     DATE           NOT NULL,
    [VALOR]       DECIMAL (9, 2) NULL,
    [TIPO]        CHAR (1)       NOT NULL,
    [CONVENIO]    VARCHAR (50)   NULL,
    */
    public class Req_exame
    {
        private Int32 Id_paciente;
        private Int32 Id_exame;
        private DateTime Dtexame;
        private Decimal Valor;
        private Char Tipo;
        private String Convenio;

        public int id_paciente
        {
            get
            {
                return Id_paciente;
            }

            set
            {
                Id_paciente = value;
            }
        }

        public int id_exame
        {
            get
            {
                return Id_exame;
            }

            set
            {
                Id_exame = value;
            }
        }

        public DateTime dtexame
        {
            get
            {
                return Dtexame;
            }

            set
            {
                Dtexame = value;
            }
        }

        public decimal valor
        {
            get
            {
                return Valor;
            }

            set
            {
                Valor = value;
            }
        }

        public char tipo
        {
            get
            {
                return Tipo;
            }

            set
            {
                Tipo = value;
            }
        }

        public string convenio
        {
            get
            {
                return Convenio;
            }

            set
            {
                Convenio = value;
            }
        }

    }
}