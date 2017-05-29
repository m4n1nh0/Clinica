using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUnit.Models
{
    public class Especialidade
    {
        private Int32 Id;
        private String Nome;
        private String Descri;

        public string descri
        {
            get
            {
                return Descri;
            }

            set
            {
                Descri = value;
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
    }
}