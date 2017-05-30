using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class ExameConvenio
    {
        private Int32 Id_exame;
        private Int32 Id_conv;
        private String NomeConv;
        private String Sigla;

        public int Id_exame1
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

        public int Id_conv1
        {
            get
            {
                return Id_conv;
            }

            set
            {
                Id_conv = value;
            }
        }

        public string NomeConv1
        {
            get
            {
                return NomeConv;
            }

            set
            {
                NomeConv = value;
            }
        }

        public string Sigla1
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
    }
}