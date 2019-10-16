using System;
using System.Globalization;

namespace AvaliacaoCore
{
    public class Configuracao
    {
        protected static Configuracao instancia;

        public string UF { get; }

        protected Configuracao(string uf)
        {
            UF = uf.ToLower();
        }

        public static Configuracao Instancia
        {
            get
            {
                if (instancia == null)
                    throw new NullReferenceException("Configuração não inicializada");

                return instancia;
            }
        }

        public static void Inicializar(string uf)
        {
            if(instancia != null) 
                throw new ApplicationException("Dupla inicialização de configuração");
            
            instancia = new Configuracao(uf);
        }

        public bool EhSantaCatarina => UF == "sc";
        public bool EhParana => UF == "pr";
    }
}