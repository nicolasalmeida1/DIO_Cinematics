using System;

namespace Dio_Cinematics
{
    public class Cinematic : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo {get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Cinematic(int id, Genero genero, string titulo, string descricao, int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "+ this.Genero + Environment.NewLine;
            retorno += "Título: "+ this.Titulo + Environment.NewLine;
            retorno += "Descrição: "+ this.Descricao + Environment.NewLine;
            retorno += "Ano: "+ this.Ano + Environment.NewLine;
            retorno += "Excluido: "+ this.Excluido;
            return retorno;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}