﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Projeto
    {
        public int Id;
        public int Id_Cliente;
        public string Nome;
        public DateTime Data_Criacao;
        public DateTime Data_Finalizacao;

        public Cliente Cliente;
    }
}
