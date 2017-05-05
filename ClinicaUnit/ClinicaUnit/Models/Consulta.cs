using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    /*     [id_paciente]  INT           NOT NULL,
    [id_convenio]  INT           NOT NULL,
    [id_medico]    INT           NOT NULL,
    [DTCONSULTA]   DATE          NOT NULL,
    [TURNO]        CHAR (1)      NOT NULL,
    [SITUACAO]     CHAR (1)      NOT NULL,
    [MEDICAMENTOS] VARCHAR (300) NOT NULL,
    */
    public class Consulta
    {
        private Int32 Id_paciente;
        private Int32 Id_convenio;
        private Int32 Id_medico;
        private DateTime Dtconsulta;
        private Char Turno;
        private Char Situacao;
        private String Medicamentos;

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

        public int id_convenio
        {
            get
            {
                return Id_convenio;
            }

            set
            {
                Id_convenio = value;
            }
        }

        public int id_medico
        {
            get
            {
                return Id_medico;
            }

            set
            {
                Id_medico = value;
            }
        }

        public DateTime dtconsulta
        {
            get
            {
                return Dtconsulta;
            }

            set
            {
                Dtconsulta = value;
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

        public char situacao
        {
            get
            {
                return Situacao;
            }

            set
            {
                Situacao = value;
            }
        }

        public string medicamentos
        {
            get
            {
                return Medicamentos;
            }

            set
            {
                Medicamentos = value;
            }
        }
    }
}